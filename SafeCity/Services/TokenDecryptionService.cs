using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SafeCity.Core.Entities;

namespace SafeCity.Services
{
    public class TokenDecryptionService
    {
        private User _cashedUsed;
        public ClaimsIdentity ClaimsIdentity { get; set; }
        public Dictionary<string, string> Claims { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenDecryptionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            ClaimsIdentity = (ClaimsIdentity)_httpContextAccessor.HttpContext.User.Identity;
            Claims = ReadClaims();
        }

        public User GetUser()
        {
            if (_cashedUsed != null)
                return _cashedUsed;

            if (!Claims.Any())
            {
                return null;
            }

            var userInfo = ParseTokenUserInfo();
            return _cashedUsed = userInfo;
        }

        public void SetupRole(Role role)
        {
            ClaimsIdentity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.ToString()));
            Claims = ReadClaims();
            _cashedUsed.Role = role;
        }

        private User ParseTokenUserInfo()
        {
            var email = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.Email).Value;
            var givenName = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.GivenName).Value;
            var familyName = _httpContextAccessor.HttpContext.User.FindFirst(JwtRegisteredClaimNames.FamilyName).Value;
            var picture = _httpContextAccessor.HttpContext.User.FindFirst("picture").Value;

            var userInfo = new User
            {
                Email = email,
                GivenName = givenName,
                FamilyName = familyName,
                Picture = picture,
                Role = Role.UnAuthorized
            };

            return userInfo;
        }

        private Dictionary<string, string> ReadClaims()
        {
            var claims = ClaimsIdentity?.Claims
                         //.Distinct(c => c.Type)
                         .ToDictionary(claim => claim.Type, claim => claim.Value)
                     ?? new Dictionary<string, string>();
            return claims;
        }
    }
}
