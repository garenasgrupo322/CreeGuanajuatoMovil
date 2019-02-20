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
        #endregion
    }
}
