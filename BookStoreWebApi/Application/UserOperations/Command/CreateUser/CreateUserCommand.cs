using System;
using System.Linq;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.UserOperations.Command.CreateUser
{
    public class CreateUserCommand
    {
        private readonly BookStoreDBContext _context;
        public UserCreateViewModel Model { get; set; }

        public CreateUserCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == Model.Email);

            if (user != null)
            {
                throw new InvalidOperationException("Böyle bir kullanıcı mevcut");
            }

            _context.Users.Add(new Entities.User { Email = Model.Email, Password = Model.Password });
            _context.SaveChanges();
        }

        public class UserCreateViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
