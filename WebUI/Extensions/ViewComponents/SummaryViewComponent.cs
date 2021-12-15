using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Extensions.ViewComponents
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotifyService _notifiyService;

        public SummaryViewComponent(INotifyService notifyServico)
        {
            _notifiyService = notifyServico;
        }

        public IViewComponentResult Invoke()
        {
            var notifications = _notifiyService.AllErrors().Select(x => x.Error).ToList();

            notifications.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x + " <br />"));

            return View(notifications);
        }
    }
}
