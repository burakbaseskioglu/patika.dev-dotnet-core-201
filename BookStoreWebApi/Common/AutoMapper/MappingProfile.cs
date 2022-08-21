using System;
using AutoMapper;
using BookStoreWebApi.Application.AuthorOperations.Command.CreateAuthor;
using BookStoreWebApi.Application.BookOperations.Command.Create;
using BookStoreWebApi.Entities;
using static BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthorDetails.GetAuthorsDetailsQueries;
using static BookStoreWebApi.Application.AuthorOperations.Queries.GetAuthors.GetAuthorsQueries;
using static BookStoreWebApi.Application.BookOperations.Queries.GetBookDetails.GetBookDetails;
using static BookStoreWebApi.Application.BookOperations.Queries.GetBooks.GetAllBooks;
using static BookStoreWebApi.Application.GenreOperations.Command.Create.CreateGenreCommand;
using static BookStoreWebApi.Application.GenreOperations.Queries.GetGenreDetails.GetGenreDetails;
using static BookStoreWebApi.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;

namespace BookStoreWebApi.Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailsViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}")); ;
            CreateMap<Book, GetBooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));
            CreateMap<CreateGenreViewModel, Genre>();
            CreateMap<Genre, GetGenresViewModel>();
            CreateMap<Genre, GetGenreDetailsViewModel>();
            CreateMap<CreateAuthorModel, Author>();
            CreateMap<Author, GetAuthorsViewModel>();
            CreateMap<Author, GetAuthorDetailsViewModel>();
        }
    }
}
