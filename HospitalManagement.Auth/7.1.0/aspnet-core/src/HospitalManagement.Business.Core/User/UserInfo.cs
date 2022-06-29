using Abp.Dependency;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.User
{
    public class UserInfo : ITransientDependency, IUserInfo
    {
        public UserInfo(IHttpContextAccessor accessor)
        {
            var token = accessor.HttpContext.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(token))
            {
                return;
            }
            Token = token.StartsWith("Bearer ") || token.StartsWith("bearer ") ? token.Substring(7) : token;
            var jwtToken = new JwtSecurityToken(Token);
            UserId = int.Parse(jwtToken.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub).Value);
            Name = jwtToken.Claims.SingleOrDefault(x => x.Type == JwtRegisteredClaimNames.Name).Value;
            Email = jwtToken.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email).Value;
            Role = jwtToken.Claims.Where(x => x.Type == "role").Select(x => x.Value).ToList();
        }

        public string Token { get; private set; }

        public int UserId { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PhoneNumber { get; private set; }

        public List<string> Role { get; private set; }
    }
}
