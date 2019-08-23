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
    public partial class MODINS_Insertar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRestaVEntas_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text=="" || txtCantidad.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(),"Show Modal Popup", "alert ('Debe llenar todos los campos');", true );
                //txtError.Text = "Error: Debe llenar ambos campos";
                return;
            }
            else
            {
                string product = txtProducto.Text;
                string cantidad = txtCantidad.Text;
                //conexion con = new conexion("ISIDRO", "GuateEduca");
                SqlConnection con = new SqlConnection("Data Source=RODOLFO-HP\\SQL2014;Initial Catalog=Analisis_Inventario;Integrated Security=True");
                try
                {
                    con.Open();
                }
                catch (SqlException)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Error no hay conexion');", true);
                }

                SqlCommand comando = new SqlCommand("Select * from Inventario where Producto='"+product,con);
                SqlDataReader reader = comando.ExecuteReader();
                //SqlDataReader consultar = con.Consulta("Select usuario,contraseña from Usuario  where usuario='" + product.Text + "' and contraseña='" + cantidad.Text + "';");
                if(reader.HasRows)
                {
                    int cant = 0, c = 0;
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select Cantidad from Iventario where Producto='"+product+"';";
                        cmd.Parameters.AddWithValue("@Cantidad", c);
                        cant = c + Int32.Parse(cantidad);
                    }
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert into Iventario(Producto, Cantidad) VALUES (@Producto,@Cantidad);";
                        cmd.Parameters.AddWithValue("@Producto", product);
                        cmd.Parameters.AddWithValue("@Cantidad", Int32.Parse(cantidad));
                    }
                }
            }
        }
    }
}