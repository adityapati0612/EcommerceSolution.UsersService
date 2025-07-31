

using eCommerce.Core.Entities;

namespace eCommerce.Core.RepositoryContracts;

/// <summary>
/// Contract to be implemented by UserRepository that contains data access logic of Users data store
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Method to add the user to data store and return the same user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser> AddUser(ApplicationUser user);

    /// <summary>
    /// Method to get user by email and password and if email and password doesn't match return 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
    

}
