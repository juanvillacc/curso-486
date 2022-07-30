using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nevus.Models;
using Nevus.Services;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nevus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadService _ciudadService;
        private readonly ILogger<CiudadController> _logger;

        public CiudadController(ICiudadService ciudadService,
            ILogger<CiudadController> logger)
        {
            _ciudadService = ciudadService;
            _logger = logger;
        }

        // GET: api/<CiudadController>
        [HttpGet]
        public IEnumerable<Ciudad> Get()
        {
            return _ciudadService.ObtenerTodas() as IEnumerable<Ciudad>;
        }

        // GET api/<CiudadController>/5
        [HttpGet("{id}")]
        public Ciudad Get(int id)
        {
            var ciudad = _ciudadService.ObtenerTodas()
                .Where(c => c.Id == id).FirstOrDefault();

            return ciudad;
        }

        // POST api/<CiudadController>
        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                if (ciudad.Id > 0)
                {
                    _ciudadService.Actualizar(ciudad);
                }
                else
                {
                    _ciudadService.Ingresar(ciudad);
                }
                return Ok();
            } else {

                return BadRequest();
            }
        }

        // PUT api/<CiudadController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Ciudad ciudad)
        {
            _ciudadService.Actualizar(ciudad);
            return Ok();    
        }

        // DELETE api/<CiudadController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _ciudadService.Eliminar(id);
            return Ok();
        }
    }
}
