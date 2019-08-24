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
            List<Objetos.ObjDevolucion> devoluciones = new List<Objetos.ObjDevolucion>();
            Objetos.ObjDevolucion devolucion1 = new Objetos.ObjDevolucion(1,"V7-999827","10/08/2019","Ingreso por mal estado","I","Ludwin");
            Objetos.ObjDevolucion devolucion2 = new Objetos.ObjDevolucion(2,"A9-398889","15/08/2019", "Ingreso por mal estado", "I", "Marcos");
            Objetos.ObjDevolucion devolucion3 = new Objetos.ObjDevolucion(3,"J8-929909", "16/08/2019", "Ingreso por cambio de producto", "I", "Monica");
            devoluciones.Add(devolucion1);
            devoluciones.Add(devolucion2);
            devoluciones.Add(devolucion3);
            return View(devoluciones);
        }

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
            ViewBag.compra = compra;
            return View();
        }

        public ActionResult Muestras()
        {
            return View();
        }

        public ActionResult Muestra(int muestra)
        {
            ViewBag.muestra = muestra;
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}