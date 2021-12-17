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
using System.Diagnostics;
using System.Collections;

namespace WebUI.Controllers
{
    public class MovieController : MainController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMapper mapper, IMovieService movieServico, INotifyService notification)
                                : base(mapper, notification)
        {
            _movieService = movieServico;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString, Guid? SelectedGenre, string sortOrder)
        {
            var genres = _movieService.ListGenres();
            ViewBag.SelectedGenre = new SelectList(await genres, "GenreID", "Name", SelectedGenre);
            Guid genreID = SelectedGenre.GetValueOrDefault();
            var movies = _mapper.Map<IEnumerable<MovieViewModel>>(await _movieService.MoviesAll());

            if (!String.IsNullOrEmpty(searchString))
            {
                //movies = movies.Where(s => s.Title.Contains(searchString) || s.Director.Contains(searchString));
            }

            ViewBag.RatingSortParm = sortOrder == "Rating" ? "rating_asc" : "Rating";

            switch (sortOrder)
            {
                case "Rating":
                    movies = movies.OrderByDescending(s => s.Rating);
                    break;
                case "rating_asc":
                    movies = movies.OrderBy(s => s.Rating);
                    break;
            }

            return View(movies);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieService.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<MovieViewModel>(movie));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(Guid id)
        {
            var movie = await _movieService.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }
            MovieViewModel viewModel = new MovieViewModel { };

            await MappingListGenres(viewModel);
            ViewBag.GenreID = new SelectList(viewModel.Genres, "GenreID", "Name", movie.GenreID);
            return View(_mapper.Map<MovieViewModel>(movie));
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditConfirmed(MovieViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(await MappingListGenres(viewModel));

            string path = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.ImageUpload?.FileName);

            if (UploadFile(viewModel.ImageUpload, path).Result)
            {
                viewModel.ImagePath = path;
            }

            await _movieService.Update(_mapper.Map<Movie>(viewModel));

            if (!ValidOperation())
            {
                return View(await MappingListGenres(viewModel));
            }

            if (_notification.HasError()) return RedirectToAction(nameof(Error));

            return RedirectToAction(nameof(Index));
            
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
        [AutoValidateAntiforgeryToken]
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = await _movieService.FindById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<MovieViewModel>(movie));
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _movieService.Remove(id);

            if (_notification.HasError()) return RedirectToAction(nameof(Error));

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

        

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }   
}
