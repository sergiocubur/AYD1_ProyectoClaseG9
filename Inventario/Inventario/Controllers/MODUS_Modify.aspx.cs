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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(txtFecha.Text != "")
            {
                using (SqlConnection connection = new SqlConnection("server=RODOLFO-HP\\SQL2017; database=AnalisisP1; integrated security = true"))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE usuario (fecha_alta) VALUES(@fecha) WHERE codigo ='"+txtCodigo.Text+"'";

                    command.Parameters.Add("@Fecha", SqlDbType.Date).Value = txtFecha.Text;

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            if(txtPass.Text != "")
            {
                using (SqlConnection connection = new SqlConnection("server=RODOLFO-HP\\SQL2017; database=AnalisisP1; integrated security = true"))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE usuario (password) VALUES(@pass) WHERE codigo ='" + txtCodigo.Text + "'";

                    command.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPass.Text;

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            if (txtApellido.Text != "")
            {
                using (SqlConnection connection = new SqlConnection("server=RODOLFO-HP\\SQL2017; database=AnalisisP1; integrated security = true"))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE usuario (apellido) VALUES(@apellido) WHERE codigo ='" + txtCodigo.Text + "'";

                    command.Parameters.Add("@papellido", SqlDbType.VarChar).Value = txtPass.Text;

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            if(txtEstado.Text != "")
            {
                using (SqlConnection connection = new SqlConnection("server=RODOLFO-HP\\SQL2017; database=AnalisisP1; integrated security = true"))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE usuario (estado) VALUES(@state) WHERE codigo ='" + txtCodigo.Text + "'";

                    command.Parameters.Add("@state", SqlDbType.Char).Value = txtPass.Text;

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            if (txtTipo.Text != "")
            {
                using (SqlConnection connection = new SqlConnection("server=RODOLFO-HP\\SQL2017; database=AnalisisP1; integrated security = true"))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE usuario (tipo_usuario) VALUES(@type) WHERE codigo ='" + txtCodigo.Text + "'";

                    command.Parameters.Add("@ptype", SqlDbType.VarChar).Value = txtPass.Text;

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
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