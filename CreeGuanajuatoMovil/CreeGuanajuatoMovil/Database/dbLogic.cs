using CreeGuanajuatoMovil.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CreeGuanajuatoMovil.Database
{
    /// <summary>
    /// Clase para la definición de la base de datos en sqlite
    /// </summary>
    public class dbLogic
    {
        /// <summary>
        /// Variable que define la conexión a la base de datos
        /// </summary>
        readonly SQLiteAsyncConnection database;

        /// <summary>
        /// Cramos la base de datos y tablas.
        /// </summary>
        /// <param name="dbPath"></param>
        public dbLogic(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);

            database.CreateTableAsync<Estado>().Wait();
            database.CreateTableAsync<Municipio>().Wait();
            database.CreateTableAsync<Colonia>().Wait();
            database.CreateTableAsync<Direccion>().Wait();
            database.CreateTableAsync<Necesidad>().Wait();
            database.CreateTableAsync<Escolaridad>().Wait();
            database.CreateTableAsync<EstadoCivil>().Wait();
        }

        /// <summary>
        /// Elimina todas las tablas de la base de datos
        /// </summary>
        public void dropTables() {
            database.ExecuteAsync("DELETE FROM Estado");
            database.ExecuteAsync("DELETE FROM Municipio");
            database.ExecuteAsync("DELETE FROM Colonia");
            database.ExecuteAsync("DELETE FROM Direccion");
            database.ExecuteAsync("DELETE FROM Necesidad");
            database.ExecuteAsync("DELETE FROM Escolaridad");
            database.ExecuteAsync("DELETE FROM EstadoCivil");
        }

        #region "Estado"

        /// <summary>
        /// Guarda un estado en la base de datos
        /// </summary>
        /// <param name="estado">Modelo de estado</param>
        /// <returns>Identificador del estado guardado</returns>
        public Task<int> GuardaEstado(Estado estado)
        {
            return database.InsertAsync(estado);
        }

        /// <summary>
        /// Guarda lista de estados
        /// </summary>
        /// <param name="estados">Lista de estados</param>
        /// <returns></returns>
        public async Task GuardaEstado(List<Estado> estados)
        {
            try
            {
                foreach (Estado item in estados) {
                    await database.InsertAsync(item);
                }
            }
            catch(Exception ex) {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los estados
        /// </summary>
        /// <returns>Lista de estados</returns>
        public Task<List<Estado>> ObtieneEstados()
        {
            return database.Table<Estado>().ToListAsync();
        }

        /// <summary>
        /// Obtiene los registros de estados por busqueda por texto
        /// </summary>
        /// <param name="busqueda">Texto de busqueda</param>
        /// <returns>Lista de estados</returns>
        public Task<List<Estado>> ObtieneEstadosByText(string busqueda)
        {
            return database.Table<Estado>().Where(m => m.nombre_estado.Contains(busqueda)).ToListAsync();
        }

        /// <summary>
        /// Obtiene un estado
        /// </summary>
        /// <param name="id_estado">Identificador del estado</param>
        /// <returns>Retorna un modelo de estado</returns>
        public Task<Estado> ObtieneEstados(int id_estado)
        {
            return database.Table<Estado>().Where(i => i.id_estado == id_estado).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Modifica un estado
        /// </summary>
        /// <param name="estado">Modelo de estado</param>
        /// <returns>Identificador del estado</returns>
        public Task<int> ModificaEstados(Estado estado)
        {
            return database.UpdateAsync(estado);
        }

        /// <summary>
        /// Elimina un estado
        /// </summary>
        /// <param name="estado">Modelo del estado</param>
        /// <returns>Identificador del estado</returns>
        public Task<int> EliminaEstados(Estado estado)
        {
            return database.DeleteAsync(estado);
        }

        #endregion

        #region "Municipio"

        /// <summary>
        /// Guarda un municipio
        /// </summary>
        /// <param name="municipio">Modelo del municipio</param>
        /// <returns>Identificador del municipio</returns>
        public Task<int> GuardaMunicipio(Municipio municipio)
        {
            return database.InsertAsync(municipio);
        }

        /// <summary>
        /// Guarda municipios
        /// </summary>
        /// <param name="municipios">Lista de municipios</param>
        /// <returns></returns>
        public async Task GuardaMunicipio(List<Municipio> municipios)
        {
            try
            {
                foreach (Municipio item in municipios) {
                    await database.InsertAsync(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los municipios
        /// </summary>
        /// <returns>Lista de municipios</returns>
        public Task<List<Municipio>> ObtieneMunicipio()
        {
            return database.Table<Municipio>().ToListAsync();
        }

        /// <summary>
        /// Obtiene un municipio
        /// </summary>
        /// <param name="id_municipio">Identificador del municipio</param>
        /// <returns>Modelo del municipio</returns>
        public Task<Municipio> ObtieneMunicipio(int id_municipio)
        {
            return database.Table<Municipio>().Where(i => i.id_municipio == id_municipio).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Obtiene los municipios de un estado
        /// </summary>
        /// <param name="id_estado">Identificador del estado</param>
        /// <returns>Lista de municipios</returns>
        public Task<List<Municipio>> ObtieneMunicipioPorEstado(int id_estado)
        {
            return database.Table<Municipio>().Where(i => i.id_estado == id_estado).ToListAsync();
        }

        /// <summary>
        /// Obtienes the municipio por estado and by text.
        /// </summary>
        /// <returns>The municipio por estado and by text.</returns>
        /// <param name="id_estado">Identifier estado.</param>
        /// <param name="busqueda">Busqueda.</param>
        public Task<List<Municipio>> ObtieneMunicipioPorEstadoAndByText(int id_estado, string busqueda)
        {
            return database.Table<Municipio>().Where(i => i.id_estado == id_estado && i.nombre_municipio.Contains(busqueda)).ToListAsync();
        }

        /// <summary>
        /// Modifica un municipio
        /// </summary>
        /// <param name="municipio">Modelo del municipio</param>
        /// <returns>Identificador del municipio</returns>
        public Task<int> ModificaMunicipio(Municipio municipio)
        {
            return database.UpdateAsync(municipio);
        }

        /// <summary>
        /// Elimina un municipio
        /// </summary>
        /// <param name="municipio">Modelo del municipio</param>
        /// <returns>Identificador del municipio</returns>
        public Task<int> EliminaMunicipio(Municipio municipio)
        {
            return database.DeleteAsync(municipio);
        }

        #endregion

        #region "Colonia"

        /// <summary>
        /// Guarda una colonia
        /// </summary>
        /// <param name="colonia">Modelo de la colonia</param>
        /// <returns>Identificador de la colonia</returns>
        public Task<int> GuardaColonia(Colonia colonia)
        {
            return database.InsertAsync(colonia);
        }

        /// <summary>
        /// Guarda colonias
        /// </summary>
        /// <param name="colonias">Lista de colonias</param>
        /// <returns></returns>
        public async Task GuardaColonia(List<Colonia> colonias)
        {
            try
            {
                foreach (Colonia item in colonias) {
                    await database.InsertAsync(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todas las colonias
        /// </summary>
        /// <returns>Lista de colonias</returns>
        public Task<List<Colonia>> ObtieneColonias()
        {
            return database.Table<Colonia>().ToListAsync();
        }

        /// <summary>
        /// Obtiene una colonia
        /// </summary>
        /// <param name="id_colonia">Identificador de la colonia</param>
        /// <returns>Modelo de colonia</returns>
        public Task<Colonia> ObtieneColonias(int id_colonia)
        {
            return database.Table<Colonia>().Where(i => i.id_colonia == id_colonia).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Ontiene colonias por municipio
        /// </summary>
        /// <param name="id_municipio">Identificador del municipio</param>
        /// <returns>Lista de colonias</returns>
        public Task<List<Colonia>> ObtieneColoniasPorMunicipio(int id_municipio)
        {
            return database.Table<Colonia>().Where(i => i.id_municipio == id_municipio).ToListAsync();
        }

        /// <summary>
        /// Obtienes the colonias por municipio by text.
        /// </summary>
        /// <returns>The colonias por municipio by text.</returns>
        /// <param name="id_municipio">Identifier municipio.</param>
        /// <param name="busqueda">Busqueda.</param>
        public Task<List<Colonia>> ObtieneColoniasPorMunicipioByText(int id_municipio, string busqueda)
        {
            return database.Table<Colonia>().Where(i => i.id_municipio == id_municipio && i.nombre_colonia.Contains(busqueda)).ToListAsync();
        }

        /// <summary>
        /// Modifica una colonia
        /// </summary>
        /// <param name="colonia">Modelo de colonia</param>
        /// <returns>Identificador de la colonia</returns>
        public Task<int> ModificaColonia(Colonia colonia)
        {
            return database.UpdateAsync(colonia);
        }

        /// <summary>
        /// Elimina una colonia
        /// </summary>
        /// <param name="colonia">Modelo de colonia</param>
        /// <returns>Identificador de la colonia</returns>
        public Task<int> EliminaColonia(Colonia colonia)
        {
            return database.DeleteAsync(colonia);
        }

        #endregion

        #region "Direccion"

        /// <summary>
        /// Guarda una dirección
        /// </summary>
        /// <param name="direccion">Modelo de dirección</param>
        /// <returns>Identificador de la dirección</returns>
        public Task<int> GuardaDireccion(Direccion direccion)
        {
            return database.InsertAsync(direccion);
        }

        /// <summary>
        /// Guarda direcciones
        /// </summary>
        /// <param name="direcciones">Lista de direcciones</param>
        /// <returns></returns>
        public async Task GuardaDireccion(List<Direccion> direcciones)
        {
            try
            {
                foreach (Direccion item in direcciones) {
                    await database.InsertAsync(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todas las direcciones
        /// </summary>
        /// <returns>Lista de direcciones</returns>
        public Task<List<Direccion>> ObtieneDirecciones()
        {
            return database.Table<Direccion>().ToListAsync();
        }

        /// <summary>
        /// Obtiene una dirección
        /// </summary>
        /// <param name="id_direccion">Identificador de la direccón</param>
        /// <returns>Modelo de direcciones</returns>
        public Task<Direccion> ObtieneDirecciones(int id_direccion)
        {
            return database.Table<Direccion>().Where(i => i.id_direccion == id_direccion).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Obtiene las direcciones por colonia
        /// </summary>
        /// <param name="id_colonia">Identificador de la colonia</param>
        /// <returns>Lista de direcciones</returns>
        public Task<List<Direccion>> ObtieneDireccionesPorColonia(int id_colonia)
        {
            return database.Table<Direccion>().Where(i => i.id_colonia == id_colonia).ToListAsync();
        }

        /// <summary>
        /// Obtienes the direcciones por colonia by text.
        /// </summary>
        /// <returns>The direcciones por colonia by text.</returns>
        /// <param name="id_colonia">Identifier colonia.</param>
        /// <param name="busqueda">Busqueda.</param>
        public Task<List<Direccion>> ObtieneDireccionesPorColoniaByText(int id_colonia, string busqueda)
        {
            return database.Table<Direccion>().Where(i => i.id_colonia == id_colonia && (i.calle.Contains(busqueda) || i.numero.Contains(busqueda)) ).ToListAsync();
        }

        /// <summary>
        /// Modifica una dirección
        /// </summary>
        /// <param name="direccion">Modelo de dirección</param>
        /// <returns>Identificador de la dirección</returns>
        public Task<int> ModificaDireccion(Direccion direccion)
        {
            return database.UpdateAsync(direccion);
        }

        /// <summary>
        /// Elimina una dirección
        /// </summary>
        /// <param name="direccion">Modelo de dirección</param>
        /// <returns>Identificador de la dirección</returns>
        public Task<int> EliminaDireccion(Direccion direccion)
        {
            return database.DeleteAsync(direccion);
        }

        #endregion

        #region "Necesidad"

        /// <summary>
        /// Guarda un registro de necesidad
        /// </summary>
        /// <param name="necesidad">Modelo de necesidad</param>
        /// <returns>Identificador de la necesidad</returns>
        public Task<int> GuardaNecesidad(Necesidad necesidad)
        {
            return database.InsertAsync(necesidad);
        }

        /// <summary>
        /// Guarda necesidades
        /// </summary>
        /// <param name="necesidades">Lista de necesidades</param>
        /// <returns></returns>
        public async Task GuardaNecesidad(List<Necesidad> necesidades)
        {
            try
            {
                foreach (Necesidad item in necesidades) {
                    await database.InsertAsync(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todas las necesidades
        /// </summary>
        /// <returns>Lista de necesidades</returns>
        public Task<List<Necesidad>> ObtieneNecesidades()
        {
            return database.Table<Necesidad>().ToListAsync();
        }

        /// <summary>
        /// Obtienes the necesidades by text.
        /// </summary>
        /// <returns>The necesidades by text.</returns>
        /// <param name="busqueda">Busqueda.</param>
        public Task<List<Necesidad>> ObtieneNecesidadesByText(string busqueda)
        {
            return database.Table<Necesidad>().Where(i => i.descripcion.Contains(busqueda)).ToListAsync();
        }

        /// <summary>
        /// Obtiene una necesidad
        /// </summary>
        /// <param name="id_necesidad">Identificador de la necesidad</param>
        /// <returns>Modelo de necesidad</returns>
        public Task<Necesidad> ObtieneNecesidades(int id_necesidad)
        {
            return database.Table<Necesidad>().Where(i => i.id_necesidad == id_necesidad).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Modifica una necesidad
        /// </summary>
        /// <param name="necesidad">Modelo de necesidad</param>
        /// <returns>Identificador de la necesidad</returns>
        public Task<int> ModificaNecesidad(Necesidad necesidad)
        {
            return database.UpdateAsync(necesidad);
        }

        /// <summary>
        /// Elimina una necesidad
        /// </summary>
        /// <param name="necesidad">Modelo de la necesidad</param>
        /// <returns>Identificador de la necesidad</returns>
        public Task<int> EliminaNecesidad(Necesidad necesidad)
        {
            return database.DeleteAsync(necesidad);
        }

        #endregion

        #region "Escolaridad"

        /// <summary>
        /// Guarda registro de escolaridad
        /// </summary>
        /// <param name="escolaridad">Modelo de escolaridad</param>
        /// <returns>Identificador del registro</returns>
        public Task<int> GuardaEscolaridad(Escolaridad escolaridad)
        {
            return database.InsertAsync(escolaridad);
        }

        /// <summary>
        /// Guarda lista de registros
        /// </summary>
        /// <param name="escolaridads">Lista de escolaridad</param>
        public async Task GuardaEscolaridad(List<Escolaridad> escolaridads)
        {
            try
            {
                foreach (Escolaridad item in escolaridads) {
                    await database.InsertAsync(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        /// <summary>
        /// Obtiene registro de escolaridad
        /// </summary>
        /// <returns>Lista de escolaridad</returns>
        public Task<List<Escolaridad>> ObtieneEscolaridad()
        {
            return database.Table<Escolaridad>().ToListAsync();
        }

        /// <summary>
        /// Obtienes the escolaridad by text.
        /// </summary>
        /// <returns>The escolaridad by text.</returns>
        /// <param name="busqueda">Busqueda.</param>
        public Task<List<Escolaridad>> ObtieneEscolaridadByText(string busqueda)
        {
            return database.Table<Escolaridad>().Where(i => i.nombre.Contains(busqueda)).ToListAsync();
        }

        /// <summary>
        /// Modifica registro de escolaridad
        /// </summary>
        /// <param name="escolaridad">Modelo de escolaridad</param>
        /// <returns>Identificador de modelo</returns>
        public Task<int> ModificaEscolaridad(Escolaridad escolaridad)
        {
            return database.UpdateAsync(escolaridad);
        }

        /// <summary>
        /// Elimina registro de escolaridad
        /// </summary>
        /// <param name="escolaridad">Modelo de escolaridad</param>
        /// <returns>Identificador de escolaridad</returns>
        public Task<int> EliminaEscolaridad(Escolaridad escolaridad)
        {
            return database.DeleteAsync(escolaridad);
        }

        #endregion

        #region "Estado Civiles"

        /// <summary>
        /// Guardo estado civil
        /// </summary>
        /// <param name="estadoCivil">Moelo de estado civil</param>
        /// <returns>Identificador de estado civil</returns>
        public Task<int> GuardaEstadoCivil(EstadoCivil estadoCivil)
        {
            return database.InsertAsync(estadoCivil);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="estadoCivil"></param>
        /// <returns></returns>
        public async Task GuardaEstadoCivil(List<EstadoCivil> estadoCivil)
        {
            try
            {
                foreach (EstadoCivil item in estadoCivil) {
                    await database.InsertAsync(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los estados civiles
        /// </summary>
        /// <returns>Lista de estados civiles</returns>
        public Task<List<EstadoCivil>> ObtieneEstadoCivil()
        {
            return database.Table<EstadoCivil>().ToListAsync();
        }

        /// <summary>
        /// Obtienes the estado civil by text.
        /// </summary>
        /// <returns>The estado civil by text.</returns>
        /// <param name="busqueda">Busqueda.</param>
        public Task<List<EstadoCivil>> ObtieneEstadoCivilByText(string busqueda)
        {
            return database.Table<EstadoCivil>().Where(i => i.nombre.Contains(busqueda)).ToListAsync();
        }

        /// <summary>
        /// Obtiene estado civil 
        /// </summary>
        /// <param name="id_estado_civil">Identificador del estado civil</param>
        /// <returns>Modelo de estado civil</returns>
        public Task<EstadoCivil> ObtieneEstadoCivil(int id_estado_civil)
        {
            return database.Table<EstadoCivil>().Where(i => i.id_estado_civil == id_estado_civil).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Modifica el registro del estado civil
        /// </summary>
        /// <param name="estadoCivil">Modelo del estado civil</param>
        /// <returns>Identificador del estado civil</returns>
        public Task<int> ModificaEstadoCivil(EstadoCivil estadoCivil)
        {
            return database.UpdateAsync(estadoCivil);
        }

        /// <summary>
        /// Elimina registro de estado civil
        /// </summary>
        /// <param name="estadoCivil">Modelo del estado civil</param>
        /// <returns></returns>
        public Task<int> EliminaEstadoCivil(EstadoCivil estadoCivil)
        {
            return database.DeleteAsync(estadoCivil);
        }

        #endregion
    }
}
