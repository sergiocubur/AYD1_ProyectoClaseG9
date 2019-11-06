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
    public class MODUSRController : Controller
    {
        // GET: MODUSR
        public ActionResult Index()
        {
            List<Objetos.ObjUsuario> usuarios = new List<Objetos.ObjUsuario>();
            DataTable tabla = consulta("SELECT * FROM usuario");
            if (tabla != null)
            {
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow usuario in tabla.Rows)
                    {
                        ObjUsuario dev = new ObjUsuario();
                        dev.idusuario = int.Parse(usuario["idusuario"].ToString());
                        dev.dpi = usuario["dpi"].ToString();
                        dev.apellido = usuario["apellido"].ToString();
                        dev.tipo_usuario = usuario["tipo_usuario"].ToString();
                        dev.estado = char.Parse(usuario["estado"].ToString());
                        dev.fecha_alta = usuario["fecha_alta"].ToString();
                        dev.codUsuario = usuario["codUsuario"].ToString();
                        dev.password = usuario["password"].ToString();
                        usuarios.Add(dev);
                    }
                }
            }
            return View(usuarios);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult agregar_usuario(string dpi, string apellido,string codUsuario, string password)
        {
            int formula=comprobarForm(dpi,apellido,codUsuario,password);
            int largo_pass = largoPassword(password);
            int numero_pass = numeroPassword(password);
            int simbolo_pass = simboloPassword(password);
            int mayuscula_pass = mayusculaPassword(password);
            int largo_cod = largoCodUsuario(codUsuario);
            int largo_dpi = largoDpi(dpi);

            if (formula==0 || largo_pass==0 || numero_pass == 0 || simbolo_pass == 0 || mayuscula_pass == 0 || largo_cod == 0 || largo_dpi == 0) { return RedirectToAction("Add"); }


            consulta("INSERT INTO [dbo].[usuario] ([dpi],[apellido],[tipo_usuario],[estado],[fecha_alta],[codUsuario],[password]) VALUES('" + dpi + "','" + apellido + "','OPERADOR','a',getdate(),'" + codUsuario + "','" + password + "')");
            return RedirectToAction("Index");

        }
        public ActionResult delete(int id)
        {
            consulta("DELETE FROM usuario WHERE idusuario=" + id);
            return RedirectToAction("Index");
        }
        public int comprobarForm(string dpi, string apellido, string codUsuario, string password)
        {
            if (dpi == "" || apellido == "" || codUsuario == "" || password == "") { return 0; }
            else { return 1; }
            
        }
        public int largoPassword(string password)
        {
            int largo = password.Length;
            if (largo < 6) { return 0; }
            else { return 1;}
            
        }
        public int numeroPassword(string password)
        {
            bool comproba = false;
            if (password.Contains("1") || password.Contains("2") || password.Contains("3") || password.Contains("4") || password.Contains("5") || password.Contains("6") || password.Contains("7") || password.Contains("8") || password.Contains("9") || password.Contains("0")) { comproba = true; }


            if (comproba==false) { return 0; }
            else { return 1; }
            
        }
        public int simboloPassword(string password)
        {
            bool comproba = false;
            if (password.Contains("!") || password.Contains("#") || password.Contains("_") || password.Contains("$") || password.Contains("%") || password.Contains("&") || password.Contains("/") || password.Contains("¡") || password.Contains("?") || password.Contains("¿")) { comproba = true; }


            if (comproba == false) { return 0; }
            else { return 1; }
        }
        public int mayusculaPassword(string password)
        {
            bool tieneMayusculas = password.Any(c => char.IsUpper(c));
           
            if (tieneMayusculas == false) { return 0; }
            else { return 1; }
            
        }
        public int largoCodUsuario(string codUsuario)
        {
            int largo = codUsuario.Length;
            if (largo != 4) { return 0; }
            else { return 1; }
        }
        public int largoDpi(string dpi)
        {
            int largo = dpi.Length;
            if (largo < 13) { return 0; }
            else { return 1; }
        }
        public static DataTable consulta(string consulta)
        {
            string credenciales = "server=.;database=AnalisisP1;integrated security=true";
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


        public ActionResult Edit(int id, string dpi, string nombre, string codigo,string password)
        {
            ObjUsuario userMod = new ObjUsuario();
            userMod.idusuario = id;
            userMod.dpi = dpi;
            userMod.apellido = nombre;
            userMod.codUsuario = codigo;
            userMod.password = password;
            Session["MODIFICANDO"] = id;
            return View(userMod);
        }
        public ActionResult modificar_usuario(string dpi, string nombre, string codUsuario, string password)
        {
            int formula = comprobarForm(dpi, nombre, codUsuario, password);
            int largo_pass = largoPassword(password);
            int numero_pass = numeroPassword(password);
            int simbolo_pass = simboloPassword(password);
            int mayuscula_pass = mayusculaPassword(password);
            int largo_cod = largoCodUsuario(codUsuario);
            int largo_dpi = largoDpi(dpi);

            if (formula == 0 || largo_pass == 0 || numero_pass == 0 || simbolo_pass == 0 || mayuscula_pass == 0 || largo_cod == 0 || largo_dpi == 0) {
                return RedirectToAction("Index");
            }
            consulta("UPDATE usuario SET dpi = '" + dpi + "',apellido='" + nombre + "',codUsuario='" + codUsuario + "',password='" + password + "' where idusuario =" + Session["MODIFICANDO"].ToString());
            Session["MODIFICANDO"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult darBajaUsuario(int id)
        {
            consulta("UPDATE usuario SET estado = 0 where idusuario =" + id);
            return RedirectToAction("Index");
        }
    }
}