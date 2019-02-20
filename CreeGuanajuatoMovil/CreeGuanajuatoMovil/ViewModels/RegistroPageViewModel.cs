using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Utils;
using CreeGuanajuatoMovil.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class RegistroPageViewModel : ViewModelBase
    {
        #region Commands
        public INavigation Navigation { get; set; }
        #endregion

        #region Properties
        public Task Initialization { get; private set; }
        public ObservableCollection<Estado> Estados { get; }
        public ObservableCollection<Municipio> Municipios { get; }
        public ObservableCollection<Colonia> Colonias { get; }
        public ObservableCollection<Direccion> Direcciones { get; }
        public ObservableCollection<Escolaridad> Escolaridad { get; }
        public ObservableCollection<Necesidad> Necesidades { get; }
        public ObservableCollection<EstadoCivil> EstadoCiviles { get; }

        private string _sEstado;

        public string sEstado {
            get { return _sEstado; }
            set {
                SetProperty(ref _sEstado, value);

                if (!string.IsNullOrEmpty(_sEstado) && _sEstado.Length > 2)
                    getEstados(_sEstado);
            }
        }

        private Estado _EstadoSeleccionado;
        public Estado EstadoSeleccionado
        {
            get { return _EstadoSeleccionado; }
            set {
                SetProperty(ref _EstadoSeleccionado, value);

                if (EstadoSeleccionado.id_estado != 0)
                    getMunicipios(EstadoSeleccionado.id_estado);

            }
        }

        private Municipio _MunicipiosSeleccionado;
        public Municipio MunicipiosSeleccionado
        {
            get { return _MunicipiosSeleccionado; }
            set {
                SetProperty(ref _MunicipiosSeleccionado, value);
                getColonias(MunicipiosSeleccionado.id_municipio);
            }
        }

        private Colonia _ColoniasSeleccionado;
        public Colonia ColoniasSeleccionado
        {
            get { return _ColoniasSeleccionado; }
            set {
                SetProperty(ref _ColoniasSeleccionado, value);
                getDirecciones(ColoniasSeleccionado.id_colonia);
            }
        }

        private Direccion _DireccionSeleccionado;
        public Direccion DireccionSeleccionado
        {
            get { return _DireccionSeleccionado; }
            set { SetProperty(ref _DireccionSeleccionado, value); }
        }

        private Escolaridad _EscolaridadSeleccionado;
        public Escolaridad EscolaridadSeleccionado
        {
            get { return _EscolaridadSeleccionado; }
            set { SetProperty(ref _EscolaridadSeleccionado, value); }
        }

        private Necesidad _NecesidadSeleccionado;
        public Necesidad NecesidadSeleccionado
        {
            get { return _NecesidadSeleccionado; }
            set { SetProperty(ref _NecesidadSeleccionado, value); }
        }

        private EstadoCivil _EstadoCivilSeleccionado;
        public EstadoCivil EstadoCivilSeleccionado
        {
            get { return _EstadoCivilSeleccionado; }
            set { SetProperty(ref _EstadoCivilSeleccionado, value); }
        }
        #endregion

        public RegistroPageViewModel() {
            Estados = new ObservableCollection<Estado>();
            Municipios = new ObservableCollection<Municipio>();
            Colonias = new ObservableCollection<Colonia>();
            Direcciones = new ObservableCollection<Direccion>();
            Escolaridad = new ObservableCollection<Escolaridad>();
            Necesidades = new ObservableCollection<Necesidad>();
            EstadoCiviles = new ObservableCollection<EstadoCivil>();
        }

        private async void getEstados(string busqueda) {
            List<Estado> estados = await App.DataBase.ObtieneEstadosByText(busqueda);

            foreach (Estado item in estados)
            {
                Estados.Add(item);
            }
        }

        private async void getMunicipios(int id_estado)
        {
            List<Municipio> municipios = await App.DataBase.ObtieneMunicipioPorEstado(id_estado);
            foreach (Municipio item in municipios)
            {
                Municipios.Add(item);
            }
        }

        private async void getColonias(int id_municipio)
        {
            List<Colonia> colonias = await App.DataBase.ObtieneColoniasPorMunicipio(id_municipio);
            foreach (Colonia item in colonias)
            {
                Colonias.Add(item);
            }
        }

        private async void getDirecciones(int id_colonia)
        {
            List<Direccion> direcciones = await App.DataBase.ObtieneDireccionesPorColonia(id_colonia);
            foreach (Direccion item in direcciones)
            {
                Direcciones.Add(item);
            }
        }

        private async void getEscolaridad()
        {
            List<Escolaridad> escolaridads = await App.DataBase.ObtieneEscolaridad();
            foreach (Escolaridad item in escolaridads)
            {
                Escolaridad.Add(item);
            }
        }

        private async void getNecesidades()
        {
            List<Necesidad> necesidads = await App.DataBase.ObtieneNecesidades();
            foreach (Necesidad item in necesidads)
            {
                Necesidades.Add(item);
            }
        }

        private async void getEstadoCiviles()
        {
            List<EstadoCivil> estadoCivils = await App.DataBase.ObtieneEstadoCivil();
            foreach (EstadoCivil item in estadoCivils)
            {
                EstadoCiviles.Add(item);
            }
        }
    }
}
