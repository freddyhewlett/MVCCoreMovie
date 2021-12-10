using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet("erro/{id:length(3,3)}")]
        [AllowAnonymous]
        public IActionResult Error(int id)
        {
            var error = new Error();
            
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
