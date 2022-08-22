using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStoreWebApi.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreWebApi.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration Configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Token CreateAccessToken(string userId)
        {
            var key = Encoding.UTF8.GetBytes(Configuration["TokenOptions:SecretKey"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenExpires = DateTime.Now.AddMinutes(15);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId)
                }),
                Expires = tokenExpires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);


            var accessToken = new Token
            {
                AccessToken = tokenHandler.WriteToken(token),
                ExpireDate = tokenExpires,
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
