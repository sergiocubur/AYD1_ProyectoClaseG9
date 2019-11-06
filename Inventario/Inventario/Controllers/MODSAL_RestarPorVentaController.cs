using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.Objetos;
using System.Configuration;

namespace Inventario.Controllers
{
    public class MODSAL_RestarPorVentaController : Controller
    {
        static string credenciales = "server=.; database=AnalisisP1 ; integrated security = true";
        // GET: MODSAL_RestarPorVenta
        public ActionResult vMODSAL_RestarPorVenta()
        {
            
            return View();
        }
        public ActionResult addDatosCliente(string nombre, string pais, string nit)
        {
            Session["CLIENTE"] = nombre;
            Session["PAIS"] = pais;
            Session["NIT"] = nit;

            return RedirectToAction("vMODSAL_RestarPorVenta", "MODSAL_RestarPorVenta");
        }
        
        [HttpGet]
        public List<ObjProducto> getProductos()
        {
            List<ObjProducto> lista = new List<ObjProducto>();
            string consulta = "select * from producto;";
            DataTable dt = consultarBD(consulta);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ObjProducto nuevo = new ObjProducto();
                        nuevo.idproducto = Int16.Parse(row["idproducto"].ToString());
                        nuevo.descripcion = row["descripcion"].ToString();
                        nuevo.precio_costo = Double.Parse(row["precio_costo"].ToString());
                        nuevo.precio_venta = Double.Parse(row["precio_venta"].ToString());
                        nuevo.fecha_ingreso = row["fecha_ingreso"].ToString();
                        nuevo.fecha_modificacion = row["fecha_modificacion"].ToString();
                        nuevo.cantidadBD = Int16.Parse(row["cantidad"].ToString());
                        lista.Add(nuevo);
                    }
                }
            }
            return lista;
        }
        [HttpGet]
        public List<ObjPais> getPaises()
        {
            List<ObjPais> lista = new List<ObjPais>();
            string consulta = "select idpais,nombre from pais";
            DataTable dt = consultarBD(consulta);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ObjPais nuevo = new ObjPais();
                        nuevo.id = Int16.Parse(row["idpais"].ToString());
                        nuevo.nombre = row["nombre"].ToString();
                        lista.Add(nuevo);
                    }
                }
            }
            return lista;
        }
        public string restando(int cantProducto, int cantIngresada, int producto)
        {
            if (cantIngresada < 0)
            {
                return "No se aceptan numeros negativos";
            }
            else if (cantIngresada > cantProducto)
            {
                return "No se cuenta con el producto suficiente para la venta,\n Cantidad de producto disponible: " + cantProducto;
            }
            else
            {
                int resta = cantProducto - cantIngresada;
                actualizarBD(producto, resta);
            }
            return "Yes";
        }
        public ActionResult restarPorVenta(int producto, int cantidad)
        {
            Session["ERROR_RESTA"] = null;
            if (cantidad == 0)
            {
                Session["ERROR_RESTA"] = "Ingrese una cantidad";
                return RedirectToAction("vMODSAL_RestarPorVenta", "MODSAL_RestarPorVenta");
            }

            foreach (ObjProducto prod in Session["LOG_PRODUCTOS"] as List<ObjProducto>)
            {
                if (producto == prod.idproducto)
                {
                    Session["ERROR_RESTA"] = restando(prod.cantidad, cantidad, producto);
                    return RedirectToAction("vMODSAL_RestarPorVenta", "MODSAL_RestarPorVenta");
                }
            }
            return RedirectToAction("vMODSAL_RestarPorVenta", "MODSAL_RestarPorVenta");
        }
        public ActionResult vMODSAL_VerProductos()
        {
            return View();
        }

        public ActionResult mostrandoProductos()
        {
            return RedirectToAction("vMODSAL_VerProductos", "MODSAL_RestarPorVenta");
        }

        public ActionResult addCarretilla(int cantidad, int producto)
        {
            List<ObjProducto> carretilla = Session["CARRETILLA"] as List<ObjProducto>;
            foreach(ObjProducto a in getProductos())
            {
                if(a.idproducto == producto)
                {
                    ObjProducto n = new ObjProducto(cantidad, a.precio_venta, a.idproducto, a.descripcion, a.precio_venta * cantidad,a.cantidadBD);
                    carretilla.Add(n);
                    Session["CARRETILLA"] = carretilla;
                    Session["TOTAL"] = Double.Parse(Session["TOTAL"].ToString()) + a.precio_venta * cantidad;
                }
            }
            return RedirectToAction("vMODSAL_RestarPorVenta", "MODSAL_RestarPorVenta");
        }
        public ActionResult cancelarVenta()
        {
            Session["CLIENTE"] = null;
            Session["PAIS"] = null;
            Session["NIT"] = null;
            Session["CARRETILLA"] = null;
            Session["TOTAL"] = 0;
            return RedirectToAction("vMODINI_Logeado", "MODINI_Logeado");
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

        public static bool actualizarBD(int idProducto, int cantidad)
        {
            SqlConnection conexion = new SqlConnection(credenciales);
            SqlDataAdapter adaptador = new SqlDataAdapter();
            try
            {
                conexion.Open();
                string sql = "update producto SET cantidad = @param1 where idproducto = @param2";
                using (SqlCommand cmdU = new SqlCommand(sql, conexion))
                {
                    cmdU.Parameters.Add("@param1", SqlDbType.Int).Value = cantidad;
                    cmdU.Parameters.Add("@param2", SqlDbType.Int).Value = idProducto;
                    cmdU.CommandType = CommandType.Text;
                    cmdU.ExecuteNonQuery();
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                Trace.WriteLine(ex.ToString());
                return false;
            }
            return true;
        }

        public ActionResult registrarVenta()
        {
            string insert = "insert into pedido(fecha_pedido,nombre_cliente,estado,total,nit,pais_idpais,usuario_idusuario, correlativo) "+
                "values(GETDATE(),'"+Session["CLIENTE"].ToString()+ "',1," + Session["TOTAL"].ToString() + "," + Session["NIT"].ToString() + "," + Session["PAIS"].ToString() + "," + Session["idU"].ToString() + ",0)";
            consultarBD(insert);

            ObjPedido pedido = getPedido();
            if( pedido != null)
            {
                List<ObjProducto> detallePedido = Session["CARRETILLA"] as List<ObjProducto>;
               foreach(ObjProducto a in detallePedido)
                {
                    if(a.cantidadBD > a.cantidad)
                    {
                        insert = "insert into det_pedido(cantidad,precio,pedido_idpedido,producto_idproducto)" +
                        "values (" + a.cantidad + "," + a.precioUnitario + "," + pedido.id + "," + a.idproducto + ")";
                        consultarBD(insert);
                        actualizarBD(a.idproducto, a.cantidadBD - a.cantidad);
                    }
                    
                }

                Session["CLIENTE"] = null;
                Session["PAIS"] = null;
                Session["NIT"] = null;
                Session["CARRETILLA"] = null;
                Session["TOTAL"] = 0;
            }



            return RedirectToAction("vMODINI_Logeado", "MODINI_Logeado");
        }

        [HttpGet]
        public ObjPedido getPedido()
        {
            string consulta = "select top(1) idpedido,fecha_pedido,nombre_cliente,total,pais_idpais,usuario_idusuario,correlativo,nit from pedido order by idpedido desc";
            DataTable dt = consultarBD(consulta);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ObjPedido n = new ObjPedido();
                        n.id = Int16.Parse(row["idpedido"].ToString());
                        n.fecha = row["fecha_pedido"].ToString();
                        n.cliente = row["nombre_cliente"].ToString();
                        n.total = Double.Parse(row["total"].ToString());
                        n.idpais = Int16.Parse(row["pais_idpais"].ToString());
                        n.idusuario = Int16.Parse(row["usuario_idusuario"].ToString());
                        n.correlativo = row["correlativo"].ToString();
                        n.nit = row["nit"].ToString();
                        return n;
                    }
                }


            }
            return null;
        }



    }
}