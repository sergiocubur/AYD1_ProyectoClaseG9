using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class MODSAL_RestaxVentaController : Controller
    {
        // GET: MODREP_RepKardex
        public ActionResult vMODSAL_RestaxVenta() 
        {
            List<Objetos.ObjRestaxVenta> lista = new List<Objetos.ObjRestaxVenta>();
            Objetos.ObjRestaxVenta uno = new Objetos.ObjRestaxVenta("01/01/2019", "Se vendieron", 100, 1, "Martillos", restar1(100, 1));
            Objetos.ObjRestaxVenta dos = new Objetos.ObjRestaxVenta("02/02/2019", "Se vendieron", 100, 5,  "Palas", restar1(55, 5));
            Objetos.ObjRestaxVenta tres = new Objetos.ObjRestaxVenta("01/01/2019", "Se vendieron", 100.25, 25, "Hojas", restar1(666, 25));
            lista.Add(uno);
            lista.Add(dos);
            lista.Add(tres);

            

            return View(lista);
        }

        public int restar1(int stock,int venta)
        {
            return stock-venta;
        }
    }
}