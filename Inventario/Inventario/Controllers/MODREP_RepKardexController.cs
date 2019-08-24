using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class MODREP_RepKardexController : Controller
    {
        // GET: MODREP_RepKardex
        public ActionResult vMODREP_RepKardex()
        {
            return View();
        }
        public ActionResult mostrandoRepKardex(DateTime fechaIni, DateTime fechaFin)
        {
            List<Objetos.ObjRepKardex> listaKardex = getKardex(fechaIni, fechaFin);
            Session["LOG_KARDEX"] = listaKardex;
            return RedirectToAction("vMODREP_RepKardex", "MODREP_RepKardex");
        }
        [HttpGet]
        public List<Objetos.ObjRepKardex> getKardex(DateTime fechaIni, DateTime fechaFin)
        {
            List<Objetos.ObjRepKardex> lista = new List<Objetos.ObjRepKardex>();
            
            return lista;
        }
    }
}