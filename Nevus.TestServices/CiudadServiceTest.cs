using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nevus.Data;
using Nevus.Data.Repositories;
using Nevus.Models;
using Nevus.Services;
using System.Linq;

namespace Nevus.TestServices
{
    [TestClass]
    public class CiudadServiceTest
    {
        private CiudadService ObtenerServicio()
        {
            var mockILogger = new Mock<ILogger<CiudadService>>();
            string cc = "Server=tcp:servercurso486.database.windows.net,1433;Initial Catalog=datacurso486;Persist Security Info=False;User ID=admincrud;Password=Pa55w.rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ";
            var options =
                new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(cc).Options;
            AppDbContext appDbContext = new AppDbContext(options);
            CiudadRepository ciudadRepository = new CiudadRepository(appDbContext);
            CiudadService ciudadService = new CiudadService(ciudadRepository, mockILogger);

            return ciudadService;
        }

        [TestMethod]
        public void ObtenerTodas()
        {
            /// Arrange: se organiza la data para ejectutar la prueba
            var servicio = ObtenerServicio();
            /// Act: Se realiza la prueba
            var ciudades = servicio.ObtenerTodas();
            /// Assert: Evaluar si lo obtenido es igual a lo esperado
            Assert.IsNotNull(ciudades);
            Assert.IsTrue(ciudades.Count>0);
        }

        [TestMethod]
        public void Insertar()
        {
            /// Arrange: se organiza la data para ejectutar la prueba
            var servicio = ObtenerServicio();
            Ciudad ciudad = new Ciudad
            {
                Nombre = "test"                
            };
            /// Act: Se realiza la prueba
            servicio.Ingresar(ciudad);
            /// Assert: Evaluar si lo obtenido es igual a lo esperado
            var ciudadIngresada = servicio.ObtenerTodas().Where(c=>c.Nombre == "test").FirstOrDefault() ;
            Assert.IsNotNull(ciudadIngresada);

            // rollback manual
            servicio.Eliminar(ciudadIngresada.Id);

        }
    }
}
