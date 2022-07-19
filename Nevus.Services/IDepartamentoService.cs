using Nevus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nevus.Services
{
    public interface IDepartamentoService
    {
        List<Departamento> ObtenerTodas();
        int Ingresar(Departamento ciudad);
        void Actualizar(Departamento ciudad);
        void Eliminar(int id);
    }
}
