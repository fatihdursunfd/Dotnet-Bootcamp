using BootcampBookApp.Entities;
using BootcampBookApp.Models;
using BootcampBookApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampBookApp.Controllers
{
    public class BookController : Controller
    {
        
        
        private readonly BootcampBookDbContext _context;
        public BookController(BootcampBookDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            var book = _context.Books.ToList();
            var genres = _context.Genres.ToList();

            //var ab = _context.AuthorBooks.ToList();
            //var bg = _context.BookGenres.ToList();

            model.books = book;
            model.genres = genres;

            return View(model);
            
        }

        [Route("Index/{id:int}")]
        public IActionResult Index(int id)
        {
            HomeViewModel model = new HomeViewModel();

            var genre = _context.Genres.Find(id);
            var bg = _context.BookGenres.Where(i => i.GenresGenreId == id);

            List<int> bookIds = new List<int>();

            foreach (var item in bg)
            {
                bookIds.Add(item.BooksBookId);
            }

            List<Book> books = new List<Book>();
            foreach (var item in bookIds)
            {
                var book = _context.Books.Find(item);
                if(book != null)
                {
                    books.Add(book);
                }
            }

            model.books = books;
            model.genres = _context.Genres.ToList();
            

            return View(model);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult List()
        {
            var books = _context.Books.ToList();

            var model = new BookViewModel() { Books = books };

            return View(model);
        }

        [HttpGet]
        public IActionResult List(string bookName)
        {
            var books = _context.Books.AsQueryable();


            if (!string.IsNullOrEmpty(bookName))
            {
                books = books.Where(i => i.Title.ToLower().Contains(bookName.ToLower()));
            }

            var model = new BookViewModel()
            {
                Books = books.ToList()
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            ListViewModel model = new ListViewModel();
            
            var book = _context.Books.Find(id);
            var authors = _context.Authors.ToList();
            var genres = _context.Genres.ToList();

            var ab = _context.AuthorBooks.Where(i => i.BookId == id).FirstOrDefault();
            var bg = _context.BookGenres.Where(i => i.BooksBookId == id).FirstOrDefault();

            if(ab != null)
                model.authors = ab.Author;
            if(bg != null)
                model.genres = bg.GenresGenre;

            model.book = book;
            
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {

            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction("List");

        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateViewModel model = new CreateViewModel();
            var genres = _context.Genres.ToList();

            // convert list to selectlist
            var item = genres.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.GenreTitle ,
                    Value = a.GenreTitle,
                    Selected = false
                };
            });
            model.genres = item;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            var author = _context.Authors.Where(i => i.FullName == model.author.FullName);

            if(author.Count() == 0)
            {
                _context.Authors.Add(model.author);
            }

            /*
            BookGenre bg1 = new BookGenre()
            {
                BooksBook = model.book,
                GenresGenre = model.genre1,
            };
            
            
            BookGenre bg2 = new BookGenre()
            {
                BooksBook = model.book,
                GenresGenre = model.genre2,
            };
            

            AuthorBook ab = new AuthorBook()
            {
                Book = model.book,
                Author = model.author
            };

            */


            _context.Books.Add(model.book);
            //_context.AuthorBooks.Add(ab);
            //_context.BookGenres.Add(bg1);
            //_context.BookGenres.Add(bg2);

            _context.SaveChanges();
            TempData["message"] = $"{model.book.Title} isimli film eklendi";
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id )
        {
            
            var entity = _context.Books.Find(id);
            _context.Books.Remove(entity);
            _context.SaveChanges();
            TempData["message"] = $"{entity.Title} isimli film silindi ";
            
            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }

}
