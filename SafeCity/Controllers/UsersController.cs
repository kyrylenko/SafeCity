using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeCity.Core.Entities;
using SafeCity.Core.Repositories;
using SafeCity.Services;

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
            var givenName = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.GivenName).Value;
            var familyName = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.FamilyName).Value;
            var picture = _httpContextAccessor.HttpContext.User.FindFirst("picture").Value;

            var user = await _userRepository.GetUserByEmailAsync(email)
                       ?? await _userRepository.CreateUserAsync(email, givenName, familyName, picture);

            return Ok(user);
        }
    }
}
