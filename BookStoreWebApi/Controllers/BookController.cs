using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApi.DataAccess;
using BookStoreWebApi.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {
        private readonly BookStoreDBContext _context;

        public BookController(BookStoreDBContext context)
        {
            _context = context;
        }

        private static List<Book> BookList = new List<Book>
        {
            new Book { Id = 1, Title = "Book 1", PageCount = 219, GenreId = 1, PublishDate = new DateTime(1980, 2, 14) },
            new Book { Id = 2, Title = "Book 2", PageCount = 784, GenreId = 2, PublishDate = new DateTime(2001, 6, 26) },
            new Book { Id = 3, Title = "Book 3", PageCount = 459, GenreId = 3, PublishDate = new DateTime(1994, 12, 30) },
            new Book { Id = 4, Title = "Book 4", PageCount = 146, GenreId = 3, PublishDate = new DateTime(1999, 7, 22) }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookList = _context.Books.OrderBy(x => x.Title).ToList<Book>();
            return Ok(bookList);
        }
    }
}
