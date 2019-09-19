using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Inventario;
using Inventario.Controllers;

namespace Inventario.Tests.Controllers
{
    
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void RestaxVentas()
        {
            // Arrange
            MODSAL_RestaxVentaController controller = new MODSAL_RestaxVentaController();

            int respuesta=controller.restar1(100, 50);            

            // Assert
            Assert.IsNotNull(respuesta);
            Assert.AreNotEqual(100, respuesta);
            //Assert.AreEqual(100,respuesta);
        }

        [Test]
        public void VerificarImputs_CrearUsuario()
        {
            MODUSRController controller = new MODUSRController();
            string dpi = "algo";
            string apellido = "algo";
            string codUsuario = "algo";
            string password = "algo";
            int respuesta = controller.comprobarForm(dpi,apellido,codUsuario,password);

            Assert.IsNotNull(respuesta);
            Assert.AreNotEqual(0, respuesta);
        }
        [Test]
        public void largoPassword_CrearUsuario()
        {
            MODUSRController controller = new MODUSRController();
            
            string password = "123456";
            int respuesta = controller.largoPassword(password);

            Assert.IsNotNull(respuesta);
            Assert.AreNotEqual(0, respuesta);
        }
        [Test]
        public void numeroPassword_CrearUsuario()
        {
            MODUSRController controller = new MODUSRController();
            
            string password = "1numero";
            int respuesta = controller.numeroPassword(password);

            Assert.IsNotNull(respuesta);
            Assert.AreNotEqual(0, respuesta);
        }
        [Test]
        public void simboloPassword_CrearUsuario()
        {
            MODUSRController controller = new MODUSRController();
            string password = "!simbolo";
            int respuesta = controller.simboloPassword(password);

            Assert.IsNotNull(respuesta);
            Assert.AreNotEqual(0, respuesta);
        }
        [Test]
        public void mayuscula_CrearUsuario()
        {
            MODUSRController controller = new MODUSRController();
            
            string password = "Mayuscula";
            int respuesta = controller.mayusculaPassword(password);

            Assert.IsNotNull(respuesta);
            Assert.AreNotEqual(0, respuesta);
        }
        [Test]
        public void largoCodUsuario_CrearUsuario()
        {
            MODUSRController controller = new MODUSRController();
            
            string codUsuario = "1234";
            int respuesta = controller.largoCodUsuario(codUsuario);

            Assert.IsNotNull(respuesta);
            Assert.AreNotEqual(0, respuesta);
        }
        [Test]
        public void largoDpi_CrearUsuario()
        {
            MODUSRController controller = new MODUSRController();
            string dpi = "1234567890123";
            int respuesta = controller.largoDpi(dpi);

            Assert.IsNotNull(respuesta);
            Assert.AreNotEqual(0, respuesta);
        }
    }
}
