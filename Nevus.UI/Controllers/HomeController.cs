using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nevus.Services;
using Nevus.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nevus.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICiudadService _ciudadService;
        public HomeController(ILogger<HomeController> logger,
            ICiudadService ciudadService
            )
        {
            _logger = logger;
            _ciudadService = ciudadService;
        }

        public IActionResult Index( )
        {

            var ciudades = _ciudadService.ObtenerTodas();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
