using System;
using System.Linq;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDBContext _context;
        public UpdateAuthorViewModel Model { get; set; }
        public int Id { get; set; }

        public UpdateAuthorCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id);

            if (author == null)
            {
                throw new Exception("Böyle bir yazar bulunamadı");
            }

            author.FirstName = Model.FirstName == default || Model.FirstName == "string" ? author.FirstName : Model.FirstName;
            author.LastName = Model.LastName == default || Model.LastName == "string" ? author.LastName : Model.LastName;

            _context.SaveChanges();
        }

        public class UpdateAuthorViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
