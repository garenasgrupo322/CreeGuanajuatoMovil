using CreeGuanajuatoMovil.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreeGuanajuatoMovil.Services
{
    public interface IRestService
    {
        #region Catalogs
        Task<List<Estado>> ObtieneEstados();
        Task<List<Municipio>> ObtieneMunicipios();
        Task<List<Colonia>> ObtieneColonias();
        Task<List<Direccion>> ObtieneDirecciones();
        Task<List<Necesidad>> ObtieneNecesidades();
        Task<List<Escolaridad>> ObtieneEscolaridadAsync();
        Task<List<EstadoCivil>> ObtieneEstadoCivilAsync();
        Task<List<Seccion>> ObtieneSeccionales();
        Task<string> ObtieneLegales();
        Task<List<Usuario>> ObtieneUsuario();
        #endregion

        Task<Usuario> ObtieneUsuarioPerfil();

        Task<Registro> GuardaRegistroAsync(Registro registro);

        Task<List<Registro>> ObtieneRegistrosFiltradosAsync(int id_estado, int id_municipio, int id_colonia, int id_escolaridad, int id_necesidad, string busqueda);

        Task<GoogleAPI> ObtieneUbicacion(double lat, double lng);

        Task<string> IniciarSesion(string usuario, string contrasena);

        Task<bool> IniciarSesionToken();

        Task setImageProfiler(string imageBase64);
    }
}
