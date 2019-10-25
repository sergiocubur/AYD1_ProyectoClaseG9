using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Objetos
{
    public class ObjRestaxVenta
    {
        public string fechaVenta { get; set; }
        public string descripcion { get; set; }        
        public double precio { get; set; }
        public int cantidad { get; set; }
        public string nombre { get; set; }
        public double total { get; set; }

        public ObjRestaxVenta(string fechaV, string desc, double prec, int cant, string nomb, double tot)
        {
            fechaVenta = fechaV;
            descripcion = desc;
            precio = prec;
            cantidad = cant;
            nombre = nomb;
            total = tot;
        }
    }
}