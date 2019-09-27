using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventario
{
    public partial class MODSAL_RestaMalEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text == "" || txtCantidad.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Debe llenar todos los campos');", true);
                //return 1;
            }
            else
            {
                int cant = Convert.ToInt32(txtCantidad.Text);
                string credenciales = "server=RODOLFO-HP\\SQL2017;database=Practica2;integrated security=true";
                SqlConnection con = new SqlConnection(credenciales);
                SqlCommand command = new SqlCommand();

                command.Connection = con;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT cantidad FROM producto WHERE descripcion=@product";
                command.Parameters.AddWithValue("@product", txtProducto.Text);

                try
                {
                    con.Open();
                    int a = Convert.ToInt32(command.ExecuteScalar());
                    if (a != 0)
                    {
                        if (a > cant)
                        {

                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        public int consulta(string product, int cantidad)
        {
            if (txtProducto.Text == "" || txtCantidad.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Debe llenar todos los campos');", true);
                return 0;
            }
            else
            {
                string credenciales = "server=RODOLFO-HP\\SQL2017;database=Practica2;integrated security=true";
                SqlConnection con = new SqlConnection(credenciales);
                SqlCommand command = new SqlCommand();

                command.Connection = con;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT id FROM producto where nombre=@nimbre";
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtProducto.Text;
                /*command.Parameters.Add("@dpi", SqlDbType.VarChar).Value = txtdpi.Text;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text;
                command.Parameters.Add("@dir", SqlDbType.VarChar).Value = txtDireccion.Text;
                command.Parameters.Add("@mail", SqlDbType.VarChar).Value = txtCorreo.Text;
                command.Parameters.Add("@cod", SqlDbType.VarChar).Value = txtUsuario.Text;
                command.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPassword.Text;*/

                try
                {
                    con.Open();
                    //Response.Write("Conexion Establecida");
                    int ok = command.ExecuteNonQuery();
                    con.Close();

                    if (ok > 0)
                    {
                        return 2;
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return 0;
            }
        }
    }
}