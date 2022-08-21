using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetails
{
    public class GetGenreDetails
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetGenreDetails(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetGenreDetailsViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == Id);

            if (genre == null)
            {
                throw new InvalidOperationException("Tür bulunamadı.");
            }
            var newGenre = _mapper.Map<GetGenreDetailsViewModel>(genre);
            return newGenre;
        }

        public class GetGenreDetailsViewModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
