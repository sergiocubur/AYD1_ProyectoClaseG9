using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inventario;
using Inventario.Controllers;
using System.Data;
using Inventario.Objetos;

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
            var result = MODSAL_RestarPorVentaController.consultarBD("select * from movimiento;");
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void mostrandoVentas_TestRestarPorVenta()
        {
            MODSAL_RestarPorVentaController controller = new MODSAL_RestarPorVentaController();
            RedirectToRouteResult result = controller.mostrandoVentas() as RedirectToRouteResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void getProductos_TestRestarPorVenta()
        {
            MODSAL_RestarPorVentaController controller = new MODSAL_RestarPorVentaController();
            List<ObjProducto> result = controller.getProductos() as List<ObjProducto>;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void mostrandoProductos_TestRestarPorVenta()
        {
            MODSAL_RestarPorVentaController controller = new MODSAL_RestarPorVentaController();
            RedirectToRouteResult result = controller.mostrandoProductos() as RedirectToRouteResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void vMODSAL_VerProductos_Test()
        {
            MODSAL_RestarPorVentaController controller = new MODSAL_RestarPorVentaController();
            ViewResult result = controller.vMODSAL_VerProductos() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void actualizarBD_TestRestarPorVenta()
        {
            var result = MODSAL_RestarPorVentaController.actualizarBD(1, 35);
            // Assert
            Assert.IsNotNull(result);
        }


    }
}
