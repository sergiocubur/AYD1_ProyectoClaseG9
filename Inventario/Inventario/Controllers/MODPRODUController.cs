using Inventario.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Views.MODPROD
{
    public class MODPRODUController : Controller
    {
        public static string credenciales = "server=LAPTOP-SCUBUR\\SQLEXPRESS02;database=AnalisisP1;integrated security=true";
        // GET: MODPRODU
        public ActionResult Index()
        {
            List<Objetos.ObjProducto> productos = new List<Objetos.ObjProducto>();
            DataTable tabla = consulta("SELECT * FROM producto");
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow producto in tabla.Rows)
                    {
                        ObjProducto dev = new ObjProducto();
                        dev.idproducto = int.Parse(producto["idproducto"].ToString());
                        dev.descripcion = producto["descripcion"].ToString();
                        dev.precio_costo = double.Parse(producto["precio_costo"].ToString());
                        dev.precio_venta = double.Parse(producto["precio_venta"].ToString());
                        dev.fecha_ingreso = producto["fecha_ingreso"].ToString();
                        dev.fecha_modificacion = producto["fecha_modificacion"].ToString();
                        productos.Add(dev);
                    }
                }
            }
            return View(productos);
        }

        public ActionResult agregar()
        {

            return View();
        }

        public ActionResult agregar_producto(int idproducto, string descripcion,double precio_compra, double precio_venta)
        {
            consulta("INSERT INTO [dbo].[producto] ([idproducto],[descripcion],[precio_costo],[precio_venta],[fecha_ingreso],[fecha_modificacion]) VALUES("+ idproducto + ",'" + descripcion + "',"+precio_compra+ "," + precio_venta + ",getdate(),getdate())");
            return RedirectToAction("Index");

        }

        public ActionResult editar_producto(int idproducto, string descripcion, double precio_compra, double precio_venta)
        {
            consulta("UPDATE producto SET descripcion='" + descripcion + "',precio_costo=" + precio_compra + ",precio_venta=" + precio_venta + ",fecha_modificacion=getdate() WHERE idproducto=" + idproducto);
            return RedirectToAction("Index");

        }

        public ActionResult editar(int id)
        {
            Objetos.ObjProducto producto = new Objetos.ObjProducto();
            DataTable tabla = consulta("SELECT * FROM producto WHERE idproducto="+id);
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow productos in tabla.Rows)
                    {
                        
                        ViewData["idproducto"] = int.Parse(productos["idproducto"].ToString());
                        ViewData["descripcion"] = productos["descripcion"].ToString();
                        ViewData["precio_costo"] = double.Parse(productos["precio_costo"].ToString());
                        ViewData["precio_venta"] = double.Parse(productos["precio_venta"].ToString());
                        
                    }
                }
            }
            return View();
        }

        public ActionResult delete(int id)
        {
            consulta("DELETE FROM producto WHERE idproducto=" + id);
            return RedirectToAction("Index");
        }

        public static DataTable consulta(string consulta)
        {
            
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
    }
}