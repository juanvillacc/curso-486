using Microsoft.Extensions.Logging;
using Nevus.Data.Repositories;
using Nevus.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nevus.Services
{
    public class CiudadService  : ICiudadService
    {
        private readonly ILogger<CiudadService> _logger;
        private readonly ICiudadRepository _ciudadRepository;  
        public CiudadService(ICiudadRepository ciudadRepository, ILogger<CiudadService> logger)
        {
            _ciudadRepository = ciudadRepository;   
            _logger = logger;
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
            try
            {
                if (ciudad.Nombre.Length<3)
                {
                    throw new ApplicationException("El nombre de la ciudad debe ser mayor de 3 digitos"); 
                }
                _ciudadRepository.Ingresar(ciudad);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public List<Ciudad> ObtenerTodas()
        {
            return _ciudadRepository.Obtener().ToList();
        }
    }
}
