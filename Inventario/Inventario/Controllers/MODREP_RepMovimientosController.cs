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
                Objetos.ObjRepKardex uno = new Objetos.ObjRepKardex("01/01/2019", "in", 100, 0, 20.50, "in");
                Objetos.ObjRepKardex dos = new Objetos.ObjRepKardex("02/02/2019", "in", 100, 0, 20.50, "in");
                lista.Add(uno);
                lista.Add(dos);
            }
            else//Reporte de salidas
            {
                Objetos.ObjRepKardex tres = new Objetos.ObjRepKardex("out", "Metros", 0, 25, 25.75, "03/03/2019");
                Objetos.ObjRepKardex cuatro = new Objetos.ObjRepKardex("salida", "Metros", 0, 25, 25.75, fechaIni.ToShortDateString());
                Objetos.ObjRepKardex cinco = new Objetos.ObjRepKardex("salida", "Metros", 0, 25, 25.75, fechaFin.ToShortDateString());
                lista.Add(tres);
                lista.Add(cuatro);
                lista.Add(cinco);
            }

            return lista;
        }
    }
}