using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventario;
using Inventario.Controllers;

namespace Inventario.Tests.Controllers
{
    [TestClass]
    public class MODSAL_RestarPorVentaTest
    {
        [TestMethod]
        public void RetornoDeVista()
        {
            MODSAL_RestarPorVentaTest controller = new MODSAL_RestarPorVentaTest();
            ViewResult result = null;// = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RestarProductoCantidad0()
        {
            MODSAL_RestarPorVentaTest controller = new MODSAL_RestarPorVentaTest();
            ViewResult result = null;// = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RestarProductoSinNombreNiCantidad()
        {
            MODSAL_RestarPorVentaTest controller = new MODSAL_RestarPorVentaTest();
            ViewResult result = null;// = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RestarCantidadMayorAExistente()
        {
            MODSAL_RestarPorVentaTest controller = new MODSAL_RestarPorVentaTest();
            ViewResult result = null;// = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

    }
}
