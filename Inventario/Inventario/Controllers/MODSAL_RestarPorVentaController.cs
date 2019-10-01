using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.Objetos;

namespace Inventario.Controllers
{
    public class MODSAL_RestarPorVentaController : Controller
    {
        // GET: MODSAL_RestarPorVenta
        public ActionResult vMODSAL_RestarPorVenta()
        {
            return View();
        }

        public static DataTable consultarBD(string Consulta)
        {
            string credenciales = "server=DESKTOP-39C8GSB; database=AnalisisP1 ; integrated security = true";
            SqlConnection conexion = new SqlConnection(credenciales);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            DataTable ds = new DataTable();
            try
            {
                conexion.Open();
                SqlCommand sql = new SqlCommand();
                sql.CommandText = Consulta;
                sql.CommandType = CommandType.Text;
                sql.Connection = conexion;

                adaptador.SelectCommand = sql;
                adaptador.Fill(ds);
                conexion.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(Consulta);
                return null;
            }
        }

        public ActionResult mostrandoVentas()
        {
            List<ObjRestaxVenta> listaVentas = new List<ObjRestaxVenta>();
            listaVentas.Add(new ObjRestaxVenta("fecha", "desc", 5.25, 1, "nom", 5));
            //Session["LOG_VENTAS"] = listaVentas;
            return RedirectToAction("vMODSAL_RestarPorVenta", "MODSAL_RestarPorVenta");
        }

        [HttpGet]
        public List<ObjProducto> getProductos()
        {
            List<ObjProducto> lista = new List<ObjProducto>();
            string consulta = "select * from producto;";
            DataTable dt = consultarBD(consulta);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ObjProducto nuevo = new ObjProducto();
                        nuevo.idproducto = Int16.Parse(row["idproducto"].ToString());
                        nuevo.descripcion = row["descripcion"].ToString();
                        nuevo.precio_costo = Double.Parse(row["precio_costo"].ToString());
                        nuevo.precio_venta = Double.Parse(row["precio_venta"].ToString());
                        nuevo.fecha_ingreso = row["fecha_ingreso"].ToString();
                        nuevo.fecha_modificacion = row["fecha_modificacion"].ToString();
                        nuevo.cantidad = Int16.Parse(row["cantidad"].ToString());
                        lista.Add(nuevo);
                    }
                }
            }
            return lista;
        }

        public string restando(int cantProducto, int cantIngresada, int producto)
        {
            if (cantIngresada < 0)
            {
                return "No se aceptan numeros negativos";
            }
            else if (cantIngresada > cantProducto)
            {
                return "No se cuenta con el producto suficiente para la venta,\n Cantidad de producto disponible: " + cantProducto;
            }
            else
            {
                int resta = cantProducto - cantIngresada;
                actualizarBD(producto, resta);
            }
            return "Yes";
        }

        public ActionResult restarPorVenta(int producto, int cantidad)
        {
            Session["ERROR_RESTA"] = null;
            if (cantidad == 0)
            {
                Session["ERROR_RESTA"] = "Ingrese una cantidad";
                return RedirectToAction("vMODSAL_RestarPorVenta", "MODSAL_RestarPorVenta");
            }

            foreach (ObjProducto prod in Session["LOG_PRODUCTOS"] as List<ObjProducto>)
            {
                if (producto == prod.idproducto)
                {
                    Session["ERROR_RESTA"] = restando(prod.cantidad, cantidad, producto);
                    return RedirectToAction("vMODSAL_RestarPorVenta", "MODSAL_RestarPorVenta");
                }
            }
            return RedirectToAction("vMODSAL_RestarPorVenta", "MODSAL_RestarPorVenta");
        }

        public static bool actualizarBD(int idProducto, int cantidad)
        {
            string credenciales = "server=DESKTOP-39C8GSB; database=AnalisisP1 ; integrated security = true";
            SqlConnection conexion = new SqlConnection(credenciales);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            try
            {
                conexion.Open();
                string sql = "update producto SET cantidad = @param1 where idproducto = @param2";
                using (SqlCommand cmdU = new SqlCommand(sql, conexion))
                {
                    cmdU.Parameters.Add("@param1", SqlDbType.Int).Value = cantidad;
                    cmdU.Parameters.Add("@param2", SqlDbType.Int).Value = idProducto;
                    cmdU.CommandType = CommandType.Text;
                    cmdU.ExecuteNonQuery();

                }
                conexion.Close();

            }
            catch (Exception ex)
            {
                conexion.Close();
                Trace.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public ActionResult vMODSAL_VerProductos()
        {
            return View();
        }

        public ActionResult mostrandoProductos()
        {
            List<ObjProducto> listaP = new List<ObjProducto>();
            listaP = getProductos();
            Session["LOG_PRODUCTOS"] = listaP;
            return RedirectToAction("vMODSAL_VerProductos", "MODSAL_RestarPorVenta");
        }

        
    }
}