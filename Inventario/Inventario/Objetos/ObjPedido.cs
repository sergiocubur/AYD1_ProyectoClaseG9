using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Objetos
{
    public class ObjPedido
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string cliente { get; set; }
        public int estado { get; set; }
        public double total { get; set; }
        public int idpais { get; set; }
        public int idusuario { get; set; }
        public string correlativo { get; set; }
        public string nit { get; set; }

        public ObjPedido(int id, string fecha, string cliente, int estado, double total, int idpais, int idusuario, string correlativo, string nit)
        {
            this.id = id;
            this.fecha = fecha;
            this.cliente = cliente;
            this.estado = estado;
            this.total = total;
            this.idpais = idpais;
            this.idusuario = idusuario;
            this.correlativo = correlativo;
            this.nit = nit;
        }
        public ObjPedido()
        {
            this.id = -1;
            this.fecha = "";
            this.cliente = "";
            this.estado = 0;
            this.total = 0;
            this.idpais = -1;
            this.idusuario = -1;
            this.correlativo = "";
            this.nit = "";
        }
    }
}