using System;
using System.Collections.Generic;
using System.Data;
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

        public static DataTable conectarBD(string Consulta)
        {
            throw new NotImplementedException();
        }
    }
}