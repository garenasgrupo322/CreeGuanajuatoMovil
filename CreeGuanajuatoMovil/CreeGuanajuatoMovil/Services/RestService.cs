﻿using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CreeGuanajuatoMovil.Helpers;

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
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
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

        public async Task<List<Seccion>> ObtieneSeccionales()
        {
            List<Seccion> seccions = new List<Seccion>();

            try
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Seccionales");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    seccions = JsonConvert.DeserializeObject<List<Seccion>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return seccions;
        }

        public async Task<List<Usuario>> ObtieneUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Users");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return usuarios;
        }
        #endregion

        public async Task<Registro> GuardaRegistroAsync(Registro registro)
        {
            var uri = new Uri(Constants.RestUrl + "Registroes");
            Registro result = new Registro();
            try
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var postDriver = JsonConvert.SerializeObject(registro);
                var content = new StringContent(postDriver, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                var request = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Registro>(request);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return result;
        }

        public async Task<List<Registro>> ObtieneRegistrosFiltradosAsync(int id_estado, int id_municipio, int id_colonia, int id_escolaridad,
            int id_necesidad, string busqueda)
        {
            List<Registro> registros = new List<Registro>();

            try
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var uri = new Uri(Constants.RestUrl + "Registroes/GetReport");
                var postDriver = JsonConvert.SerializeObject(new {
                    id_estado = id_estado,
                    id_municipio = id_municipio,
                    id_colonia = id_colonia,
                    id_escolaridad = id_escolaridad,
                    id_necesidad = id_necesidad,
                    busqueda = busqueda
                });
                var content = new StringContent(postDriver, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                /*client.DefaultRequestHeaders
                    .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));*/
                response = await client.PostAsync(uri, content);


                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    registros = JsonConvert.DeserializeObject<List<Registro>>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return registros;
        }

        public async Task<GoogleAPI> ObtieneUbicacion(double lat, double lng)
        {
            GoogleAPI registros = new GoogleAPI();

            string[] parametros = new string[3];
            parametros[0] = lat.ToString();
            parametros[1] = lng.ToString();
            parametros[2] = Constants.googleKey;

            try
            {
                HttpResponseMessage response = null;
                var uri = new Uri(string.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng={0},{1}&key={2}", parametros));
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    registros = JsonConvert.DeserializeObject<GoogleAPI>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return registros;
        }

        public class loginResult
        {
            public string response { get; set; }
        }

        public async Task<string> IniciarSesion(string usuario, string contrasena)
        {
            var uri = new Uri(Constants.RestUrl + "Auth/Login");

            loginResult result = new loginResult();
            try
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var postDriver = JsonConvert.SerializeObject(new
                {
                    username = usuario,
                    password = contrasena
                });

                var content = new StringContent(postDriver, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);    

                var request = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<loginResult>(request);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return result.response;
        }

        public async Task<bool> IniciarSesionToken()
        {
            bool estatus = false;
            var uri = new Uri(Constants.RestUrl + "Auth/LoginToken");

            try
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = null;
                response = await client.GetAsync(uri);

                estatus = response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return estatus;
        }

        public async Task<Usuario> ObtieneUsuarioPerfil()
        {
            Usuario usuarios = new Usuario();

            try
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Users/Perfil");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    usuarios = JsonConvert.DeserializeObject<Usuario>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return usuarios;
        }

        public async Task<string> ObtieneLegales()
        {
            string legales = string.Empty;

            try
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = null;
                var uri = new Uri(Constants.RestUrl + "Legales");
                response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var request = await response.Content.ReadAsStringAsync();
                    legales = JsonConvert.DeserializeObject<string>(request);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return legales;
        }

        public async Task setImageProfiler(string imageBase64)
        {
            try
            {
                client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue();
                client.DefaultRequestHeaders.CacheControl.NoCache = true;
                client.DefaultRequestHeaders
                        .Authorization = new AuthenticationHeaderValue("Bearer", Settings.AccessToken);
                client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var uri = new Uri("https://garenas-developer.azurewebsites.net/Api/Users/setImage");

                var postDriver = JsonConvert.SerializeObject(new
                {
                    token = Settings.AccessToken,
                    image = imageBase64
                });

                var content = new StringContent(postDriver, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
    }
}
