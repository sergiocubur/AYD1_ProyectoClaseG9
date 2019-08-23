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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fecha = "";
            int idpr = 0, id = 0; ;
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
                SqlConnection con = new SqlConnection("Data Source=RODOLFO-HP\SQL2017;Initial Catalog=AnalisisP1;Integrated Security=True");
                try
                {
                    con.Open();
                }
                catch (SqlException)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Show Modal Popup", "alert ('Error no hay conexion');", true);
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into movimiento(fecha_ingreso, descripcion, tipo_movimiento, estado) VALUES (@fecha,@des,@tmovimiento,@est);";
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("ddd MMM yyy"));
                    cmd.Parameters.AddWithValue("@des", "Producto en Mal Estado");
                    cmd.Parameters.AddWithValue("@tmovimiento", "Resta");
                    cmd.Parameters.AddWithValue("@est", "A");
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into movimiento(fecha_ingreso, descripcion, tipo_movimiento, estado) VALUES (@fecha,@des,@tmovimiento,@est);";
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("ddd MMM yyyy"));
                    fecha = DateTime.Now.ToString("ddd MMM YYYY");
                    cmd.Parameters.AddWithValue("@des", "Producto en Mal Estado");
                    cmd.Parameters.AddWithValue("@tmovimiento", "Resta");
                    cmd.Parameters.AddWithValue("@est", "A");
                }

                using (SqlCommand cmd = new SqlCommand())
                {   
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select idingreso  from movimiento where fecha='@fecha' and tipo_movimiento ='Resta' and descripcion='Mal Estado';";
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select idproducto  from producto where descripicion='@des';";
                    cmd.Parameters.AddWithValue("@des", fecha);
                    idpr = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into det_movimiento(cantidad, idProducto, idIngreso) VALUES (@cant,@idPr,@idIng);";
                    cmd.Parameters.AddWithValue("@cant", cantidad);
                    cmd.Parameters.AddWithValue("@idPr", idpr);
                    cmd.Parameters.AddWithValue("@idIng", id);
                }
            }
        }
    }
}