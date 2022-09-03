﻿using System;
using System.Linq;
using BookStoreWebApi.DataAccess;
using BookStoreWebApi.Entities;
using BookStoreWebApi.Services;
using Microsoft.Extensions.Configuration;

namespace BookStoreWebApi.Application.UserOperations.Command.CreateAccessToken
{
    public class CreateAccesstokenCommand
    {
        private readonly BookStoreDBContext _context;
        public UserTokenModel Model { get; set; }
        public IConfiguration Configuration { get; set; }

        public CreateAccesstokenCommand(BookStoreDBContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public Token Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user == null)
            {
                throw new InvalidOperationException("Kullanıcı bulunamadı");
            }

            JwtTokenService tokenService = new JwtTokenService(Configuration);
            var token = tokenService.CreateAccessToken(user);
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
