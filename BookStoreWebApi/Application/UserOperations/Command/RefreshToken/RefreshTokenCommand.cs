using System;
using System.Linq;
using BookStoreWebApi.DataAccess;
using BookStoreWebApi.Entities;
using BookStoreWebApi.Services;
using Microsoft.Extensions.Configuration;

namespace BookStoreWebApi.Application.UserOperations.Command.RefreshToken
{
    public class RefreshTokenCommand
    {
        private readonly BookStoreDBContext _context;
        public IConfiguration Configuration { get; set; }
        public string RefreshToken { get; set; }

        public RefreshTokenCommand(BookStoreDBContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);

            if (user == null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı.");
            }
            JwtTokenService tokenService = new JwtTokenService(Configuration);
            var token = tokenService.CreateAccessToken(user);
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(5);
            return token;
        }
    }
}
