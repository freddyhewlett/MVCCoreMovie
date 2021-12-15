using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Filmes.WebApp.Configuration;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MvcMovie.Controllers
{
    public class GenreController : MainController
    {
        private readonly ILogger<GenreController> _logger;
        private readonly IMovieRepository _movieRepository;

        public GenreController(IMapper mapper, ILogger<GenreController> logger, INotifyService notificacao, IMovieRepository movieRep) : base(mapper, notificacao)
        {
            _logger = logger;
            _movieRepository = movieRep;
        }

        // GET: Genre
        public IActionResult Index()
        {
            var genres = _movieRepository.ListGenres();
            return View(genres);
        }

        public IActionResult About()
        {
            
            return View();
        }

        
    }
}