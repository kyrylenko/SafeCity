using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeCity.Core.Repositories;

namespace SafeCity.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UsersController(IUserRepository userRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        [HttpGet]
        public async Task<IActionResult> Me()
        {
            var email = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email).Value;
            var user = await _userRepository.GetUserByEmailAsync(email);

            return Ok(user);
        }
    }
}
