using Microsoft.Extensions.Caching.Memory;
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
        //private readonly IMemoryCache _cache;

        public CiudadService(
            ICiudadRepository ciudadRepository,
            ILogger<CiudadService> logger
            //,IMemoryCache cache
            )
        {
            _ciudadRepository = ciudadRepository;   
            _logger = logger;
            //_cache = cache;
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
            List<Ciudad> ciudades;
            /*if (!_cache.TryGetValue("Cache_Listado_ciudades",out ciudades))
            {
                ciudades =  _ciudadRepository.Obtener().ToList();
                var opciones = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(100));
                _cache.Set("Cache_Listado_ciudades", ciudades, opciones);
                
            }*/
            ciudades = _ciudadRepository.Obtener().ToList();
      
            return ciudades;
        }
    }
}
