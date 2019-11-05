using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.Objetos;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Inventario.Controllers
{
    public class MODREP_RepMovimientosController : Controller
    {
        static string credenciales = "server=LAPTOP-SCUBUR\\SQLEXPRESS02; database=AnalisisP1 ; integrated security = true";
        // GET: MODREP_RepMovimientos
        public ActionResult vMODREP_RepMovimientos()
        {

            return View();

        }

        public ActionResult mostrandoRepMovimientos(DateTime fechaIni, DateTime fechaFin, string tipoMovimiento)
        {
            List<ObjRepKardex> listaMovimientos = getMovimientos(fechaIni, fechaFin, tipoMovimiento);
            Session["LOG_MOVIMIENTOS"] = listaMovimientos;
            return RedirectToAction("vMODREP_RepMovimientos", "MODREP_RepMovimientos");
        }
        [HttpGet]
        public List<ObjRepKardex> getMovimientos(DateTime fechaIni, DateTime fechaFin, string tipoMovimiento)
        {
            List<ObjRepKardex> lista = new List<ObjRepKardex>();
            if (tipoMovimiento.Equals("in"))    //Reporte de entradas
            {
                string consulta = "select MO.descripcion, MO.fecha_ingreso, DMO.cantidad, (DMO.cantidad * PRO.precio_costo) total " +
                                    "from movimiento as MO, det_movimiento DMO, producto as PRO " +
                                    "where DMO.movimiento_idingreso = MO.idingreso " +
                                    "and DMO.producto_idproducto = PRO.idproducto ";
                                    //"and MO.fecha_ingreso between '" + fechaIni.ToShortDateString() + "' and '" + fechaFin.ToShortDateString() + "'";
                DataTable dt = consultarBD(consulta);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            ObjRepKardex nuevo = new ObjRepKardex();
                            nuevo.descripcion = row["descripcion"].ToString();
                            nuevo.fecha = row["fecha_ingreso"].ToString();
                            nuevo.cantidad = row["cantidad"].ToString();
                            nuevo.total = row["total"].ToString();
                            lista.Add(nuevo);
                        }
                    }
                }
            }
            else
            {
                string consulta = "select PE.nombre_cliente, PRO.descripcion, PE.fecha_pedido, DPE.cantidad, PE.total " +
                                    "from pedido as PE, det_pedido as DPE, producto as PRO" +
                                    "where DPE.pedido_idpedido = PE.idpedido" +
                                    "and DPE.producto_idproducto = PRO.idproducto";
                                    //"and PE.fecha_pedido between '" + fechaIni.ToShortDateString() + "' and '" + fechaFin.ToShortDateString() + "'";
                DataTable dt = consultarBD(consulta);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            ObjRepKardex nuevo = new ObjRepKardex();
                            nuevo.cliente_proveedor = row["nombre_cliente"].ToString();
                            nuevo.descripcion = row["descripcion"].ToString();
                            nuevo.fecha = row["fecha_pedido"].ToString();
                            nuevo.cantidad = row["cantidad"].ToString();
                            nuevo.total = row["total"].ToString();
                            lista.Add(nuevo);
                        }
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