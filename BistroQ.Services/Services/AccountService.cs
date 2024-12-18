using BistroQ.Core.Dtos.Auth;
using BistroQ.Core.Entities;
using BistroQ.Core.Interfaces.Services;
using BistroQ.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BistroQ.Services.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly BistroQContext _context;

    public AccountService(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        BistroQContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }
    public async Task<bool> CreateAccountAsync(CreateAccountDto request)
    {
        var user = new AppUser
        {
            UserName = request.Username,
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return false;

        await _userManager.AddToRoleAsync(user, request.Role);

        return true;
    }

    public async Task<bool> UpdateAccountAsync(string id, UpdateAccountDto request)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return false;

        if (!string.IsNullOrEmpty(request.Username))
            user.UserName = request.Username;

        if (!string.IsNullOrEmpty(request.Password))
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, request.Password);
            if (!result.Succeeded)
                return false;
        }

        if (!string.IsNullOrEmpty(request.Role))
        {
            var currentRoles = await _userManager.GetRolesAsync(user);

            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, request.Role);
        }

        var updateResult = await _userManager.UpdateAsync(user);
        return updateResult.Succeeded;
    }

    // Hard delete
    public async Task<bool> DeleteAccountAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
            return false;

        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }
}