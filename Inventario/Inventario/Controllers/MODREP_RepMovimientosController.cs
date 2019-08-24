using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class MODREP_RepMovimientosController : Controller
    {
        // GET: MODREP_RepMovimientos
        public ActionResult vMODREP_RepMovimientos()
        {
            return View();
        }


        public ActionResult mostrandoRepMovimientos(DateTime fechaIni, DateTime fechaFin, string tipoMovimiento)
        {
            List<Objetos.ObjRepKardex> listaMovimientos = getMovimientos(fechaIni, fechaFin, tipoMovimiento);
            Session["LOG_MOVIMIENTOS"] = listaMovimientos;
            return RedirectToAction("vMODREP_RepMovimientos", "MODREP_RepMovimientos");
        }
        [HttpGet]
        public List<Objetos.ObjRepKardex> getMovimientos(DateTime fechaIni, DateTime fechaFin, string tipoMovimiento)
        {
            List<Objetos.ObjRepKardex> lista = new List<Objetos.ObjRepKardex>();
            if (tipoMovimiento.Equals("in"))    //Reporte de entradas
            {

            }
            else//Reporte de salidas
            {

            }
            return lista;
        }
    }
}