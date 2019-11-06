using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Diagnostics;

namespace Inventario.Controllers
{
    public class MODINI_LoginController : Controller
    {
        static string credenciales = "server=.; database=AnalisisP1 ; integrated security = true";
        // GET: MODINI_Login
        public ActionResult vMODINI_Login()
        {
            if(Session["codeU"] != null)
            {
                return RedirectToAction("vMODINI_Logeado", "MODINI_Logeado");
            }
            //Session["Error"] = null;
            return View();
        }
        //LOGIN USUARIO---
        [HttpPost]
        public ActionResult Autorizar(string user, string password)
        {
            string consulta = "select idusuario, apellido, codUsuario, password from usuario where codUsuario = '" + user + "' and password = '" + password + "'";
            DataTable dt = consultarBD(consulta);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                if (user.Equals(row["codUsuario"].ToString()) && password.Equals(row["password"].ToString()))
                {
                    Session["idU"] = row["idusuario"].ToString();
                    Session["codeU"] = row["codUsuario"].ToString();
                    Session["nameU"] = row["apellido"].ToString();
                    Session["Error"] = null;
                    return RedirectToAction("vMODINI_Logeado", "MODINI_Logeado");
                }
            }
            Session["Error"] = "Codigo de usuario o contraseña incorrecto..!!!";
            return RedirectToAction("vMODINI_Login", "MODINI_Login");
        }
        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("vMODINI_Login", "MODINI_Login");
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