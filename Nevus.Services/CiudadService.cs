using Nevus.Data.Repositories;
using Nevus.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nevus.Services
{
    public class CiudadService  : ICiudadService
    {
        private readonly ICiudadRepository _ciudadRepository;  
        public CiudadService(ICiudadRepository ciudadRepository)
        {
            _ciudadRepository = ciudadRepository;   
        }

        public void Actualizar(Ciudad ciudad)
        {
            _ciudadRepository.Actualizar(ciudad);
        }

        public void Eliminar(Int64 id)
        {
            _ciudadRepository.Eliminar(id);
        }

        public void Ingresar(Ciudad ciudad)
        {
            _ciudadRepository.Ingresar(ciudad);
        }

        public List<Ciudad> ObtenerTodas()
        {
            return _ciudadRepository.Obtener().ToList();
        }
    }
}
