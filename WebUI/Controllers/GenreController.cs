using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;


namespace MvcMovie.Controllers
{
    public class GenreController : Controller
    {
        private readonly MovieDbContext _context;

        public GenreController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: Genre
        public ActionResult Index()
        {
            var genres = _context.Genres.OrderBy(g => g.Name);
            return View(genres.ToList());
        }

        public ActionResult About()
        {
            var data = from movie in _context.Movies
                       group movie by movie.Genre into dateGroup
                       select new GenreDataInfo()
                       {
                           GenreName = dateGroup.Key.Name,
                           GenreCount = dateGroup.Count(),
                           TotalGross = dateGroup.Sum(m => m.Gross),
                           AverageRating = dateGroup.Average(m => m.Rating)
                       };
            return View(data.OrderByDescending(g => g.GenreCount).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}