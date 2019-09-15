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
    public class MODUSRController : Controller
    {
        // GET: MODUSR
        public ActionResult Index()
        {
            return View();
        }
        public int comprobarForm()
        {
            
            return 0;
        }
        public int largoPassword()
        {

            return 0;
        }
        public int numeroPassword()
        {

            return 0;
        }
        public int simboloPassword()
        {

            return 0;
        }
        public int mayusculaPassword()
        {

            return 0;
        }
        public int largoCodUsuario()
        {

            return 0;
        }
        public int largoDpi()
        {

            return 0;
        }
        public static DataTable consulta(string consulta)
        {
            string credenciales = "server=LAPTOP-SCUBUR\\SQLEXPRESS02;database=AnalisisP1;integrated security=true";
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