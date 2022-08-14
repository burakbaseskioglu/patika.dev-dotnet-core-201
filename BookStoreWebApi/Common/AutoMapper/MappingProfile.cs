using System;
using AutoMapper;
using BookStoreWebApi.Application.BookOperations.Command.Create;
using BookStoreWebApi.Entities;
using static BookStoreWebApi.Application.BookOperations.Queries.GetBookDetails.GetBookDetails;
using static BookStoreWebApi.Application.BookOperations.Queries.GetBooks.GetAllBooks;

namespace BookStoreWebApi.Common.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailsViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, GetBooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        }
    }
}
