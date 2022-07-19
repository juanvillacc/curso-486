using Nevus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nevus.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        public void Actualizar(Departamento ciudad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public int Ingresar(Departamento ciudad)
        {
            throw new NotImplementedException();
        }

        public List<Departamento> ObtenerTodas()
        {
            var resultado = new List<Departamento>{
                new Departamento
                {
                     Id = 1,
                     Nombre= "Antioquia"
                },

                new Departamento
                {
                     Id = 2,
                     Nombre= "Cesar"
                },
            };
            return resultado;
        }
    }
}
