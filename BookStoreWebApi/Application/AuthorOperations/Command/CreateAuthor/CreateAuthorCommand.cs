using System;
using System.Linq;
using AutoMapper;
using BookStoreWebApi.DataAccess;
using BookStoreWebApi.Entities;

namespace BookStoreWebApi.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly BookStoreDBContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorModel Model { get; set; }

        public CreateAuthorCommand(BookStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if (author != null)
            {
                throw new Exception("Böyle bir yazar mevcut.");
            }

            author = _mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
