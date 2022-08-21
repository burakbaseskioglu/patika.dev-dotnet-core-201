using System;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DataAccess;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.GenreOperations.Command.Create
{
    public class CreateGenreCommand
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public CreateGenreViewModel Model { get; set; }

        public CreateGenreCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);

            if (genre != null)
            {
                throw new InvalidOperationException("Böyle bir kitap türü bulunmaktadır.");
            }

            genre = _mapper.Map<Genre>(Model);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public class CreateGenreViewModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
