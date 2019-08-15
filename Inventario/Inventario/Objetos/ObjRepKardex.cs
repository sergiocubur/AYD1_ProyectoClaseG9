using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Objetos
{
    public class ObjRepKardex
    {
        public string fechaIngreso { get; set; }
        public string descripcion { get; set; }
        public int cantIngreso { get; set; }
        public int cantEgreso { get; set; }
        public double precioUnitario { get; set; }
        public string fechaEgreso { get; set; }

        public ObjRepKardex(string fechaI, string desc, int cantI, int cantE, double precioU, string fechaE)
        {
            fechaIngreso = fechaI;
            descripcion = desc;
            cantIngreso = cantI;
            cantEgreso = cantE;
            precioUnitario = precioU;
            fechaEgreso = fechaE;
        }
    }
}