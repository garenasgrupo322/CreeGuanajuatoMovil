using System;
using System.Collections.Generic;
using System.Text;

namespace CreeGuanajuatoMovil.Models
{
    /// <summary>
    /// Modelo para las direcciones
    /// </summary>
    public class Direccion
    {
        public int id_direccion { get; set; }

        public int id_colonia { get; set; }

        public string calle { get; set; }
        
        public string numero { get; set; }
    }
}
