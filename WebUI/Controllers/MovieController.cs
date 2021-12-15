using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Filmes.WebApp.Configuration;
using Application.Interfaces;
using AutoMapper;
using WebUI.Models;
using System.IO;

namespace WebUI.Controllers
{
    public class MovieController : MainController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMapper mapper, IMovieService filmesServico, INotifyService notificacao)
                                : base(mapper, notificacao)
        {
            _movieService = filmesServico;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<MovieViewModel>>(await _movieService.MoviesAll()));
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieService.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<Movie>(movie));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            var result = new MovieViewModel();

            return View(await MappingListGenres(result));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(MovieViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(await MappingListGenres(viewModel));

            string path = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ImageUpload?.FileName);

            if (UploadFile(viewModel.ImageUpload, path).Result)
            {
                viewModel.ImagePath = path;
            }

            await _movieService.Insert(_mapper.Map<Movie>(viewModel));

            //Validar se a operação foi valida
            if (!ValidOperation())
            {
                return View(await MappingListGenres(viewModel));
            }

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public IActionResult Delete(Guid id)
        {
            var movie = _movieService.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [AllowAnonymous]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var movie = _movieService.FindById(id);
            await _movieService.Remove(_mapper.Map<Movie>(movie));

            return RedirectToAction(nameof(Index));
        }

        private async Task<MovieViewModel> MappingListGenres(MovieViewModel viewModel)
        {
            viewModel.Genres = _mapper.Map<IEnumerable<GenreViewModel>>(await _movieService.ListGenres());
            return viewModel;
        }

        private async Task<bool> UploadFile(IFormFile imageUpload, string imgPath)
        {
            if (imageUpload == null || imageUpload?.Length > 0)
            {
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPath);

            if (System.IO.File.Exists(path))
            {
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageUpload.CopyToAsync(stream);
            }
            return true;
        }
    }
    //public class MovieController : Controller
    //{
    //    private readonly MovieDbContext _context;

    //    public MovieController(MovieDbContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: Movie
    //    public async Task<IActionResult> Index(string searchString, int? SelectedGenre, string sortOrder)
    //    {
    //        var genres = _context.Genres.OrderBy(g => g.Name).ToList();
    //        ViewBag.SelectedGenre = new SelectList(genres, "GenreID", "Name", SelectedGenre);
    //        int genreID = SelectedGenre.GetValueOrDefault();

    //        var movies = _context.Movies
    //            .Where(c => !SelectedGenre.HasValue || c.GenreID == genreID);

    //        if (!String.IsNullOrEmpty(searchString))
    //        {
    //            movies = movies.Where(s => s.Title.Contains(searchString) || s.Director.Contains(searchString));
    //        }

    //        ViewBag.RatingSortParm = sortOrder == "Rating" ? "rating_asc" : "Rating";

    //        switch (sortOrder)
    //        {
    //            case "Rating":
    //                movies = movies.OrderByDescending(s => s.Rating);
    //                break;
    //            case "rating_asc":
    //                movies = movies.OrderBy(s => s.Rating);
    //                break;
    //        }

    //        //return View(movies);
    //        return View(await movies.ToListAsync());
    //    }

    //    // GET: Movie/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var movie = await _context.Movies
    //            .Include(m => m.Genre)
    //            .FirstOrDefaultAsync(m => m.ID == id);
    //        if (movie == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(movie);
    //    }

    //    // GET: Movie/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Name");
    //        return View();
    //    }

    //    // POST: Movie/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Create([Bind("ID,Title,Director,ReleaseDate,Gross,Rating,GenreID")] Movie movie)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Movies.Add(movie);
    //            _context.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        ViewBag.GenreID = new SelectList(_context.Genres, "GenreID", "Name", movie.GenreID);
    //        return View(movie);
    //    }

    //    // GET: Movie/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var movie = await _context.Movies.FindAsync(id);
    //        if (movie == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Name", movie.GenreID);
    //        return View(movie);
    //    }

    //    // POST: Movie/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Edit(int id, string title, string director, DateTime releasedate, decimal gross, double rating, string imageUrl, int genreID, IFormFile image)
    //    {
    //        var movie = _context.Movies.Find(id);
    //        if (ModelState.IsValid && movie != null)
    //        {
    //            movie.Title = title;
    //            movie.Director = director;
    //            movie.ReleaseDate = releasedate;
    //            movie.Gross = gross;
    //            movie.Rating = rating;
    //            movie.ImageUrl = imageUrl;
    //            movie.GenreID = genreID;

    //            if (image != null)
    //            {
    //                movie.ImageMimeType = image.ContentType;
    //                movie.ImageFile = new byte[image.Length];
    //                image.OpenReadStream().Read(movie.ImageFile, 0, (int)image.Length);
    //            }

    //            _context.Entry(movie).State = EntityState.Modified;
    //            _context.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "Name", movie.GenreID);
    //        return View(movie);
    //    }

    //    // GET: Movie/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var movie = await _context.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.ID == id);
    //        if (movie == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(movie);
    //    }

    //    public IActionResult GetImage(int id)
    //    {
    //        var movie = _context.Movies.Find(id);
    //        if (movie != null && movie.ImageFile != null)
    //        {
    //            return File(movie.ImageFile, movie.ImageMimeType);
    //        }
    //        else
    //        {
    //            return File("~/Images/nao-disponivel.jpg", "image/jpeg");
    //        }
    //    }

    //    // POST: Movie/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var movie = await _context.Movies.FindAsync(id);
    //        _context.Movies.Remove(movie);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    public IActionResult Browse(string genre = "Action")
    //    {
    //        var genreModel = _context.Genres.Include("Movies").Single(g => g.Name == genre);

    //        return View(genreModel);
    //    }

    //    [HttpGet]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> GenreMenu(int num = 5)
    //    {
    //        var genres = await _context.Genres.OrderByDescending(g => g.Movies.Count).Take(num).ToListAsync();

    //        return this.PartialView(genres);
    //    }

    //    private bool MovieExists(int id)
    //    {
    //        return _context.Movies.Any(e => e.ID == id);
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            _context.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }


    //}

    //[ViewComponent(Name = "GenreMenuViewComponent")]
    //public class GenreMenuViewComponent : ViewComponent
    //{
    //    private readonly MovieDbContext _context;

    //    public GenreMenuViewComponent(MovieDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
    //        var genres = await _context.Genres.OrderByDescending(g => g.Movies.Count).Take(5).ToListAsync();
    //        return this.View(genres);
    //    }
    //}
}
