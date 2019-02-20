using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace CreeGuanajuatoMovil.Services
{
    public class RestService : IRestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
        }

        #region catálogos   

        /// <summary>
        /// Obtiene el catalogo de estados del ws
        /// </summary>
        /// <returns>Lista de estados</returns>
        public async Task<List<Estado>> ObtieneEstados()
        {
            List<Estado> estados = new List<Estado>();

            try
            {
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Estados");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    estados = JsonConvert.DeserializeObject<List<Estado>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return estados;
        }

        /// <summary>
        /// Obtiene el catalogo de municipios del ws
        /// </summary>
        /// <returns>Lista de municipios</returns>
        public async Task<List<Municipio>> ObtieneMunicipios()
        {
            List<Municipio> municipios = new List<Municipio>();

            try
            {
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Municipios");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    municipios = JsonConvert.DeserializeObject<List<Municipio>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return municipios;
        }

        /// <summary>
        /// Obtiene el catalogo de colonias del ws
        /// </summary>
        /// <returns>Lista de colonias</returns>
        public async Task<List<Colonia>> ObtieneColonias()
        {
            List<Colonia> colonias = new List<Colonia>();

            try
            {
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Colonias");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    colonias = JsonConvert.DeserializeObject<List<Colonia>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return colonias;
        }

        /// <summary>
        /// Obtiene el catalogo de direcciones del ws
        /// </summary>
        /// <returns>Lista de direcciones</returns>
        public async Task<List<Direccion>> ObtieneDirecciones()
        {
            List<Direccion> direcciones = new List<Direccion>();

            try
            {
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Direcciones");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    direcciones = JsonConvert.DeserializeObject<List<Direccion>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return direcciones;
        }

        /// <summary>
        /// Obtiene el catalogo de necesidades del ws
        /// </summary>
        /// <returns>Lista de necesidades</returns>
        public async Task<List<Necesidad>> ObtieneNecesidades()
        {
            List<Necesidad> necesidades = new List<Necesidad>();

            try
            {
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Necesidades");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    necesidades = JsonConvert.DeserializeObject<List<Necesidad>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return necesidades;
        }

        /// <summary>
        /// Obtiene la escolaridad del ws
        /// </summary>
        /// <returns>Lista de escolaridad</returns>
        public async Task<List<Escolaridad>> ObtieneEscolaridadAsync()
        {
            List<Escolaridad> escolaridads = new List<Escolaridad>();

            try
            {
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Escolaridades");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    escolaridads = JsonConvert.DeserializeObject<List<Escolaridad>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return escolaridads;
        }

        /// <summary>
        /// Obtiene los estados civil del ws 
        /// </summary>
        /// <returns>Lista de estados civiles</returns>
        public async Task<List<EstadoCivil>> ObtieneEstadoCivilAsync()
        {
            List<EstadoCivil> estadoCivils = new List<EstadoCivil>();

            try
            {
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "EstadoCiviles");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    estadoCivils = JsonConvert.DeserializeObject<List<EstadoCivil>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return estadoCivils;
        }

        #endregion
    }
}
