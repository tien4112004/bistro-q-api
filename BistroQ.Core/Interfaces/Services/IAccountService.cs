using BistroQ.Core.Dtos.Auth;
using Microsoft.AspNetCore.Identity;

namespace BistroQ.Core.Interfaces.Services;
/// <summary>
/// Provides functionality for managing user accounts in the restaurant POS system.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Creates a new user account with specified credentials and role.
    /// </summary>
    /// <param name="request">The account creation data containing username, password, and role.</param>
    /// <returns>
    /// A newly created account DTO containing the account information.
    /// </returns>
    /// <remarks>
    /// The default role is set to Client if not specified in the request.
    /// </remarks>
    Task<AccountDto> CreateAccountAsync(CreateAccountDto request);
    
    /// <summary>
    /// Updates an existing user account's information.
    /// </summary>
    /// <param name="id">The unique identifier of the account to update.</param>
    /// <param name="request">The account update data containing the fields to be modified.</param>
    /// <returns>
    /// The updated account DTO containing the account information.
    /// </returns>
    /// <remarks>
    /// Only provided fields in the request will be updated. Null or empty fields will be ignored.
    /// </remarks>
    Task<AccountDto> UpdateAccountAsync(string id, UpdateAccountDto request);
    
    /// <summary>
    /// Deletes a user account from the system.
    /// </summary>
    /// <param name="id">The unique identifier of the account to delete.</param>
    /// <returns>
    /// True if the account was successfully deleted; false if the account doesn't exist.
    /// </returns>
    Task<bool> DeleteAccountAsync(string id);
}