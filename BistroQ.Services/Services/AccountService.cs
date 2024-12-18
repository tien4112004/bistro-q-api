using BistroQ.Core.Dtos.Auth;
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

    public AccountService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork, BistroQContext context)
    {
        _userManager = userManager;
        _unitOfWork = unitOfWork;
        _context = context;
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
        var usersWithRoles = from user in _userManager.Users
            join userRole in _context.UserRoles
                on user.Id equals userRole.UserId
            join role in _context.Roles
                on userRole.RoleId equals role.Id
            group role.Name by user
            into userRoles
            select new
            {
                User = userRoles.Key,
                Role = userRoles.First()
            };

        var filteredUsers = usersWithRoles;

        if (!string.IsNullOrWhiteSpace(query.Username))
        {
            filteredUsers = filteredUsers.Where(u =>
                u.User.UserName != null && u.User.UserName.Contains(query.Username));
        }

        if (!string.IsNullOrWhiteSpace(query.Role))
        {
            filteredUsers = filteredUsers.Where(u =>
                u.Role.Equals(query.Role, StringComparison.OrdinalIgnoreCase));
        }

        var totalCount = await filteredUsers.CountAsync();

        var sortedUsers = query.OrderBy?.ToLower() switch
        {
            "username" => query.OrderDirection == "asc"
                ? filteredUsers.OrderBy(u => u.User.UserName)
                : filteredUsers.OrderByDescending(u => u.User.UserName),
            "role" => query.OrderDirection == "asc"
                ? filteredUsers.OrderBy(u => u.Role)
                : filteredUsers.OrderByDescending(u => u.Role),
            _ => filteredUsers.OrderBy(u => u.User.UserName)
        };

        var pagedUsers = await sortedUsers
            .Skip((query.Page - 1) * query.Size)
            .Take(query.Size)
            .Select(ur => new AccountDto
            {
                Id = ur.User.Id,
                Username = ur.User.UserName,
                Role = ur.Role,
                TableId = ur.User.TableId
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