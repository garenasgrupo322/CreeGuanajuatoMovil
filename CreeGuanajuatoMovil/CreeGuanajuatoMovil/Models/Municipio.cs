using System;
using System.Collections.Generic;
using System.Text;

namespace CreeGuanajuatoMovil.Models
{
    /// <summary>
    /// Modelo para los municipios
    /// </summary>
    public class Municipio
    {
        public int id_municipio { get; set; }

        public int id_estado { get; set; }

        public string nombre_municipio { get; set; }
    }
}
