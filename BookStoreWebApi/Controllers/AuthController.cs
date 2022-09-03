using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApi.Application.UserOperations.Command.CreateAccessToken;
using BookStoreWebApi.Application.UserOperations.Command.RefreshToken;
using BookStoreWebApi.DataAccess;
using BookStoreWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static BookStoreWebApi.Application.UserOperations.Command.CreateAccessToken.CreateAccesstokenCommand;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly BookStoreDBContext _context;
        public IConfiguration Configuration { get; set; }

        public AuthController(BookStoreDBContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [HttpPost("createtoken")]
        public IActionResult CreateAccessToken([FromBody]UserTokenModel userTokenModel)
        {
            CreateAccesstokenCommand createAccesstokenCommand = new CreateAccesstokenCommand(_context, Configuration);
            createAccesstokenCommand.Model = userTokenModel;
            var token = createAccesstokenCommand.Handle();
            return Ok(token);
        }

        [HttpPost("refreshtoken")]
        public IActionResult RefreshToken([FromQuery]string refreshToken)
        {
            RefreshTokenCommand refreshTokenCommand = new RefreshTokenCommand(_context, Configuration);
            refreshTokenCommand.RefreshToken = refreshToken;
            var token = refreshTokenCommand.Handle();
            return Ok(token);
        }
    }
}
