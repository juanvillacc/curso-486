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
        private readonly IDepartamentoService _departamentoService;
        public HomeController(ILogger<HomeController> logger,
            ICiudadService ciudadService,
            IDepartamentoService departamentoService
            )
        {
            _logger = logger;
            _ciudadService = ciudadService;
            _departamentoService = departamentoService; 
        }

        public IActionResult Index( )
        {
            _logger.Log(LogLevel.Critical, "Ejemplo de logeer");
            var ciudades = _ciudadService.ObtenerTodas();
            var departamentos = _departamentoService.ObtenerTodas();    
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
