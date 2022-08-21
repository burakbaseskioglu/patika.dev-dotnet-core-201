using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetGenresQuery(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetGenresViewModel> Handle()
        {
            var genres = _context.Genres.OrderBy(x => x.Id).ToList();

            var genreList = _mapper.Map<List<GetGenresViewModel>>(genres);
            return genreList;
        }

        public class GetGenresViewModel
        {
            public string Name { get; set; }
            public bool IsActive { get; set; }
        }
    }
}
