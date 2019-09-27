using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Objetos
{
    public class ObjProducto
    {
        public int idproducto { get; set; }
        public string descripcion { get; set; }
        public double precio_costo { get; set; }
        public double precio_venta { get; set; }
        public string fecha_ingreso { get; set; }
        public string fecha_modificacion { get; set; }
        public int cantidad { get; set; }

        public ObjProducto(int idproducto, string descripcion, double precio_costo, double precio_venta, string fecha_ingreso, string fecha_modificacion)
        {
            this.idproducto = idproducto;
            this.descripcion = descripcion;
            this.precio_costo = precio_costo;
            this.precio_venta = precio_venta;
            this.fecha_ingreso = fecha_ingreso;
            this.fecha_modificacion = fecha_modificacion;
        }
        public ObjProducto(int idproducto, string descripcion, double precio_costo, double precio_venta, string fecha_ingreso, string fecha_modificacion, int cantidad)
        {
            this.idproducto = idproducto;
            this.descripcion = descripcion;
            this.precio_costo = precio_costo;
            this.precio_venta = precio_venta;
            this.fecha_ingreso = fecha_ingreso;
            this.fecha_modificacion = fecha_modificacion;
            this.cantidad = cantidad;
        }

        public ObjProducto()
        {
        }
    }
}