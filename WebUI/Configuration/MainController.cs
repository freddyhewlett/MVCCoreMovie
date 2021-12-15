using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.WebApp.Configuration
{
    [Authorize]
    public abstract class MainController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly INotifyService _notification;

        protected MainController(IMapper mapper, INotifyService notification)
        {
            _mapper = mapper;
            _notification = notification;
        }

        protected bool ValidOperation()
        {
            if (_notification.HasError())
            {
                return false;
            }
            return true;
        }
    }
}