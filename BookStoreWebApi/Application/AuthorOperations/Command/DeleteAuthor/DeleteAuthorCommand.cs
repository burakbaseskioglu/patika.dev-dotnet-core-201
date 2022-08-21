using System;
using System.Linq;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.AuthorOperations.Command.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDBContext _context;

        public int Id { get; set; }

        public DeleteAuthorCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id);

            if (author == null)
            {
                throw new Exception("Yazar bulunamadı.");
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
