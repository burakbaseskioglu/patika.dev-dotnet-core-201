using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQueries
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetAuthorsQueries(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAuthorsViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.Id).ToList();
            var authorList = _mapper.Map<List<GetAuthorsViewModel>>(authors);
            return authorList;
        }

        public class GetAuthorsViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
