using System;
using System.Linq;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.BookOperations.Command.Update
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDBContext _context;
        public UpdateBookViewModel Model { get; set; }
        public int Id { get; set; }

        public UpdateBookCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == Id);

            if (book == null)
            {
                throw new Exception("Böyle bir kitap bulunamadı");
            }

            book.Title = Model.Title == default || Model.Title == "string" ? book.Title : Model.Title;
            book.PageCount = Model.PageCount == default ? book.PageCount : Model.PageCount;
            book.GenreId = Model.GenreId == default ? book.GenreId : Model.GenreId;
            book.PublishDate = Model.PublishDate == default ? book.PublishDate : Model.PublishDate;
            book.AuthorId = Model.AuthorId == default ? book.AuthorId : Model.AuthorId;
            _context.SaveChanges();
        }

        public class UpdateBookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public int GenreId { get; set; }
            public DateTime PublishDate { get; set; }
            public int AuthorId { get; set; }
        }
    }
}
