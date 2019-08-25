using Inventario.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            //Objetos.ObjDevolucion devolucion1 = new Objetos.ObjDevolucion(1,"V7-999827","10/08/2019","Ingreso por mal estado","I","Ludwin");
            //Objetos.ObjDevolucion devolucion2 = new Objetos.ObjDevolucion(2,"A9-398889","15/08/2019", "Ingreso por mal estado", "I", "Marcos");
            //Objetos.ObjDevolucion devolucion3 = new Objetos.ObjDevolucion(3,"J8-929909", "16/08/2019", "Ingreso por cambio de producto", "I", "Monica");
            //devoluciones.Add(devolucion1);
            //devoluciones.Add(devolucion2);
            //devoluciones.Add(devolucion3);
            DataTable tabla = consulta("SELECT * FROM MOVIMIENTO WHERE tipo_movimiento='DEVOLUCION'");
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow devolucion in tabla.Rows)
                    {
                        ObjDevolucion dev = new ObjDevolucion();
                        dev.idingreso = int.Parse(devolucion["idingreso"].ToString());
                        dev.fecha_ingreso = devolucion["fecha_ingreso"].ToString();
                        dev.descripcion = devolucion["descripcion"].ToString();
                        dev.estado = devolucion["estado"].ToString();
                        dev.usuario_ingresa = "Ludwin"; //devolucion["usuario_ingresa"].ToString();
                        devoluciones.Add(dev);
                    }
                }
            }
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
            List<Objetos.ObjMuestra> muestras = new List<Objetos.ObjMuestra>();
            ViewBag.muestra = muestra;
            Objetos.ObjMuestra devolucion1 = new Objetos.ObjMuestra(1, "V7-999827", "10/08/2019", "Muestra para showroom", "I", "Ludwin");
            Objetos.ObjMuestra devolucion2 = new Objetos.ObjMuestra(2, "A9-398889", "15/08/2019", "Muestra para Zona 12", "I", "Marcos");
            Objetos.ObjMuestra devolucion3 = new Objetos.ObjMuestra(3, "J8-929909", "16/08/2019", "Muestra para Comercial 2", "I", "Monica");
            muestras.Add(devolucion1);
            muestras.Add(devolucion2);
            muestras.Add(devolucion3);
            return View(muestras);
        }

        public ActionResult Index()
        {
            return View();
        }


        public static DataTable consulta(string consulta) {
            string credenciales = "server=LAPTOP-LUDWIN;database=AnalisisP1;integrated security=true";
            SqlConnection conexion = new SqlConnection(credenciales);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable ds = new DataTable();
            try
            {
                conexion.Open();
                SqlCommand sql = new SqlCommand();
                sql.CommandText = consulta;
                sql.CommandType = CommandType.Text;
                sql.Connection = conexion;

                adaptador.SelectCommand = sql;
                adaptador.Fill(ds);
                conexion.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(consulta);
                return null;
            }
        }

        [HttpPost]
        public ActionResult insertarDevolucion(string descripcion,string usuario_ingresa)
        {
            consulta("INSERT INTO MOVIMIENTO(fecha_ingreso,descripcion,tipo_movimiento,estado,usuario_ingresa) VALUES(getdate(),'"+descripcion+ "','DEVOLUCION','I',1)");
            return RedirectToAction("Devoluciones");
        }
    }
}