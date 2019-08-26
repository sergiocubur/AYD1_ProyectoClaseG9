﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Objetos
{
    public class ObjMuestra
    {
        public int idingreso { get; set; }
        public string fecha_ingreso { get; set; }
        public string descripcion { get; set; }
        public string tipo_movimiento { get; set; }
        public string estado { get; set; }
        public string usuario_ingresa { get; set; }
        public string factura_asociada { get; set; }

        public ObjMuestra(int idingreso, string factura_asociada, string fecha_ingreso, string descripcion, string estado, string usuario_ingresa)
        {
            this.idingreso = idingreso;
            this.factura_asociada = factura_asociada;
            this.fecha_ingreso = fecha_ingreso;
            this.descripcion = descripcion;
            this.tipo_movimiento = "ING_MUESTRA";
            this.estado = estado;
            this.usuario_ingresa = usuario_ingresa;
        }

        public ObjMuestra()
        {

        }
    }
}