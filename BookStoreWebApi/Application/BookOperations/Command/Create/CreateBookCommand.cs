using System;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.Common.Enums;
using BookStoreWebApi.DataAccess;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.BookOperations.Command.Create
{
    public class CreateBookCommand
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateBookModel Model { get; set; }

        public CreateBookCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book != null)
            {
                throw new Exception("Böyle bir kitap mevcut.");
            }

            book = _mapper.Map<Book>(Model);
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
    }
}
