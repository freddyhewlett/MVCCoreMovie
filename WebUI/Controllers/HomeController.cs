using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Filmes.WebApp.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : MainController
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(IMapper mapper, ILogger<HomeController> logger, INotifyService notification)
                                : base(mapper, notification)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("erro/{id:length(3,3)}")]
        [AllowAnonymous]
        public IActionResult Error(int id)
        {
            var error = new ErrorViewModel();
            
            if (id == 404)
            {
                error.Message = "Página não existe!";
                error.Title = "Página não encontrada";
                error.StatusCode = id;
            }
            else if (id == 500) 
            {
                error.Message = "Tente novamente mais tarde...";
                error.Title = "Ocorreu um erro.";
                error.StatusCode = id;
            } 
            else if (id == 403)
            {
                error.Message = "Você não tem permissão.";
                error.Title = "Acesso negado.";
                error.StatusCode = id;
            }
            return View("Error", error);
        }
    }
}
