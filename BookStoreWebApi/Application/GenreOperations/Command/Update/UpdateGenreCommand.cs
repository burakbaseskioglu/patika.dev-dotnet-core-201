using System;
using System.Linq;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.GenreOperations.Command.Update
{
    public class UpdateGenreCommand
    {
        private readonly BookStoreDBContext _context;
        public UpdateGenreViewModel Model { get; set; }
        public int Id { get; set; }

        public UpdateGenreCommand(BookStoreDBContext context)
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

            genre.Name = Model.Name == default || Model.Name == "string" ? genre.Name : Model.Name;
            genre.IsActive = Model.IsActive == default ? genre.IsActive : Model.IsActive;
            _context.SaveChanges();
        }

        public class UpdateGenreViewModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
