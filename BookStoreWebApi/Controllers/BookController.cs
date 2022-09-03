using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Command.Create;
using BookStoreWebApi.Application.BookOperations.Command.Delete;
using BookStoreWebApi.Application.BookOperations.Command.Update;
using BookStoreWebApi.Application.BookOperations.Queries.GetBookDetails;
using BookStoreWebApi.Application.BookOperations.Queries.GetBooks;
using BookStoreWebApi.DataAccess;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.BookOperations.Command.Update.UpdateBookCommand;

namespace BookStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetAllBooks getBooks = new GetAllBooks(_context, _mapper);
            var bookList = getBooks.Handle();
            return Ok(bookList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookById(int id)
        {
            GetBookDetails getBookDetails = new GetBookDetails(_context, _mapper);
            getBookDetails.Id = id;
            var book = getBookDetails.Handle();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateBookModel createBookModel)
        {
            CreateBookCommand createBook = new CreateBookCommand(_context, _mapper);
            createBook.Model = createBookModel;
            CreateCommandValidator validations = new CreateCommandValidator();
            validations.ValidateAndThrow(createBook);
            createBook.Handle();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateBookViewModel updateBookViewModel)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
            updateBookCommand.Id = id;
            updateBookCommand.Model = updateBookViewModel;
            UpdateBookCommandValidator validations = new UpdateBookCommandValidator();
            validations.Validate(updateBookCommand);

            updateBookCommand.Handle();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            DeleteBookCommand deleteBookCommand = new DeleteBookCommand(_context);
            deleteBookCommand.Id = id;
            deleteBookCommand.Handle();
            return Ok();
        }
    }
}
