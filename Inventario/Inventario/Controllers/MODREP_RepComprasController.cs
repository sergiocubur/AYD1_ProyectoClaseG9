using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class MODREP_RepComprasController : Controller
    {
        // GET: MODREP_RepCompras
        public ActionResult vMODREP_RepCompras()
        {
            return View();
        }

        public ActionResult mostrandoRepCompras(DateTime fechaIni, DateTime fechaFin, string tipoCompras)
        {
            List<Objetos.ObjRepKardex> listaCompras = getCompras(fechaIni, fechaFin, tipoCompras);
            Session["LOG_COMPRAS"] = listaCompras;
            return RedirectToAction("vMODREP_RepCompras", "MODREP_RepCompras");
        }
        [HttpGet]
        public List<Objetos.ObjRepKardex> getCompras(DateTime fechaIni, DateTime fechaFin, string tipoCompras)
        {
            List<Objetos.ObjRepKardex> lista = new List<Objetos.ObjRepKardex>();
            if (tipoCompras.Equals("nac"))    //Reporte de compras nacionales
            {

            }
            else //Reporte de compras internacionales
            {

            }
            return lista;
        }
    }
}