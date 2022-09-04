using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetAllBooks
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetAllBooks(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetBooksViewModel> Handle()
        {
            var books = _context.Books.Include(x => x.Genre).Include(x => x.Author).OrderBy(x => x.Id).ToList();
            var bookList = _mapper.Map<List<GetBooksViewModel>>(books);
            return bookList;
        }

        public class GetBooksViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public string Genre { get; set; }
            public DateTime PublishDate { get; set; }
            public string Author { get; set; }
        }
    }
}
