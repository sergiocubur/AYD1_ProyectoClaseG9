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
    public class MODREP_RepKardexController : Controller
    {
        static string credenciales = "server=.; database=AnalisisP1 ; integrated security = true";
        // GET: MODREP_RepKardex
        public ActionResult vMODREP_RepKardex()
        {
            return View();
        }
        public ActionResult mostrandoRepKardex(DateTime fechaIni, DateTime fechaFin)
        {
            List<ObjRepKardex> listaKardex = getKardex(fechaIni, fechaFin);
            Session["LOG_KARDEX"] = listaKardex;
            return RedirectToAction("vMODREP_RepKardex", "MODREP_RepKardex");
        }
        [HttpGet]
        public List<ObjRepKardex> getKardex(DateTime fechaIni, DateTime fechaFin)
        {
            List<ObjRepKardex> lista = new List<ObjRepKardex>();
            /***************************************************
            ******************** Egresos ************************
            ***************************************************/
            string consulta = "select PE.nombre_cliente, PE.fecha_pedido, DPE.cantidad, PRO.descripcion, PE.total " +
                                "from pedido as PE, det_pedido as DPE, producto as PRO " +
                                "where DPE.pedido_idpedido = PE.idpedido " +
                                "and DPE.producto_idproducto = PRO.idproducto ";
                                //"and PE.fecha_pedido between '" + fechaIni.ToShortDateString() + "' and '" + fechaFin.ToShortDateString() + "'";
            DataTable dt = consultarBD(consulta);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ObjRepKardex nuevo = new ObjRepKardex();
                        nuevo.tipo = "Egreso";
                        nuevo.cliente_proveedor = row["nombre_cliente"].ToString();
                        nuevo.fecha = row["fecha_pedido"].ToString();
                        nuevo.cantidad = row["cantidad"].ToString();
                        nuevo.descripcion = row["descripcion"].ToString();
                        nuevo.total = row["total"].ToString();
                        lista.Add(nuevo);
                    }
                }
            }
            /***************************************************
             ******************* ingresos ************************
             ***************************************************/

            consulta = "select MO.fecha_ingreso, DMO.cantidad, MO.descripcion, (DMO.cantidad * PRO.precio_costo) total " +
                        "from movimiento as MO, det_movimiento DMO, producto as PRO " +
                        "where DMO.movimiento_idingreso = MO.idingreso " +
                        "and DMO.producto_idproducto = PRO.idproducto ";
                        //"and MO.fecha_ingreso between '" + fechaIni.ToShortDateString() + "' and '" + fechaFin.ToShortDateString() + "'";
            dt = consultarBD(consulta);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ObjRepKardex nuevo = new ObjRepKardex();
                        nuevo.tipo = "Ingreso";
                        nuevo.fecha = row["fecha_ingreso"].ToString();
                        nuevo.cantidad = row["cantidad"].ToString();
                        nuevo.descripcion = row["descripcion"].ToString();
                        nuevo.total = row["total"].ToString();
                        lista.Add(nuevo);
                    }
                }
            }
            return lista;
        }
        public static DataTable consultarBD(string Consulta)
        {
            
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
    }
}