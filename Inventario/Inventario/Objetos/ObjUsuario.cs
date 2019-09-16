using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Objetos
{
    public class ObjUsuario
    {
        public int idusuario { get; set; }
        public string dpi { get; set; }
        public string apellido { get; set; }
        public string tipo_usuario { get; set; }
        public char estado { get; set; }
        public string fecha_alta { get; set; }
        public string codUsuario { get; set; }
        public string password { get; set; }

        public ObjUsuario(int idproducto, string dpi,string apellido, string tipo_usuario,char estado,string fecha_alta,string codUsuario,string password)
        {
            this.idusuario = idusuario;
            this.dpi = dpi;
            this.apellido = apellido;
            this.tipo_usuario = tipo_usuario;
            this.estado = estado;
            this.fecha_alta = fecha_alta;
            this.codUsuario = codUsuario;
            this.password = password;
        }

        public ObjUsuario()
        {
        }
    }
}