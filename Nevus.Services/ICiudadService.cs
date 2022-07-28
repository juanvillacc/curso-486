using Nevus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nevus.Services
{
    public interface ICiudadService
    {
        List<Ciudad> ObtenerTodas();
        void Ingresar(Ciudad ciudad);
        void Actualizar(Ciudad ciudad);
        void Eliminar(Int64 id);
    }
}
