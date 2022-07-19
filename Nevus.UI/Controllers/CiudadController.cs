using Microsoft.AspNetCore.Mvc;
using Nevus.Models;

namespace Nevus.UI.Controllers
{
    public class CiudadController : Controller
    {
        /// <summary>
        /// Muestra el listado de ciudades
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Muestra la informacion que se va a editar
        /// </summary>
        /// <param name="IdCiudad"></param>
        /// <returns></returns>
        public IActionResult Editar(int IdCiudad)
        {
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
