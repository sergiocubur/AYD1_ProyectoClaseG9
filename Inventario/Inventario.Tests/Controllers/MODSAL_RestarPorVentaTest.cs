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
            MODSAL_RestarPorVentaController controller = new MODSAL_RestarPorVentaController();
            ViewResult result = controller.vMODSAL_RestarPorVenta() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

    }
}
