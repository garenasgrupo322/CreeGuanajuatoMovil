using System;
using System.Collections.Generic;
using System.Text;

namespace CreeGuanajuatoMovil.Models
{
    /// <summary>
    /// Modelo para las colonias
    /// </summary>
    public class Colonia
    {
        public int id_colonia { get; set; }

        public int id_municipio { get; set; }

        public string nombre_colonia { get; set; }

        public string codigo_postal { get; set; }
    }
}
