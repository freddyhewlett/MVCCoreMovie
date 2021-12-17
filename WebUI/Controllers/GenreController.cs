using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Filmes.WebApp.Configuration;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebUI.Models;

namespace MvcMovie.Controllers
{
    public class GenreController : MainController
    {
        private readonly ILogger<GenreController> _logger;
        private readonly IGenreService _genreService;

        public GenreController(IGenreService service, IMapper mapper, ILogger<GenreController> logger, INotifyService notificacao) : base(mapper, notificacao)
        {
            _logger = logger;
            _genreService = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<GenreViewModel>>(await _genreService.GenresAll()));            
        }

        public IActionResult About()
        {
            
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Browse(Guid id)
        {
            var genreModel = await _genreService.FindById(id);
            string genreName = genreModel.Name;
            string genreDescription = genreModel.Description;
            var movieList = await _genreService.ListGenreMovie(genreName);
            var viewModel = _mapper.Map<IEnumerable<MovieViewModel>>(movieList);

            var result = new GenreViewModel(genreName, genreDescription, viewModel);

            return View(result);
        }
    }
}