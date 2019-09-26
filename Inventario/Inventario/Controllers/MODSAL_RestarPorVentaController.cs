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

        public static DataTable conectarBD(string Consulta)
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
    }
}