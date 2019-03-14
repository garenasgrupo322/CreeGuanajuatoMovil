using System;
namespace CreeGuanajuatoMovil.Models
{
    public class Registro
    {
        public int id_registro { get; set; }

        public string nombre { get; set; }

        public string apellido_paterno { get; set; }

        public string apellido_materno { get; set; }

        public string INE { get; set; }

        public string email { get; set; }

        public DateTime fecha_nacimiento { get; set; }

        public int numero_hijos { get; set; }

        public Estado Estado { get; set; }

        public Municipio Municipio { get; set; }

        public Colonia Colonia { get; set; }

        public Direccion Direccion { get; set; }

        public Escolaridad Escolaridad { get; set; }

        public EstadoCivil EstadoCivil { get; set; }

        public Necesidad Necesidad { get; set; }

        public Seccion Seccion { get; set; }    

        public double longitud { get; set; }

        public double latitud { get; set; }

        public string nombre_completo { get; set; }

        public string busqueda { get; set; }
    }
}
