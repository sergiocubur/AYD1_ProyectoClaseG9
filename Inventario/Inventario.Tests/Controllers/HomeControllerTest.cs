using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Inventario;
using Inventario.Controllers;

namespace practica2_grupo7.Tests.Controllers
{
    
    public class HomeControllerTest
    {
        
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

        [Test]
        public void los_input_devolucion_no_pueden_ser_vacios()
        {
            MODINGController controller = new MODINGController();
            Assert.IsNull(controller.insertarDevolucion(String.Empty, String.Empty));
            //Assert.AreNotEqual(0, respuesta);
        }


    }
}
