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
    /// A task that represents the asynchronous operation.
    /// The task result contains true if account creation was successful; otherwise, false.
    /// </returns>
    /// <remarks>
    /// The default role is set to Client if not specified in the request.
    /// </remarks>
    Task<bool> CreateAccountAsync(CreateAccountDto request);
    
    /// <summary>
    /// Updates an existing user account's information.
    /// </summary>
    /// <param name="id">The unique identifier of the account to update.</param>
    /// <param name="request">The account update data containing the fields to be modified.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains true if account update was successful; otherwise, false.
    /// </returns>
    /// <remarks>
    /// Only provided fields in the request will be updated. Null or empty fields will be ignored.
    /// </remarks>
    Task<bool> UpdateAccountAsync(string id, UpdateAccountDto request);
    
    /// <summary>
    /// Deletes a user account from the system.
    /// </summary>
    /// <param name="id">The unique identifier of the account to delete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains true if account deletion was successful; otherwise, false.
    /// </returns>
    Task<bool> DeleteAccountAsync(string id);
}