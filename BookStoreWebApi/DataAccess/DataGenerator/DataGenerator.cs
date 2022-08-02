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

                var bookList = new List<Book>
                {
                    new Book { Id = 1, Title = "Book 1", PageCount = 219, GenreId = 1, PublishDate = new DateTime(1980, 2, 14) },
                    new Book { Id = 2, Title = "Book 2", PageCount = 784, GenreId = 2, PublishDate = new DateTime(2001, 6, 26) },
                    new Book { Id = 3, Title = "Book 3", PageCount = 459, GenreId = 3, PublishDate = new DateTime(1994, 12, 30) },
                    new Book { Id = 4, Title = "Book 4", PageCount = 146, GenreId = 3, PublishDate = new DateTime(1999, 7, 22) }
                };

                context.Books.AddRange(bookList);
                context.SaveChanges();
            }
        }
    }
}
