using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Objetos
{
    public class ObjRepKardex
    {
        /*
       +tipo       (ingreso|egreso (nacionales|internacionales)(entradas|salidas)
       +cliente/proveedor
       +fecha
       +cantidad
       +descripcion
       +total
       +pais
       +precio costo
        */
        public string tipo { get; set; }
        public string cliente_proveedor { get; set; }
        public string fecha { get; set; }
        public string cantidad { get; set; }
        public string descripcion { get; set; }
        public string total { get; set; }
        public string pais { get; set; }
        public string costo { get; set; }

        public ObjRepKardex()
        {
            tipo = "-";
            cliente_proveedor = "-";
            fecha = "-";
            cantidad = "-";
            descripcion = "-";
            total = "-";
            pais = "-";
            costo = "-";

        }
    }
}