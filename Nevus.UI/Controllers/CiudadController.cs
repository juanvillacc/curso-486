using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nevus.Models;
using Nevus.Services;
using System.Linq;

namespace Nevus.UI.Controllers
{
    //[Authorize]
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
        [HttpGet]
        public IActionResult Index()
        {
            return View(_ciudadService.ObtenerTodas());
        }
        /// <summary>
        /// Muestra la informacion que se va a editar
        /// </summary>
        /// <param name="IdCiudad"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Editar")]
        public IActionResult Editar(int IdCiudad)
        {

            _logger.Log(LogLevel.Information,

                $"Se inicio el llamado a la action ${RouteData.Values[""]} del controlador ${RouteData.Values[""]} ");

            /*if ((int)RouteData.Values["IdCiudad"] == 0)
            {
                return Content("Parametro no valido");

            }*/
            var ciudad = _ciudadService.ObtenerTodas()
                .Where(c => c.Id == IdCiudad).FirstOrDefault();
            return View(ciudad ?? new Ciudad());
        }
        /// <summary>
        /// Actualizacion de la base de datos dependiendo del el id de la ciudad
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Guardar(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {

                /*try
                {*/
                    if (ciudad.Id < 0)
                    {
                        ModelState.AddModelError("Id", "El codigo no puede ser negativo");
                        return View("Editar", ciudad);
                    }
                    else
                    {

                        if (ciudad.Id > 0)
                        {
                            _ciudadService.Actualizar(ciudad);
                        }
                        else
                        {
                            _ciudadService.Ingresar(ciudad);
                        }

                        return RedirectToAction("Index");
                    }
                /*}
                catch (System.Exception ex)
                {

                    ModelState.AddModelError("Nombre", ex.Message);
                    return View("Editar", ciudad);
                }*/
            }
            else
            {
                return View("Editar", ciudad);

            }

        }
        /// <summary>
        /// Eliminar el registro en la base de datos
        /// </summary>
        /// <param name="IdCiudad"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Eliminar(int IdCiudad)
        {
            // logica para borrar
            _ciudadService.Eliminar(IdCiudad);
            return RedirectToAction("Index");
        }
    }
}
