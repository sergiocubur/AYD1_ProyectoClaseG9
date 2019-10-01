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
    public class MODREP_RepComprasController : Controller
    {
        // GET: MODREP_RepCompras
        public ActionResult vMODREP_RepCompras()
        {
            return View();
        }

        public ActionResult mostrandoRepCompras(DateTime fechaIni, DateTime fechaFin, string tipoCompras)
        {
            List<ObjRepKardex> listaCompras = getCompras(fechaIni, fechaFin, tipoCompras);
            Session["LOG_COMPRAS"] = listaCompras;
            return RedirectToAction("vMODREP_RepCompras", "MODREP_RepCompras");
        }
        [HttpGet]
        public List<ObjRepKardex> getCompras(DateTime fechaIni, DateTime fechaFin, string tipoCompras)
        {
            List<ObjRepKardex> lista = new List<ObjRepKardex>();
            if (tipoCompras.Equals("nac"))    //Reporte de compras nacionales
            {
                string consulta = "select MO.proveedor,  MO.descripcion, PA.nombre, MO.fecha_ingreso, DMO.cantidad, PRO.precio_costo, (DMO.cantidad * PRO.precio_costo) as total " +
                                    "from movimiento as MO, det_movimiento DMO, producto as PRO, pais as PA " +
                                    "where PA.idpais = MO.pais_idpais " +
                                    "and PA.nombre = 'Guatemala' " +
                                    "and DMO.movimiento_idingreso = MO.idingreso " +
                                    "and DMO.producto_idproducto = PRO.idproducto " +
                                    "and MO.fecha_ingreso between '" + fechaIni.ToShortDateString() + "' and '" + fechaFin.ToShortDateString() + "'";
                DataTable dt = consultarBD(consulta);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            ObjRepKardex nuevo = new ObjRepKardex();
                            nuevo.cliente_proveedor = row["proveedor"].ToString();
                            nuevo.descripcion = row["descripcion"].ToString();
                            nuevo.pais = row["nombre"].ToString();
                            nuevo.fecha = row["fecha_ingreso"].ToString();
                            nuevo.cantidad = row["cantidad"].ToString();
                            nuevo.costo = row["precio_costo"].ToString();
                            nuevo.total = row["total"].ToString();
                            lista.Add(nuevo);
                        }
                    }
                }
            }
            else //Reporte de compras internacionales
            {
                string consulta = "select MO.proveedor,  MO.descripcion, PA.nombre, MO.fecha_ingreso, DMO.cantidad, PRO.precio_costo, (DMO.cantidad * PRO.precio_costo) as total " +
                                    "from movimiento as MO, det_movimiento DMO, producto as PRO, pais as PA " +
                                    "where PA.idpais = MO.pais_idpais " +
                                    "and PA.nombre <> 'Guatemala' " +
                                    "and DMO.movimiento_idingreso = MO.idingreso " +
                                    "and DMO.producto_idproducto = PRO.idproducto " +
                                    "and MO.fecha_ingreso between '" + fechaIni.ToShortDateString() + "' and '" + fechaFin.ToShortDateString() + "'";
                DataTable dt = consultarBD(consulta);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            ObjRepKardex nuevo = new ObjRepKardex();
                            nuevo.cliente_proveedor = row["proveedor"].ToString();
                            nuevo.descripcion = row["descripcion"].ToString();
                            nuevo.pais = row["nombre"].ToString();
                            nuevo.fecha = row["fecha_ingreso"].ToString();
                            nuevo.cantidad = row["cantidad"].ToString();
                            nuevo.costo = row["precio_costo"].ToString();
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
            string credenciales = "server=LAPTOP-SCUBUR\\SQLEXPRESS02; database=AnalisisP1 ; integrated security = true";
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