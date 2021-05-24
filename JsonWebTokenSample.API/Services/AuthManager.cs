using JsonWebTokenSample.API.Models;
using JsonWebTokenSample.API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JsonWebTokenSample.API.Services
{
    public class AuthManager : IAuthService
    {
        public async Task<MyAccessTokenDto> SignInAsync(LoginDto loginDto)
        {
            if (loginDto.Username != "a" && loginDto.Password != "1")
                throw new Exception("Kullanıcı adı veya şifre yanlış!");

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("custom jwt security key bla bla bla"));
            
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, loginDto.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                Expires = DateTime.UtcNow.AddSeconds(10),
                Issuer = "localhost",
                Audience = "localhost",
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            var access_token = tokenHandler.WriteToken(token);

            return new MyAccessTokenDto { AccessToken = access_token, Type = "Bearer" };
        }
    }
}
