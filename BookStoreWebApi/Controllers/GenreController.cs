using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreWebApi.Application.GenreOperations.Command.Create;
using BookStoreWebApi.Application.GenreOperations.Command.Delete;
using BookStoreWebApi.Application.GenreOperations.Command.Update;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetails;
using BookStoreWebApi.Application.GenreOperations.Queries.GetGenres;
using BookStoreWebApi.DataAccess;
using Microsoft.AspNetCore.Mvc;
using static BookStoreWebApi.Application.GenreOperations.Command.Create.CreateGenreCommand;
using static BookStoreWebApi.Application.GenreOperations.Command.Update.UpdateGenreCommand;


namespace BookStoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetGenresQuery createGenreCommand = new GetGenresQuery(_context, _mapper);
            var genreList = createGenreCommand.Handle();
            return Ok(genreList);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            GetGenreDetails getGenreDetails = new GetGenreDetails(_context, _mapper);
            getGenreDetails.Id = id;
            return Ok(getGenreDetails.Handle());
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateGenreViewModel genre)
        {
            CreateGenreCommand createGenreCommand = new CreateGenreCommand(_context, _mapper);
            createGenreCommand.Model = genre;
            CreateGenreCommandValidator validations = new CreateGenreCommandValidator();
            validations.Validate(createGenreCommand);
            createGenreCommand.Handle();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] UpdateGenreViewModel genre)
        {
            UpdateGenreCommand updateGenreCommand = new UpdateGenreCommand(_context);
            updateGenreCommand.Id = id;
            updateGenreCommand.Model = genre;
            UpdateGenreCommandValidator validations = new UpdateGenreCommandValidator();
            validations.Validate(updateGenreCommand);
            updateGenreCommand.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            DeleteGenreCommand deleteGenreCommand = new DeleteGenreCommand(_context);
            deleteGenreCommand.Id = id;
            deleteGenreCommand.Handle();

            return Ok();
        }
    }
}
