using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SafeCity.Core.Repositories;
using SafeCity.Services;

namespace SafeCity.Middleware
{
    public static class UserInfoMiddleware
    {
        public static IApplicationBuilder UseRoleInTokenSetup(this IApplicationBuilder builder)
        {
            builder.Use(async (context, next) =>
            {
                var tokenService = context.RequestServices.GetRequiredService<TokenDecryptionService>();
                var tokenUser = tokenService.GetUser();
                if (tokenUser == null)
                {
                    await next();
                    return;
                }

                var userRepository = context.RequestServices.GetRequiredService<IUserRepository>();

                var user = await userRepository.GetUserByEmailAsync(tokenUser.Email);
                if (user == null)
                {
                    user = await userRepository.CreateUserAsync(tokenUser.Email, tokenUser.GivenName, tokenUser.FamilyName, tokenUser.Picture);
                    await userRepository.SaveAsync();
                }

                tokenService.SetupRole(user.Role);

                await next();
            });

            return builder;
        }
    }
}
