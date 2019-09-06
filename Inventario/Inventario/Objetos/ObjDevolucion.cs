using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Objetos
{
    public class ObjDevolucion
    {
        public int idingreso { get; set; }
        public string fecha_ingreso { get; set; }
        public string descripcion { get; set; }
        public string tipo_movimiento { get; set; }
        public string estado { get; set; }
        public string usuario_ingresa { get; set; }

        public ObjDevolucion(int idingreso, string fecha_ingreso, string descripcion, string estado, string usuario_ingresa)
        {
            this.idingreso = idingreso;
            this.fecha_ingreso = fecha_ingreso;
            this.descripcion = descripcion;
            this.tipo_movimiento = "DEVOLUCION";
            this.estado = estado;
            this.usuario_ingresa = usuario_ingresa;
        }

        public ObjDevolucion() { }
    }
}