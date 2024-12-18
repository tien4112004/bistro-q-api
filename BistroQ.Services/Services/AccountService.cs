using AutoMapper;
using BistroQ.Core.Dtos.Auth;
using BistroQ.Core.Dtos.Tables;
using BistroQ.Core.Entities;
using BistroQ.Core.Exceptions;
using BistroQ.Core.Interfaces;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Services.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly BistroQContext _context;
    private readonly IMapper _mapper;

    public AccountService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, BistroQContext context, IMapper mapper)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _context = context;
        _mapper = mapper;
    }

    public async Task<AccountDto> GetByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            throw new ResourceNotFoundException("User not found");
        }

        var role = await _userManager.GetRolesAsync(user);
        return new AccountDto
        {
            Id = user.Id,
            Username = user.UserName,
            Role = role.FirstOrDefault(),
            TableId = user.TableId
        };
    }

    // NOTE: Cannot split this method into QueryableBuilder because of the group by clause
public async Task<(IEnumerable<AccountDto> Accounts, int Count)> GetAllAsync(
    AccountCollectionQueryParams query)
{
    var usersWithRoles = _context.Users
        .Include(u => u.Table)
        .ThenInclude(t => t.Zone)
        .Select(u => new
        {
            User = u,
            Role = _context.UserRoles
                .Where(ur => ur.UserId == u.Id)
                .Join(_context.Roles,
                    ur => ur.RoleId,
                    r => r.Id,
                    (ur, r) => r.Name)
                .FirstOrDefault()
        });

    if (!string.IsNullOrWhiteSpace(query.Username))
    {
        usersWithRoles = usersWithRoles.Where(x => EF.Functions.Like(
            x.User.UserName, 
            $"%{query.Username}%"
        ));
    }

    if (!string.IsNullOrWhiteSpace(query.Role))
    {
        usersWithRoles = usersWithRoles.Where(u => u.Role == query.Role);
    }
    
    if (!string.IsNullOrWhiteSpace(query.Zone))
    {
        usersWithRoles = usersWithRoles.Where(u => u.User.Table != null 
                                                   && u.User.Table.Zone != null 
                                                   && u.User.Table.Zone.Name == query.Zone);
    }

    var totalCount = await usersWithRoles.CountAsync();

    var sortedUsers = query.OrderBy?.ToLower() switch
    {
        "username" => query.OrderDirection == "asc"
            ? usersWithRoles.OrderBy(u => u.User.UserName)
            : usersWithRoles.OrderByDescending(u => u.User.UserName),
        "role" => query.OrderDirection == "asc"
            ? usersWithRoles.OrderBy(u => u.Role)
            : usersWithRoles.OrderByDescending(u => u.Role),
        _ => usersWithRoles.OrderBy(u => u.User.UserName)
    };
    
    var pagedUsers = await sortedUsers
        .Skip(query.Size * (query.Page - 1))
        .Take(query.Size)
        .Select(u => new AccountDto
        {
            Id = u.User.Id,
            Username = u.User.UserName,
            Role = u.Role,
            TableId = u.User.TableId,
            Table = u.User.Table != null ? _mapper.Map<TableDetailDto>(u.User.Table) : null
        })
        .ToListAsync();
    
    return (pagedUsers, totalCount);
}

    public async Task<AccountDto> CreateAccountAsync(CreateAccountDto request)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var user = new AppUser
            {
                UserName = request.Username,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to create user");
            }

            var roleResult = await _userManager.AddToRoleAsync(user, request.Role);
            if (!roleResult.Succeeded)
            {
                throw new Exception("Failed to assign role to user");
            }

            var createdUser = await _userManager.FindByNameAsync(user.UserName);
            if (createdUser == null)
            {
                throw new ResourceNotFoundException("User not found");
            }

            await _unitOfWork.CommitTransactionAsync();

            return new AccountDto
            {
                Id = createdUser.Id,
                Username = createdUser.UserName,
                Role = request.Role
            };
        }
        catch (Exception e)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<AccountDto> UpdateAccountAsync(string id, UpdateAccountDto request)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new ResourceNotFoundException("User not found");
            }

            if (!string.IsNullOrEmpty(request.Username))
                user.UserName = request.Username;

            if (!string.IsNullOrEmpty(request.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, token, request.Password);
                if (!passwordResult.Succeeded)
                {
                    throw new Exception("Failed to reset password");
                }
            }

            if (!string.IsNullOrEmpty(request.Role))
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                {
                    throw new Exception("Failed to remove roles from user");
                }

                var addRoleResult = await _userManager.AddToRoleAsync(user, request.Role);
                if (!addRoleResult.Succeeded)
                {
                    throw new Exception("Failed to assign role to user");
                }
            }

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new Exception("Failed to update user");
            }

            var updatedUser = await _userManager.FindByIdAsync(id);
            if (updatedUser == null)
            {
                throw new ResourceNotFoundException("User not found");
            }

            await _unitOfWork.CommitTransactionAsync();

            return new AccountDto
            {
                Id = updatedUser.Id,
                Username = updatedUser.UserName,
                Role = request.Role
            };
        }
        catch (Exception e)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<bool> DeleteAccountAsync(string id)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new ResourceNotFoundException("User not found");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to delete user");
            }

            await _unitOfWork.CommitTransactionAsync();
            return true;
        }
        catch (Exception e)
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}