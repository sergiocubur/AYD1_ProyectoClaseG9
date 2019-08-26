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
        public ActionResult vMODREP_RepKardex() //(List<Objetos.ObjRepKardex> lista)
        {
            List<Objetos.ObjRepKardex> lista = new List<Objetos.ObjRepKardex>();
            Objetos.ObjRepKardex uno = new Objetos.ObjRepKardex("01/01/2019", "Metros", 100, 0, 20.50, "-");
            Objetos.ObjRepKardex dos = new Objetos.ObjRepKardex("02/02/2019", "Martillos", 100, 0, 20.50, "-");
            Objetos.ObjRepKardex tres = new Objetos.ObjRepKardex("-", "Metros", 0, 25, 25.75, "03/03/2019");
            lista.Add(uno);
            lista.Add(dos);
            lista.Add(tres);

            return View(lista);
        }
    }
}