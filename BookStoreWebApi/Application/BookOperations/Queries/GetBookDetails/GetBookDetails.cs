using System;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.BookOperations.Queries.GetBookDetails
{
    public class GetBookDetails
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetBookDetails(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetBookDetailsViewModel Handle()
        {
            var book = _context.Books.Include(x => x.Genre).Include(x => x.Author).Where(x => x.Id == Id).SingleOrDefault();

            if (book == null)
            {
                throw new Exception("Kitap bulunamadı");
            }

            var bookDetails = _mapper.Map<GetBookDetailsViewModel>(book);
            return bookDetails;
        }

        public class GetBookDetailsViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string Genre { get; set; }
            public DateTime PublishDate { get; set; }
            public string Author { get; set; }
        }
    }
}
