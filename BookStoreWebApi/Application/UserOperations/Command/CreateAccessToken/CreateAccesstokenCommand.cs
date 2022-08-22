using System;
using System.Linq;
using BookStoreWebApi.DataAccess;
using BookStoreWebApi.Entities;
using BookStoreWebApi.Services;

namespace BookStoreWebApi.Application.UserOperations.Command.CreateAccessToken
{
    public class CreateAccesstokenCommand
    {
        private readonly BookStoreDBContext _context;
        private readonly IJwtTokenService _tokenService;
        public UserTokenModel Model { get; set; }
        public CreateAccesstokenCommand(BookStoreDBContext context, IJwtTokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public Token Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user == null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı");
            }

            var token = _tokenService.CreateAccessToken(user.Id.ToString());
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.ExpireDate.AddMinutes(5);

            _context.SaveChanges();

            return token;
        }

        public class UserTokenModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
