using System.Threading.Tasks;
using SafeCity.Core.Entities;

namespace SafeCity.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(string email, string givenName, string familyName, string picture, Role role = Role.UnAuthorized);
        Task<bool> SaveAsync();
    }
}
