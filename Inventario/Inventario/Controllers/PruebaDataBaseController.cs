using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class PruebaDataBaseController : Controller
    {
        // GET: PruebaDataBase
        public ActionResult Index()
        {
            DataBase db = new DataBase();
            var listusuarios=db.producto.ToList();
            return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = listusuarios };
        }
    }
}