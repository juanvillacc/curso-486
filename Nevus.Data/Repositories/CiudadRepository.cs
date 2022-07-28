using Nevus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nevus.Data.Repositories
{
    public class CiudadRepository : ICiudadRepository
    {
        protected readonly AppDbContext _contexto;
        public CiudadRepository(AppDbContext contexto) 
        {
            _contexto = contexto;   
        }
        public void Actualizar(Ciudad ciudad)
        {
            _contexto.Ciudad.Update(ciudad);
            _contexto.SaveChanges();
        }

        public void Eliminar(Int64 idCiudad)
        {
            var ciudad = _contexto.Ciudad.Find(idCiudad);
            _contexto.Ciudad.Remove(ciudad);
            _contexto.SaveChanges();
        }

        
        public void Ingresar(Ciudad ciudad)
        {
            _contexto.Ciudad.Add(ciudad);
            _contexto.SaveChanges();
        }

        public IEnumerable<Ciudad> Obtener()
        {
            return _contexto.Ciudad;
        }
        public Ciudad ObtenerPorId(int IdCiudad)
        {
            return _contexto.Ciudad.Find(IdCiudad);
        }
    }
}
