using BootCampMovieApp.Context;
using BootCampMovieApp.Entity;
using BootCampMovieApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCampMovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List(int? id , string? q)
        {
            var movies = _context.movie.AsQueryable();
            if(id != null)
            {
                movies = movies.Include(i => i.Genres).Where(i => i.Genres.Any(g => g.GenreId == id));
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i => i.Title.ToLower().Contains(q.ToLower()) || i.Description.ToLower().Contains(q.ToLower()));
            }
            var model = new MovieViewModel
            {
                Movies = movies.ToList()
            };

            return View("Movies",model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var movies = _context.movie.Find(id);
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            return View(_context.movie.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {

            _context.movie.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("List", "Movies" , new {@id = movie.MovieId } );
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _context.movie.Add(movie);
            _context.SaveChanges();
            TempData["message"] = $"{movie.Title} isimli film eklendi";
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Delete(int MovieId, string Title)
        {
            var entity = _context.movie.Find(MovieId);
            _context.movie.Remove(entity);
            _context.SaveChanges();
            TempData["message"] = $"{Title} isimli film silindi ";
            return RedirectToAction("List");
        }
    }
}
