using Nevus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nevus.Data.Repositories
{
    public interface ICiudadRepository
    {
        Ciudad ObtenerPorId(int IdCiudad);
        IEnumerable<Ciudad> Obtener();
        void Ingresar(Ciudad ciudad);

        void Actualizar(Ciudad ciudad);

        void Eliminar(Int64 idCiudad);
    }
}
