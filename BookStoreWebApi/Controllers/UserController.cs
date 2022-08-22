using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApi.Application.UserOperations.Command.CreateUser;
using BookStoreWebApi.DataAccess;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.UserOperations.Command.CreateUser.CreateUserCommand;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly BookStoreDBContext _context;

        public UserController(BookStoreDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateViewModel model)
        {
            CreateUserCommand createUserCommand = new CreateUserCommand(_context);
            createUserCommand.Model = model;
            createUserCommand.Handle();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetList()
        {

            return Ok(_context.Users.OrderBy(x => x.Id).ToList());
        }
    }
}
