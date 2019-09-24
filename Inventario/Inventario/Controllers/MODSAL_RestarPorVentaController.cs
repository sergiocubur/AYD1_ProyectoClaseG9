using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class MODSAL_RestarPorVentaController : Controller
    {
        // GET: MODSAL_RestarPorVenta
        public ActionResult vMODSAL_RestarPorVenta()
        {
            return View();
        }

        public bool conectarBD(string Consulta)
        {
            throw new NotImplementedException();
        }
    }
}