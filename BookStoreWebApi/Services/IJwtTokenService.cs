using System;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Services
{
    public interface IJwtTokenService
    {
        public Token CreateAccessToken(string userId);
        public string CreateRefrehToken();
    }
}
