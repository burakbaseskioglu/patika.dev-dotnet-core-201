using System;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DataAccess;

namespace BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthorDetails
{
    public class GetAuthorsDetailsQueries
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetAuthorsDetailsQueries(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorDetailsViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id);
            if (author == null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }

            return _mapper.Map<GetAuthorDetailsViewModel>(author);
        }

        public class GetAuthorDetailsViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
