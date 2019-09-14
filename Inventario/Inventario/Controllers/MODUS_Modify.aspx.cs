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
                using (SqlConnection connection = new SqlConnection("Data Source=RODOLFO-HP\\SQL2017;Initial Catalog=AnalisisP1;Integrated Security=True"))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE usuario (fecha_alta) VALUES(@fecha)";

                    command.Parameters.Add("@Fecha", SqlDbType.Date).Value = txtFecha.Text;

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                /*SqlConnection con = new SqlConnection("Data Source=RODOLFO-HP\\SQL2017;Initial Catalog=AnalisisP1;Integrated Security=True");
                try
                {
                    con.Open();
                }
                catch (SqlException)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Error no hay conexion');", true);
                }

                SqlCommand cmd = new SqlCommand("UpdateFecha", con);
                cmd.CommandType = CommandType.TableDirect;

                cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = txtFecha.Text;

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Resta Realizada');", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Operacion Denegada');", true);
                }

                con.Close();*/
            }
        }
    }

    [Binding]
    public class StepDefinitions
    {
        [When("@Agregar fecha de alta"]
        public void agregarFecha()
        {
            if (txtFecha.Text != "")
            {
                using (SqlConnection connection = new SqlConnection("Data Source=RODOLFO-HP\\SQL2017;Initial Catalog=AnalisisP1;Integrated Security=True"))
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE usuario (fecha_alta) VALUES(@fecha)";

                    command.Parameters.Add("@Fecha", SqlDbType.Date).Value = txtFecha.Text;

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            }
    }
}