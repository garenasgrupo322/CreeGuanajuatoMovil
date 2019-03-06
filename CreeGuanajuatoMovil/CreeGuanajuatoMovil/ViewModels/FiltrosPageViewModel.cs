using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Views;
using Xamarin.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class FiltrosPageViewModel : ViewModelBase
    {
        #region Commands
        public INavigation Navigation { get; set; }

        public Command FiltraRegistroCommand { get; set; }
        public Command FiltraRegistroMapaCommand { get; set; }
        public Command LimpiaFiltrosCommand { get; set; }
        #endregion

        #region Properties Estado

        public bool IsSelectedEstado { get; set; }

        private bool _IsVisibleEstado;
        public bool IsVisibleEstado
        {
            get
            {
                return _IsVisibleEstado;
            }
            set
            {
                SetProperty(ref _IsVisibleEstado, value);
            }
        }

        private string _sEstado;

        public string sEstado
        {
            get { return _sEstado; }
            set
            {
                SetProperty(ref _sEstado, value);

                if (!IsSelectedEstado)
                {
                    Task.Run(() => getEstados(_sEstado));
                }
            }
        }

        private Estado _EstadoSeleccionado;
        public Estado EstadoSeleccionado
        {
            get { return _EstadoSeleccionado; }
            set
            {
                SetProperty(ref _EstadoSeleccionado, value);
                IsSelectedEstado = true;
                sEstado = _EstadoSeleccionado.nombre_estado;
                ListEstadoClear();
            }
        }

        #endregion

        #region Properties Municipio

        public bool IsSelectedMunicipio { get; set; }

        private bool _IsVisibleMunicipio;
        public bool IsVisibleMunicipio
        {
            get
            {
                return _IsVisibleMunicipio;
            }
            set
            {
                SetProperty(ref _IsVisibleMunicipio, value);
            }
        }

        private string _sMunicipio;

        public string sMunicipio
        {
            get { return _sMunicipio; }
            set
            {
                SetProperty(ref _sMunicipio, value);

                if (!IsSelectedMunicipio)
                    Task.Run(() => getMunicipios(EstadoSeleccionado.id_estado, _sMunicipio));
            }
        }

        private Municipio _MunicipioSeleccionado;
        public Municipio MunicipioSeleccionado
        {
            get { return _MunicipioSeleccionado; }
            set
            {
                SetProperty(ref _MunicipioSeleccionado, value);
                IsSelectedMunicipio = true;
                sMunicipio = _MunicipioSeleccionado.nombre_municipio;
                ListMunicipioClear();
            }
        }

        #endregion

        #region Properties Colonia

        public bool IsSelectedColonia { get; set; }

        private bool _IsVisibleColonia;
        public bool IsVisibleColonia
        {
            get
            {
                return _IsVisibleColonia;
            }
            set
            {
                SetProperty(ref _IsVisibleColonia, value);
            }
        }

        private string _sColonia;

        public string sColonia
        {
            get { return _sColonia; }
            set
            {
                SetProperty(ref _sColonia, value);

                if (!IsSelectedColonia)
                    Task.Run(() => getColonias(MunicipioSeleccionado.id_municipio, _sColonia));
            }
        }

        private Colonia _ColoniaSeleccionado = new Colonia();
        public Colonia ColoniaSeleccionado
        {
            get { return _ColoniaSeleccionado; }
            set
            {
                SetProperty(ref _ColoniaSeleccionado, value);
                IsSelectedColonia = true;
                sColonia = _ColoniaSeleccionado.nombre_colonia;
                ListColoniaClear();
            }
        }

        #endregion

        #region Properties Escolaridad

        public bool IsSelectedEscolaridad { get; set; }

        private bool _IsVisibleEscolaridad;
        public bool IsVisibleEscolaridad
        {
            get
            {
                return _IsVisibleEscolaridad;
            }
            set
            {
                SetProperty(ref _IsVisibleEscolaridad, value);
            }
        }

        private string _sEscolaridad;

        public string sEscolaridad
        {
            get { return _sEscolaridad; }
            set
            {
                SetProperty(ref _sEscolaridad, value);

                if (!IsSelectedEscolaridad)
                    Task.Run(() => getEscolaridades(_sEscolaridad));
            }
        }

        private Escolaridad _EscolaridadSeleccionado;
        public Escolaridad EscolaridadSeleccionado
        {
            get { return _EscolaridadSeleccionado; }
            set
            {
                SetProperty(ref _EscolaridadSeleccionado, value);
                IsSelectedEscolaridad = true;
                sEscolaridad = _EscolaridadSeleccionado.nombre;
                ListEscolaridadClear();
            }
        }

        #endregion

        #region Properties Necesidad

        public bool IsSelectedNecesidad { get; set; }

        private bool _IsVisibleNecesidad;
        public bool IsVisibleNecesidad
        {
            get
            {
                return _IsVisibleNecesidad;
            }
            set
            {
                SetProperty(ref _IsVisibleNecesidad, value);
            }
        }

        private string _sNecesidad;

        public string sNecesidad
        {
            get { return _sNecesidad; }
            set
            {
                SetProperty(ref _sNecesidad, value);

                if (!IsSelectedNecesidad)
                    Task.Run(() => getNecesidades(_sNecesidad));
            }
        }

        private Necesidad _NecesidadSeleccionado;
        public Necesidad NecesidadSeleccionado
        {
            get { return _NecesidadSeleccionado; }
            set
            {
                SetProperty(ref _NecesidadSeleccionado, value);
                IsSelectedNecesidad = true;
                sNecesidad = _NecesidadSeleccionado.descripcion;
                ListNecesidadClear();
            }
        }

        #endregion

        #region Properties
        public Task Initialization { get; private set; }
        public ObservableCollection<Estado> Estados { get; set; }
        public ObservableCollection<Municipio> Municipios { get; set; }
        public ObservableCollection<Colonia> Colonias { get; set; }
        public ObservableCollection<Escolaridad> Escolaridades { get; set; }
        public ObservableCollection<Necesidad> Necesidades { get; set; }

        private bool _ErrorEstadoVisible;

        public bool ErrorEstadoVisible
        {
            get
            {
                return _ErrorEstadoVisible;
            }
            set
            {
                SetProperty(ref _ErrorEstadoVisible, value);
            }
        }

        private string _ErrorEstadoMensaje;

        public string ErrorEstadoMensaje
        {
            get
            {
                return _ErrorEstadoMensaje;
            }
            set
            {
                SetProperty(ref _ErrorEstadoMensaje, value);
            }
        }

        private bool _ErrorMunicipioVisible;

        public bool ErrorMunicipioVisible
        {
            get
            {
                return _ErrorMunicipioVisible;
            }
            set
            {
                SetProperty(ref _ErrorMunicipioVisible, value);
            }
        }

        private string _ErrorMunicipioMensaje;

        public string ErrorMunicipioMensaje
        {
            get
            {
                return _ErrorMunicipioMensaje;
            }
            set
            {
                SetProperty(ref _ErrorMunicipioMensaje, value);
            }
        }

        private bool _ErrorColoniaVisible;

        public bool ErrorColoniaVisible
        {
            get
            {
                return _ErrorColoniaVisible;
            }
            set
            {
                SetProperty(ref _ErrorColoniaVisible, value);
            }
        }

        private string _ErrorColoniaMensaje;

        public string ErrorColoniaMensaje
        {
            get
            {
                return _ErrorColoniaMensaje;
            }
            set
            {
                SetProperty(ref _ErrorColoniaMensaje, value);
            }
        }

        private bool _ErrorCpVisible;

        public bool ErrorCpVisible
        {
            get
            {
                return _ErrorCpVisible;
            }
            set
            {
                SetProperty(ref _ErrorCpVisible, value);
            }
        }

        private string _ErrorCpMensaje;

        public string ErrorCpMensaje
        {
            get
            {
                return _ErrorCpMensaje;
            }
            set
            {
                SetProperty(ref _ErrorCpMensaje, value);
            }
        }

        private bool _ErrorEscolaridadVisible;

        public bool ErrorEscolaridadVisible
        {
            get
            {
                return _ErrorEscolaridadVisible;
            }
            set
            {
                SetProperty(ref _ErrorEscolaridadVisible, value);
            }
        }

        private string _ErrorEscolaridadMensaje;

        public string ErrorEscolaridadMensaje
        {
            get
            {
                return _ErrorEscolaridadMensaje;
            }
            set
            {
                SetProperty(ref _ErrorEscolaridadMensaje, value);
            }
        }

        private bool _ErrorNecesidadVisible;

        public bool ErrorNecesidadVisible
        {
            get
            {
                return _ErrorNecesidadVisible;
            }
            set
            {
                SetProperty(ref _ErrorNecesidadVisible, value);
            }
        }

        private string _ErrorNecesidadMensaje;

        public string ErrorNecesidadMensaje
        {
            get
            {
                return _ErrorNecesidadMensaje;
            }
            set
            {
                SetProperty(ref _ErrorNecesidadMensaje, value);
            }
        }

        private string _Busqueda;

        public string Busqueda
        {
            get
            {
                return _Busqueda;
            }
            set
            {
                SetProperty(ref _Busqueda, value);
            }
        }

        #endregion

        public FiltrosPageViewModel()
        {
            Estados = new ObservableCollection<Estado>();
            Municipios = new ObservableCollection<Municipio>();
            Colonias = new ObservableCollection<Colonia>();
            Escolaridades = new ObservableCollection<Escolaridad>();
            Necesidades = new ObservableCollection<Necesidad>();

            FiltraRegistroCommand = new Command(FiltraRegistros);
            FiltraRegistroMapaCommand = new Command(FiltraRegistrosMapa);
            LimpiaFiltrosCommand = new Command(LimpiaFiltros);
        }

        async Task getEstados(string busqueda)
        {
            IsVisibleEstado = false;
            if (!string.IsNullOrEmpty(busqueda) && busqueda.Length > 2)
            {
                var count = Estados.Count();

                for (int i = 0; i < count; i++)
                {
                    Estados.RemoveAt(0);
                }

                List<Estado> estados = await App.DataBase.ObtieneEstadosByText(busqueda);

                if (estados.Count > 0)
                {
                    foreach (Estado item in estados)
                    {
                        Estados.Add(item);
                    }
                    IsVisibleEstado = true;
                }
                else
                {
                    ListEstadoClear();
                }
            }
            else
            {
                ListEstadoClear();
            }
        }

        async Task getMunicipios(int id_estado, string busqueda)
        {
            IsVisibleMunicipio = false;
            if (id_estado != 0 && (!string.IsNullOrEmpty(busqueda) && busqueda.Length > 2))
            {
                var count = Municipios.Count();

                for (int i = 0; i < count; i++)
                {
                    Municipios.RemoveAt(0);
                }

                List<Municipio> municipios = await App.DataBase.ObtieneMunicipioPorEstadoAndByText(id_estado, busqueda);

                if (municipios.Count != 0)
                {
                    foreach (Municipio item in municipios)
                    {
                        Municipios.Add(item);
                    }
                    IsVisibleMunicipio = true;
                }
                else
                {
                    ListMunicipioClear();
                }

            }
            else
            {
                ListMunicipioClear();
            }
        }

        async Task getColonias(int id_municipio, string busqueda)
        {
            IsVisibleColonia = false;
            if (id_municipio != 0 && (!string.IsNullOrEmpty(busqueda) && busqueda.Length > 2))
            {
                var count = Colonias.Count();

                for (int i = 0; i < count; i++)
                {
                    Colonias.RemoveAt(0);
                }

                List<Colonia> colonias = await App.DataBase.ObtieneColoniasPorMunicipioByText(id_municipio, busqueda);

                if (colonias.Count != 0)
                {
                    foreach (Colonia item in colonias)
                    {
                        Colonias.Add(item);
                    }

                    IsVisibleColonia = true;
                }
                else
                {
                    ListColoniaClear();
                }
            }
            else
            {
                ListColoniaClear();
            }

        }

        async Task getEscolaridades(string busqueda)
        {
            IsVisibleEscolaridad = false;
            if (!string.IsNullOrEmpty(busqueda) && busqueda.Length > 2)
            {
                var count = Escolaridades.Count();

                for (int i = 0; i < count; i++)
                {
                    Escolaridades.RemoveAt(0);
                }

                List<Escolaridad> escolaridads = await App.DataBase.ObtieneEscolaridadByText(busqueda);

                if (escolaridads.Count > 0)
                {
                    foreach (Escolaridad item in escolaridads)
                    {
                        Escolaridades.Add(item);
                    }
                    IsVisibleEscolaridad = true;
                }
                else
                {
                    ListEscolaridadClear();
                }
            }
            else
            {
                ListEscolaridadClear();
            }
        }

        async Task getNecesidades(string busqueda)
        {
            IsVisibleNecesidad = false;
            if (!string.IsNullOrEmpty(busqueda) && busqueda.Length > 2)
            {
                var count = Necesidades.Count();

                for (int i = 0; i < count; i++)
                {
                    Necesidades.RemoveAt(0);
                }

                List<Necesidad> necesidads = await App.DataBase.ObtieneNecesidadesByText(busqueda);

                if (necesidads.Count != 0)
                {
                    foreach (Necesidad item in necesidads)
                    {
                        Necesidades.Add(item);
                    }
                    IsVisibleNecesidad = true;
                }
                else
                {
                    ListNecesidadClear();
                }

            }
            else
            {
                ListNecesidadClear();
            }
        }

        void ListEstadoClear()
        {
            IsVisibleEstado = false;
        }

        void ListMunicipioClear()
        {
            IsVisibleMunicipio = false;
        }

        void ListColoniaClear()
        {
            IsVisibleColonia = false;
        }

        void ListEscolaridadClear()
        {
            IsVisibleEscolaridad = false;
        }

        void ListNecesidadClear()
        {
            IsVisibleNecesidad = false;
        }

        void FiltraRegistros()
        {
            if (valida())
            {
                var mdp = (Application.Current.MainPage as MasterDetailPage);
                var navPage = mdp.Detail as NavigationPage;
                mdp.IsPresented = false;

                if (EstadoSeleccionado == null)
                    EstadoSeleccionado = new Estado();

                if (MunicipioSeleccionado == null)
                    MunicipioSeleccionado = new Municipio();


                if (ColoniaSeleccionado == null)
                    ColoniaSeleccionado = new Colonia();

                if (EscolaridadSeleccionado == null)
                    EscolaridadSeleccionado = new Escolaridad();

                if (NecesidadSeleccionado == null)
                    NecesidadSeleccionado = new Necesidad();

                navPage.PushAsync(new ReportePage(EstadoSeleccionado.id_estado, MunicipioSeleccionado.id_municipio, ColoniaSeleccionado.id_colonia, EscolaridadSeleccionado.id_escolaridad,
                    NecesidadSeleccionado.id_necesidad, Busqueda));
            }
        }

        void FiltraRegistrosMapa()
        {
            if (valida())
            {
                var mdp = (Application.Current.MainPage as MasterDetailPage);
                var navPage = mdp.Detail as NavigationPage;
                mdp.IsPresented = false;

                if (EstadoSeleccionado == null)
                    EstadoSeleccionado = new Estado();

                if (MunicipioSeleccionado == null)
                    MunicipioSeleccionado = new Municipio();


                if (ColoniaSeleccionado == null)
                    ColoniaSeleccionado = new Colonia();

                if (EscolaridadSeleccionado == null)
                    EscolaridadSeleccionado = new Escolaridad();

                if (NecesidadSeleccionado == null)
                    NecesidadSeleccionado = new Necesidad();

                navPage.PushAsync(new MapaPage(EstadoSeleccionado.id_estado, MunicipioSeleccionado.id_municipio, ColoniaSeleccionado.id_colonia, EscolaridadSeleccionado.id_escolaridad,
                    NecesidadSeleccionado.id_necesidad, Busqueda));
            }
        }

        public void focusEnry(string sender)
        {
            switch (sender)
            {
                case "Estado":
                    IsSelectedEstado = false;
                    break;

                case "Municipio":
                    IsSelectedMunicipio = false;
                    break;

                case "Colonia":
                    IsSelectedColonia = false;
                    break;

                case "Escolaridad":
                    IsSelectedEscolaridad = false;
                    break;

                case "Necesidad":
                    IsSelectedNecesidad = false;
                    break;
            }
        }

        bool valida()
        {
            bool success = true;

            if (!string.IsNullOrEmpty(sEstado))
            {
                ErrorEstadoVisible = false;
                ErrorEstadoMensaje = "Por favor seleccione una opción de la lista desplegable";

                if (EstadoSeleccionado == null)
                {
                    success = false;
                    ErrorEstadoVisible = true;
                }
                else
                {
                    if (!EstadoSeleccionado.nombre_estado.Equals(sEstado))
                    {
                        success = false;
                        ErrorEstadoVisible = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(sMunicipio))
            {
                ErrorMunicipioVisible = false;
                ErrorMunicipioMensaje = "Por favor seleccione una opción de la lista desplegable";

                if (MunicipioSeleccionado == null)
                {
                    success = false;
                    ErrorMunicipioVisible = true;
                }
                else
                {
                    if (!MunicipioSeleccionado.nombre_municipio.Equals(sMunicipio))
                    {
                        success = false;
                        ErrorMunicipioVisible = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(sColonia))
            {
                ErrorColoniaVisible = false;
                ErrorColoniaMensaje = "Por favor seleccione una opción de la lista desplegable";

                if (ColoniaSeleccionado == null)
                {
                    success = false;
                    ErrorColoniaVisible = true;
                }
                else
                {
                    if (!ColoniaSeleccionado.nombre_colonia.Equals(sColonia)) 
                    {
                        success = false;
                        ErrorColoniaVisible = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(sEscolaridad))
            {
                ErrorEscolaridadVisible = false;
                ErrorEscolaridadMensaje = "Por favor seleccione una opción de la lista desplegable";

                if (EscolaridadSeleccionado == null)
                {
                    success = false;
                    ErrorEscolaridadVisible = true;
                }
                else
                {
                    if (!EscolaridadSeleccionado.nombre.Equals(sEscolaridad))
                    {
                        success = false;
                        ErrorEscolaridadVisible = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(sNecesidad))
            {
                ErrorNecesidadVisible = false;
                ErrorNecesidadMensaje = "Por favor seleccione una opción de la lista desplegable";

                if (NecesidadSeleccionado == null)
                {
                    success = false;
                    ErrorNecesidadVisible = true;
                }
                else
                {
                    if (!NecesidadSeleccionado.descripcion.Equals(sNecesidad))
                    {
                        success = false;
                        ErrorNecesidadVisible = true;
                    }
                }
            }

            return success;
        }

        void LimpiaFiltros()
        {
            EstadoSeleccionado = new Estado();
            MunicipioSeleccionado = new Municipio();
            ColoniaSeleccionado = new Colonia();
            EscolaridadSeleccionado = new Escolaridad();
            NecesidadSeleccionado = new Necesidad();
            Busqueda = string.Empty;
        }
    }
}
