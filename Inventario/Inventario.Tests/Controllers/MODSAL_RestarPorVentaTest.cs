using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventario;
using Inventario.Controllers;
using System.Data;

namespace Inventario.Tests.Controllers
{
    [TestClass]
    public class MODSAL_RestarPorVentaTest
    {
       [TestMethod]
        public void vMODSAL_RestarPorVenta_Test()
        {
            MODSAL_RestarPorVentaController controller = new MODSAL_RestarPorVentaController();
            ViewResult result = controller.vMODSAL_RestarPorVenta() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void consultarBD_TestRestarPorVenta()
        {
            var result = MODSAL_RestarPorVentaController.conectarBD("select * from movimiento;");
            // Assert
            Assert.IsNotNull(result);
        }


    }
}
