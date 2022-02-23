using BootCampMovieApp.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootCampMovieApp.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public GenresViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(_context.genre.ToList());
        }
    }
}
