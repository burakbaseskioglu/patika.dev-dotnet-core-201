using System;
using System.Linq;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.BookOperations.Command.Delete
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDBContext _context;

        public int Id { get; set; }

        public DeleteBookCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == Id);

            if (book == null)
            {
                throw new Exception("Kitap bulunamadı.");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
