using System;
using System.Collections.Generic;
using System.Text;

namespace CreeGuanajuatoMovil.Models
{
    public class Beneficiario
    {
        public int id_beneficiario { get; set; }

        public int id_usuario { get; set; }

        public int id_direccion { get; set; }

        public int id_necesidad { get; set; }

        public string edad { get; set; }

        public string ine { get; set; }

        public string escolaridad { get; set; }

        public string estado_civil { get; set; }

        public string seccional { get; set; }

        public string hijos_numero { get; set; }
    }
}
