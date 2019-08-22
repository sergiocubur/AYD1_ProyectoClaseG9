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
                Objetos.ObjRepKardex uno = new Objetos.ObjRepKardex("01/01/2019", "nacional", 100, 0, 20.50, "in");
                Objetos.ObjRepKardex dos = new Objetos.ObjRepKardex("02/02/2019", "nacional", 100, 0, 20.50, "in");
                lista.Add(uno);
                lista.Add(dos);
            }
            else //Reporte de compras internacionales
            {
                Objetos.ObjRepKardex tres = new Objetos.ObjRepKardex("internacional", "Metros", 0, 25, 25.75, "03/03/2019");
                Objetos.ObjRepKardex cuatro = new Objetos.ObjRepKardex("internacional", "Metros", 0, 25, 25.75, fechaIni.ToShortDateString());
                Objetos.ObjRepKardex cinco = new Objetos.ObjRepKardex("internacional", "Metros", 0, 25, 25.75, fechaFin.ToShortDateString());
                lista.Add(tres);
                lista.Add(cuatro);
                lista.Add(cinco);
            }

            return lista;
        }
    }
}