using Nevus.Models;
using System.Collections.Generic;

namespace Nevus.Services
{
    public class CiudadService  : ICiudadService
    {
        public List<Ciudad> ObtenerTodas()
        {
            var resultados = new List<Ciudad>
            {
                new Ciudad
                {
                    Id = 1,
                    Nombre = "Ciudad1"
                },

                new Ciudad
                {
                    Id = 2,
                    Nombre = "Ciudad2"
                },
            };

            return resultados;
        }
    }
}
