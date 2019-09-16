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
            List<Objetos.ObjDetMovimiento> detalles = new List<Objetos.ObjDetMovimiento>();
            DataTable tabla = consulta("SELECT a.*, b.descripcion FROM det_movimiento a join producto b on a.producto_idproducto = b.idproducto WHERE movimiento_idingreso =" +devolucion );
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow detalle in tabla.Rows)
                    {
                        ObjDetMovimiento det = new ObjDetMovimiento();
                        det.cantidad = int.Parse(detalle["cantidad"].ToString());
                        det.movimiento_idingreso = int.Parse(detalle["movimiento_idingreso"].ToString());
                        det.producto_idproducto = int.Parse(detalle["producto_idproducto"].ToString());
                        det.descripcion = detalle["descripcion"].ToString();
                        detalles.Add(det);
                    }
                }
            }
            return View(detalles);
        }

        public ActionResult Compras()
        {
            List<Objetos.ObjDevolucion> compras = new List<Objetos.ObjDevolucion>();
            DataTable tabla = consulta("SELECT * FROM MOVIMIENTO WHERE tipo_movimiento='COMPRA'");
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow compra in tabla.Rows)
                    {
                        ObjDevolucion dev = new ObjDevolucion();
                        dev.idingreso = int.Parse(compra["idingreso"].ToString());
                        dev.fecha_ingreso = compra["fecha_ingreso"].ToString();
                        dev.descripcion = compra["descripcion"].ToString();
                        dev.estado = compra["estado"].ToString();
                        dev.usuario_ingresa = "Ludwin"; 
                        compras.Add(dev);
                    }
                }
            }
            return View(compras);
        }

        public ActionResult Compra(int compra)
        {
            ViewBag.compra = compra;
            List<Objetos.ObjDetMovimiento> detalles = new List<Objetos.ObjDetMovimiento>();
            DataTable tabla = consulta("SELECT a.*, b.descripcion FROM det_movimiento a join producto b on a.producto_idproducto = b.idproducto WHERE movimiento_idingreso =" + compra);
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow detalle in tabla.Rows)
                    {
                        ObjDetMovimiento det = new ObjDetMovimiento();
                        det.cantidad = int.Parse(detalle["cantidad"].ToString());
                        det.movimiento_idingreso = int.Parse(detalle["movimiento_idingreso"].ToString());
                        det.producto_idproducto = int.Parse(detalle["producto_idproducto"].ToString());
                        det.descripcion = detalle["descripcion"].ToString();
                        detalles.Add(det);
                    }
                }
            }
            return View(detalles);
        }

        public ActionResult Muestras()
        {
            List<Objetos.ObjMuestra> muestras = new List<Objetos.ObjMuestra>();
            DataTable tabla = consulta("SELECT * FROM MOVIMIENTO WHERE tipo_movimiento='MUESTRA'");
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow muestra in tabla.Rows)
                    {
                        ObjMuestra dev = new ObjMuestra();
                        dev.idingreso = int.Parse(muestra["idingreso"].ToString());
                        dev.fecha_ingreso = muestra["fecha_ingreso"].ToString();
                        dev.descripcion = muestra["descripcion"].ToString();
                        dev.estado = muestra["estado"].ToString();
                        dev.usuario_ingresa = "Ludwin"; //devolucion["usuario_ingresa"].ToString();
                        muestras.Add(dev);
                    }
                }
            }
            return View(muestras);
        }

        public ActionResult Muestra(int muestra)
        {
            ViewBag.muestra = muestra;
            List<Objetos.ObjDetMovimiento> detalles = new List<Objetos.ObjDetMovimiento>();
            DataTable tabla = consulta("SELECT a.*, b.descripcion FROM det_movimiento a join producto b on a.producto_idproducto = b.idproducto WHERE movimiento_idingreso =" + muestra);
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow detalle in tabla.Rows)
                    {
                        ObjDetMovimiento det = new ObjDetMovimiento();
                        det.cantidad = int.Parse(detalle["cantidad"].ToString());
                        det.movimiento_idingreso = int.Parse(detalle["movimiento_idingreso"].ToString());
                        det.producto_idproducto = int.Parse(detalle["producto_idproducto"].ToString());
                        det.descripcion = detalle["descripcion"].ToString();
                        detalles.Add(det);
                    }
                }
            }
            return View(detalles);
        }

        public ActionResult Index()
        {
            return View();
        }


        public static DataTable consulta(string consulta)
        {
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
        public ActionResult insertarDevolucion(string descripcion, string usuario_ingresa)
        {
            consulta("INSERT INTO MOVIMIENTO(fecha_ingreso,descripcion,tipo_movimiento,estado,usuario_idusuario,proveedor,pais_idpais) VALUES(getdate(),'" + descripcion + "','DEVOLUCION',0,1,'',1)");
            return RedirectToAction("Devoluciones");
        }

        [HttpPost]
        public ActionResult insertarDetalle(int cantidad, int producto, int movimiento, int modulo)
        {
            consulta("INSERT INTO det_movimiento(cantidad,movimiento_idingreso,producto_idproducto) VALUES(" + cantidad + "," + movimiento + "," + producto + ")");


            if (modulo == 0)
            {
                return RedirectToRoute(
                    new
                    {
                        controller = "MODING",
                        action = "Devolucion",
                        devolucion = movimiento
                    }
                );
            }
            else if (modulo == 1)
            {
                return RedirectToRoute(
                    new
                    {
                        controller = "MODING",
                        action = "Muestra",
                        muestra = movimiento
                    }
                );
            }
            else if (modulo == 2)
            {
                return RedirectToRoute(
                    new
                    {
                        controller = "MODING",
                        action = "Compra",
                        compra = movimiento
                    }
                );
            }
            else
            {
                return RedirectToAction("Devoluciones");
            }
        }

        [HttpPost]
        public ActionResult insertarMuestra(string descripcion, string usuario_ingresa)
        {
            consulta("INSERT INTO MOVIMIENTO(fecha_ingreso,descripcion,tipo_movimiento,estado,usuario_idusuario,proveedor,pais_idpais) VALUES(getdate(),'" + descripcion + "','MUESTRA',0,1,'',1)");
            return RedirectToAction("Muestras");
        }

        [HttpPost]
        public ActionResult insertarCompra(string descripcion, string usuario_ingresa)
        {
            consulta("INSERT INTO MOVIMIENTO(fecha_ingreso,descripcion,tipo_movimiento,estado,usuario_idusuario,proveedor,pais_idpais) VALUES(getdate(),'" + descripcion + "','COMPRA',0,1,'',1)");
            return RedirectToAction("Compras");
        }

    }
}