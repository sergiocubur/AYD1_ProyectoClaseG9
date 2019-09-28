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
                int result = 0;
                string credenciales = "server=RODOLFO-HP\\SQL2017;database=AnalisisP1;integrated security=true";
                SqlConnection con = new SqlConnection(credenciales);
                SqlCommand command = new SqlCommand();

                command.Connection = con;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT cantidad FROM producto WHERE descripcion=@product";
                command.Parameters.AddWithValue("@product", txtProducto.Text);
                //Response.Write("Pasa por aca " + cant);
                try
                {
                    con.Open();
                    int a = Convert.ToInt32(command.ExecuteScalar());
                    //Response.Write("Consulta: " + a);
                    if (a > cant)
                    {
                        result = a - cant;
                        con.Close();
                        Consultaupdate(result, txtProducto.Text);
                        txtProducto.Text = "";
                        txtCantidad.Text = "";
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('No se puede restar mas de lo que hay en inventario');", true);
                        txtCantidad.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        public void Consultaupdate(int cantidad, string producto)
        {
            Response.Write("update " + cantidad + " " + producto);
            string credenciales = "server=RODOLFO-HP\\SQL2017;database=AnalisisP1;integrated security=true";
            SqlConnection con = new SqlConnection(credenciales);
            SqlCommand command = new SqlCommand();

            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE producto SET cantidad=@cantidad WHERE descripcion=@product";
            command.Parameters.AddWithValue("@product", producto);
            command.Parameters.AddWithValue("@cantidad", cantidad);

            try
            {
                con.Open();
                int r = command.ExecuteNonQuery();
                if (r == 0)
                {
                    Response.Write("No hubo nada");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Response.Write(e);
            }

        }

        public int consultaUp(int cantidad, string producto)
        {
            Response.Write("update " + cantidad + " " + producto);
            string credenciales = "server=RODOLFO-HP\\SQL2017;database=AnalisisP1;integrated security=true";
            SqlConnection con = new SqlConnection(credenciales);
            SqlCommand command = new SqlCommand();

            command.Connection = con;
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE producto SET cantidad=@cantidad WHERE descripcion=@product";
            command.Parameters.AddWithValue("@product", producto);
            command.Parameters.AddWithValue("@cantidad", cantidad);

            try
            {
                con.Open();
                int r = command.ExecuteNonQuery();
                if (r != 0)
                {
                    return 4;
                }
                else
                {
                    return 0;
                }
                con.Close();
            }
            catch (Exception e)
            {
                Response.Write(e);
            }
            return 0;
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
                int c = consultaSelect(product);
            }
            return 0;
        }

        public int consultaSelect(string product)
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
                    return 1;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return 0;
        }
    }
}