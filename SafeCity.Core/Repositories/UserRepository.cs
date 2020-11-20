using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SafeCity.Core.Entities;

namespace SafeCity.Core.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly SafeCityContext _context;

        public UserRepository(SafeCityContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                //.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> CreateUserAsync(string email, string givenName, string familyName, string picture,
            Role role = Role.UnAuthorized)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = email,
                GivenName = givenName,
                FamilyName = familyName,
                Picture = picture,
                Role = role
            };
            var result = await _context.Users.AddAsync(user);

            return result.Entity;
        }

        public async Task<bool> SaveAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result >= 0;
        }
    }
}
