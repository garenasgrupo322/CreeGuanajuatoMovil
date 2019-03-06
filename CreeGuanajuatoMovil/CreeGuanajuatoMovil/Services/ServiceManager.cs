using CreeGuanajuatoMovil.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreeGuanajuatoMovil.Services
{
    public class ServiceManager
    {
        IRestService restService;

        public ServiceManager(IRestService service)
        {
            restService = service;
        }

        #region Catalogs

        public Task<List<Estado>> ObtieneEstados()
        {
            return restService.ObtieneEstados();
        }

        public Task<List<Municipio>> ObtieneMunicipios()
        {
            return restService.ObtieneMunicipios();
        }

        public Task<List<Colonia>> ObtieneColonias()
        {
            return restService.ObtieneColonias();
        }

        public Task<List<Direccion>> ObtieneDirecciones()
        {
            return restService.ObtieneDirecciones();
        }

        public Task<List<Necesidad>> ObtieneNecesidades()
        {
            return restService.ObtieneNecesidades();
        }

        public Task<List<Escolaridad>> ObtieneEscolaridadAsync()
        {
            return restService.ObtieneEscolaridadAsync();
        }

        public Task<List<EstadoCivil>> ObtieneEstadoCivilAsync()
        {
            return restService.ObtieneEstadoCivilAsync();
        }

        public Task<List<Usuario>> ObtieneUsuario()
        {
            return restService.ObtieneUsuario();
        }

        #endregion

        public Task<Registro> GuardaRegistroAsync(Registro registro)
        {
            return restService.GuardaRegistroAsync(registro);
        }

        public Task<List<Registro>> ObtieneRegistrosFiltradosAsync(int id_estado, int id_municipio, int id_colonia, int id_escolaridad, int id_necesidad, string busqueda)
        {
            return restService.ObtieneRegistrosFiltradosAsync(id_estado, id_municipio, id_colonia, id_escolaridad, id_necesidad, busqueda);
        }

        public Task<GoogleAPI> ObtieneUbicacion(double lat, double lng)
        {
            return restService.ObtieneUbicacion(lat, lng);
        }

        public Task<Usuario> IniciarSesion(string usuario, string contrasena)
        {
            return restService.IniciarSesion(usuario, contrasena);
        }

    }
}
