using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class MODINGController : Controller
    {
        [HttpGet]
        public ActionResult Devoluciones()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Devolucion(int devolucion)
        {
            ViewBag.Devolucion = devolucion;
            return View();
        }

        public ActionResult Compras()
        {
            return View();
        }

        public ActionResult Compra(int compra)
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}