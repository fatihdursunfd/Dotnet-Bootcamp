//using BootcampBookApp.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampBookApp
{
    public static class DummyData
    {
        
        public static void Dummy(IApplicationBuilder app)
        {
            /*
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<BootcampBookDbContext>();
            context.Database.Migrate();

            List<Genre> Genres =  new List<Genre>()
            {
                new Genre() { GenreTitle = "Macera" },
                new Genre() { GenreTitle = "Dram" },
                new Genre() { GenreTitle = "Distopik" },
                new Genre() { GenreTitle = "Bilim Kurgu" },
            };

            List<Author> Authors = new List<Author>()
            {
                new Author(){FullName = "Jose Saramago"},
                new Author(){FullName = "Victor Hugo"},
                new Author(){FullName = "J. K. Rowling"},
            };

            List<Book> Books = new List<Book>()
            {
                new Book
                {
                    Title = "Körlük",
                    PageCount = 336 ,
                    PublishedDate = new DateTime(1995,1,1),
                    Price = 30 ,
                    ImageUrl = "korluk.jpg",
                },
                new Book
                {
                    Title = "Bir İdam Mahkumunun Son Günü",
                    PageCount = 280 ,
                    PublishedDate = new DateTime(1826,1,1),
                    Price = 10 ,
                    ImageUrl = "idam.jpg",
                },
                new Book
                {
                    Title = "Harry Potter Felsefe Taşı",
                    PageCount = 280 ,
                    PublishedDate = new DateTime(2007,1,1),
                    Price = 35 ,
                    ImageUrl = "felsefetasi.jpg",
                }
            };

            List<BookGenre> bookGenres = new List<BookGenre>()
            {
                new BookGenre(){BooksBook = Books[0] , GenresGenre = Genres[1]},
                new BookGenre(){BooksBook = Books[0] , GenresGenre = Genres[2]},
                new BookGenre(){BooksBook = Books[1] , GenresGenre = Genres[1]},
                new BookGenre(){BooksBook = Books[2] , GenresGenre = Genres[0]},
                new BookGenre(){BooksBook = Books[2] , GenresGenre = Genres[3]}
            };

            List<AuthorBook> authorBooks = new List<AuthorBook>()
            {
                new AuthorBook(){Book = Books[0] , Author = Authors[0]},
                new AuthorBook(){Book = Books[1] , Author = Authors[1]},
                new AuthorBook(){Book = Books[2] , Author = Authors[2]}
            };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Books.Count() == 0)
                {
                    context.Books.AddRange(Books);
                }
                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(Genres);
                }
                if (context.Authors.Count() == 0)
                {
                    context.Authors.AddRange(Authors);
                }
                if (context.AuthorBooks.Count() == 0)
                {
                    context.AuthorBooks.AddRange(authorBooks);
                }
                if (context.BookGenres.Count() == 0)
                {
                    context.BookGenres.AddRange(bookGenres);
                }

                context.SaveChanges();
            }
             */
        }



    }
}
