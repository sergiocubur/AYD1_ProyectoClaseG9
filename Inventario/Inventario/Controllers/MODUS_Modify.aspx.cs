using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TechTalk.SpecFlow;
using System.Data.SqlClient;
using System.Data;

namespace Inventario.Controllers
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        static string credenciales = "server=LAPTOP-SCUBUR\\SQLEXPRESS02; database=AnalisisP1 ; integrated security = true";
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txtFecha.Text != "")
            {
                using (SqlConnection con = new SqlConnection(credenciales))
                using (SqlCommand command = con.CreateCommand())
                {
                    command.Connection = con;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE usuario SET fecha_alta=@date WHERE codUsuario=@codigo";

                    command.Parameters.AddWithValue("@date", txtFecha.Text);
                    command.Parameters.AddWithValue("@codigo", txtCodigo.Text);

                    con.Open();

                    command.ExecuteNonQuery();

                    con.Close();
                }
            }
            if(txtPass.Text != "")
            {
                using (SqlConnection con = new SqlConnection(credenciales))
                using (SqlCommand command = con.CreateCommand())
                {
                    command.Connection = con;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE usuario SET password=@pass WHERE codUsuario=@codigo";

                    command.Parameters.AddWithValue("@pass", txtPass.Text);
                    command.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                    con.Open();

                    command.ExecuteNonQuery();

                    con.Close();
                }
            }
            if (txtApellido.Text != "")
            {
                using (SqlConnection con = new SqlConnection(credenciales))
                using (SqlCommand command = con.CreateCommand())
                {
                    command.Connection = con;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE usuario SET apellido=@apellido WHERE codUsuario=@codigo";

                    command.Parameters.AddWithValue("@apellido", txtApellido.Text);
                    command.Parameters.AddWithValue("@codigo", txtCodigo.Text);

                    con.Open();

                    command.ExecuteNonQuery();

                    con.Close();
                }
            }
            if(txtEstado.Text != "")
            {
                using (SqlConnection con = new SqlConnection(credenciales))
                using (SqlCommand command = con.CreateCommand())
                {
                    command.Connection = con;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE usuario SET estado=@state WHERE codUsuario=@codigo";

                    command.Parameters.AddWithValue("@state", txtEstado.Text);
                    command.Parameters.AddWithValue("@codigo", txtCodigo.Text);

                    con.Open();

                    command.ExecuteNonQuery();

                    con.Close();
                }
            }
            if (txtTipo.Text != "")
            {
                using (SqlConnection con = new SqlConnection(credenciales))
                using (SqlCommand command = con.CreateCommand())
                {
                    command.Connection = con;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE usuario SET tipo_usuario=@type WHERE codUsuario=@codigo";

                    command.Parameters.AddWithValue("@type", txtTipo.Text);
                    command.Parameters.AddWithValue("@codigo", txtCodigo.Text);

                    con.Open();

                    command.ExecuteNonQuery();

                    con.Close();
                }
            }

            txtFecha.Text = "";
            txtApellido.Text = "";
            txtEstado.Text = "";
            txtPass.Text = "";
            txtTipo.Text = "";
            txtFecha.Text = "";
        }
    }
}