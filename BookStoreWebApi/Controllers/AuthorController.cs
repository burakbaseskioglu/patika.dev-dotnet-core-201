using AutoMapper;
using BookStoreWebApi.Application.AuthorOperations.Command.CreateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Command.DeleteAuthor;
using BookStoreWebApi.Application.AuthorOperations.Command.UpdateAuthor;
using BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthors;
using BookStoreWebApi.DataAccess;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.AuthorOperations.Command.UpdateAuthor.UpdateAuthorCommand;

namespace BookStoreWebApi.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class AuthorController : Controller
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetAuthorsQueries getAuthorsQueries = new GetAuthorsQueries(_context, _mapper);
            var authorList = getAuthorsQueries.Handle();
            return Ok(authorList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            GetAuthorsDetailsQueries getAuthorsDetailsQueries = new GetAuthorsDetailsQueries(_context, _mapper);
            getAuthorsDetailsQueries.Id = id;
            var author = getAuthorsDetailsQueries.Handle();
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAuthorModel model)
        {
            CreateAuthorCommand createAuthorCommand = new CreateAuthorCommand(_context, _mapper);
            createAuthorCommand.Model = model;
            CreateAuthorCommandValidator validations = new CreateAuthorCommandValidator();
            validations.Validate(createAuthorCommand);
            createAuthorCommand.Handle();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] UpdateAuthorViewModel model)
        {
            UpdateAuthorCommand updateAuthorCommand = new UpdateAuthorCommand(_context);
            updateAuthorCommand.Id = id;
            updateAuthorCommand.Model = model;
            UpdateAuthorCommandValidator validations = new UpdateAuthorCommandValidator();
            validations.Validate(updateAuthorCommand);
            updateAuthorCommand.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            DeleteAuthorCommand deleteAuthorCommand = new DeleteAuthorCommand(_context);
            deleteAuthorCommand.Id = id;
            deleteAuthorCommand.Handle();
            return Ok();
        }
    }
}
