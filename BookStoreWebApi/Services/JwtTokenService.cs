using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStoreWebApi.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreWebApi.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration Configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            var expireDate = DateTime.Now.AddMinutes(15);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = expireDate
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var createdToken = tokenHandler.WriteToken(token);

            var accessToken = new Token
            {
                AccessToken = createdToken,
                ExpireDate = expireDate,
                RefreshToken = CreateRefrehToken()
            };
            return accessToken;
        }

        public string CreateRefrehToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
