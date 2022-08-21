using System;
using System.Linq;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.GenreOperations.Command.Delete
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDBContext _context;
        public int Id { get; set; }

        public DeleteGenreCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == Id);

            if (genre == null)
            {
                throw new InvalidOperationException("Tür bulunamadı.");
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
