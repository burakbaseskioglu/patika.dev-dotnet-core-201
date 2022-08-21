using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreWebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStoreWebApi.DataAccess.DataGenerator
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                var authorList = new List<Author>
                {
                    new Author { FirstName = "Author 1", LastName = "Lastname" },
                    new Author { FirstName = "Author 2", LastName = "Lastname" },
                    new Author { FirstName = "Author 3", LastName = "Lastname" }
                };

                context.Authors.AddRange(authorList);

                var bookList = new List<Book>
                {
                    new Book { Title = "Book 1", PageCount = 219, GenreId = 1, PublishDate = new DateTime(1980, 2, 14), AuthorId = 1 },
                    new Book { Title = "Book 2", PageCount = 784, GenreId = 2, PublishDate = new DateTime(2001, 6, 26), AuthorId = 1 },
                    new Book { Title = "Book 3", PageCount = 459, GenreId = 3, PublishDate = new DateTime(1994, 12, 30), AuthorId = 2 },
                    new Book { Title = "Book 4", PageCount = 146, GenreId = 3, PublishDate = new DateTime(1999, 7, 22), AuthorId = 3 }
                };

                var genreList = new List<Genre>
                {
                    new Genre{ Name = "Personal", IsActive = true },
                    new Genre{ Name = "Novel", IsActive = true },
                    new Genre{ Name = "Story", IsActive = true },
                    new Genre{ Name = "Literature", IsActive = false },
                };

                context.Genres.AddRange(genreList);
                context.Books.AddRange(bookList);
                context.SaveChanges();
            }
        }
    }
}
