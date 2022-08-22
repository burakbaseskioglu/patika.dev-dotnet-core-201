using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApi.Application.UserOperations.Command.CreateAccessToken;
using BookStoreWebApi.DataAccess;
using BookStoreWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.UserOperations.Command.CreateAccessToken.CreateAccesstokenCommand;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly BookStoreDBContext _context;
        private readonly IJwtTokenService _tokenService;

        public AuthController(IJwtTokenService tokenService, BookStoreDBContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateAccessToken([FromBody]UserTokenModel userTokenModel)
        {
            CreateAccesstokenCommand createAccesstokenCommand = new CreateAccesstokenCommand(_context, _tokenService);
            createAccesstokenCommand.Model = userTokenModel;
            var token = createAccesstokenCommand.Handle();
            return Ok(token);
        }
    }
}
