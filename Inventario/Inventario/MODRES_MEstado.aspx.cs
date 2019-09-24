using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Inventario
{
    public partial class MODRES_MEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        int i;
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (txtProducto.Text == "" || txtCantidad.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Debe llenar todos los campos');", true);
                //txtError.Text = "Error: Debe llenar ambos campos";
                return;
            }
            else
            {
                string product = txtProducto.Text;
                string cantidad = txtCantidad.Text;
                //conexion con = new conexion("ISIDRO", "GuateEduca");
                SqlConnection con = new SqlConnection("Data Source=RODOLFO-HP\\SQL2017;Initial Catalog=AnalisisP1;Integrated Security=True");
                try
                {
                    con.Open();
                }
                catch (SqlException)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Error no hay conexion');", true);
                }

                SqlCommand cmd = new SqlCommand("RestaVenta", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Producto", SqlDbType.VarChar).Value = product;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = cantidad;

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Resta Realizada');", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Operacion Denegada');", true);
                }

                con.Close();

            }
        }

        public int consulta(string product, int cantidad)
        {
            if (cantidad == 0 || product == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Debe llenar todos los campos');", true);
                //txtError.Text = "Error: Debe llenar ambos campos";
                return 0;
            }
            else
            {

                //conexion con = new conexion("ISIDRO", "GuateEduca");
                SqlConnection con = new SqlConnection("Data Source=RODOLFO-HP\\SQL2017;Initial Catalog=AnalisisP1;Integrated Security=True");
                try
                {
                    con.Open();
                }
                catch (SqlException)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Error no hay conexion');", true);
                }

                SqlCommand cmd = new SqlCommand("RestaVenta", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Producto", SqlDbType.VarChar).Value = product;
                cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = cantidad;

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Resta Realizada');", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Operacion Denegada');", true);
                }

                con.Close();
                return 1;

                /*
                 *  string credenciales = "server=RODOLFO-HP\\SQL2017;database=Practica2;integrated security=true";
            SqlConnection con = new SqlConnection(credenciales);
            SqlCommand command = new SqlCommand();

            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "INSERT INTO empleado (dpi,nombre,direccion,mail,cod_empleado,password,tipoempleado_tipoempleado) VALUES(@dpi,@nombre,@dir, @mail, @cod, @pass,1)";
            command.Parameters.Add("@dpi", SqlDbType.VarChar).Value = txtdpi.Text;
            command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text;
            command.Parameters.Add("@dir", SqlDbType.VarChar).Value = txtDireccion.Text;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = txtCorreo.Text;
            command.Parameters.Add("@cod", SqlDbType.VarChar).Value = txtUsuario.Text;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPassword.Text;

            try {
                con.Open();
                //Response.Write("Conexion Establecida");
                int ok = command.ExecuteNonQuery();
                con.Close();

                if(ok > 0)
                {
                    Response.Write("Usuario Registrado");
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }*/
            }
        }
    }
}
 