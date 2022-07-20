using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nevus.Models;
using Nevus.Services;
using System.Linq;

namespace Nevus.UI.Controllers
{
    //[Route("Ciudades")]
    public class CiudadController : Controller
    {
        private readonly ICiudadService _ciudadService;
        private readonly ILogger<CiudadController> _logger;
        public CiudadController(ICiudadService ciudadService,
            ILogger<CiudadController> logger)
        {
            _ciudadService = ciudadService;
            _logger = logger;   
        }

        /// <summary>
        /// Muestra el listado de ciudades
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_ciudadService.ObtenerTodas().FirstOrDefault().Nombre);
        }
        /// <summary>
        /// Muestra la informacion que se va a editar
        /// </summary>
        /// <param name="IdCiudad"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Modificar")]
        public IActionResult Editar(int IdCiudad)
        {

            _logger.Log(LogLevel.Information,
                
                $"Se inicio el llamado a la action ${RouteData.Values[""]} del controlador ${RouteData.Values[""]} ");

            if ((int)RouteData.Values["IdCiudad"] == 0)
            {
                return Content("Parametro no valido");

            }
            var ciudad = new Ciudad();

            return View(ciudad);
        }
        /// <summary>
        /// Actualizacion de la base de datos 
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns></returns>
        public IActionResult Editar(Ciudad ciudad)
        {

            return View();
        }
        /// <summary>
        /// Eliminar el registro en la base de datos
        /// </summary>
        /// <param name="IdCiudad"></param>
        /// <returns></returns>
        public IActionResult Eliminar(int IdCiudad)
        {
            return View();
        }
        /// <summary>
        /// Inserta un registro en la base de datos
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns></returns>
        public IActionResult Insertar(Ciudad ciudad)
        {

            return View();
        }
    }
}
