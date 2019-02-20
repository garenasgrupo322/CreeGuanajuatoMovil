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

        #endregion

    }
}
