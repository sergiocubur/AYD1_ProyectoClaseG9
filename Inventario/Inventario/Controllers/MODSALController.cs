using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.Controllers;
using Inventario.Objetos;

namespace Inventario.Controllers
{
    public class MODSALController : Controller
    {
        // GET: MODSAL
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult vRestarMalEstado()
        {
            return View();
        }
        public ActionResult restarProducto(int producto, int cantidad)
        {
            MODSAL_RestarPorVentaController resta = new MODSAL_RestarPorVentaController();
            foreach(ObjProducto prod in resta.getProductos())
            {
                if(prod.idproducto == producto)
                {
                    resta.restando(prod.cantidadBD, cantidad, producto);
                    return RedirectToAction("vRestarMalEstado");
                }
            }
            return RedirectToAction("vRestarMalEstado");
        }

    }
}