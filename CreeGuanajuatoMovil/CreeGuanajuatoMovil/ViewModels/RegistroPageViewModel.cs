using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Utils;
using CreeGuanajuatoMovil.Views;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class RegistroPageViewModel : ViewModelBase
    {
        #region Commands
        public INavigation Navigation { get; set; }

        public Command GuardaRegistroCommand { get; set; }

        public Command SiguienteEntryCommand { get; set; }

        public Command GetCurrentLocation { get; set; }

        public ImageSource imageSorceLocation { get; set; }
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

        #region Properties Direccion

        public bool IsSelectedDireccion { get; set; }

        private bool _IsVisibleDireccion;
        public bool IsVisibleDireccion
        {
            get
            {
                return _IsVisibleDireccion;
            }
            set
            {
                SetProperty(ref _IsVisibleDireccion, value);
            }
        }

        private string _sDireccion;

        public string sDireccion
        {
            get { return _sDireccion; }
            set
            {
                SetProperty(ref _sDireccion, value);

                if (!IsSelectedDireccion)
                    Task.Run(() => getDirecciones(ColoniaSeleccionado.id_colonia, _sDireccion));

            }
        }

        private Direccion _DireccionSeleccionado = new Direccion();
        public Direccion DireccionSeleccionado
        {
            get { return _DireccionSeleccionado; }
            set
            {
                SetProperty(ref _DireccionSeleccionado, value);
                IsSelectedDireccion = true;
                sDireccion = _DireccionSeleccionado.calle;
                ListDireccionClear();
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

        #region Properties EstadoCivil

        public bool IsSelectedEstadoCivil { get; set; }

        private bool _IsVisibleEstadoCivil;
        public bool IsVisibleEstadoCivil
        {
            get
            {
                return _IsVisibleEstadoCivil;
            }
            set
            {
                SetProperty(ref _IsVisibleEstadoCivil, value);
            }
        }

        private string _sEstadoCivil;

        public string sEstadoCivil
        {
            get { return _sEstadoCivil; }
            set
            {
                SetProperty(ref _sEstadoCivil, value);

                if (!IsSelectedEstadoCivil)
                    Task.Run(() => getEstadosCiviles(_sEstadoCivil));
            }
        }

        private EstadoCivil _EstadoCivilSeleccionado;
        public EstadoCivil EstadoCivilSeleccionado
        {
            get { return _EstadoCivilSeleccionado; }
            set
            {
                SetProperty(ref _EstadoCivilSeleccionado, value);
                IsSelectedEstadoCivil = true;
                sEstadoCivil = _EstadoCivilSeleccionado.nombre;
                ListEstadoCivilClear();
            }
        }

        #endregion

        #region Properties
        public Task Initialization { get; private set; }
        public ObservableCollection<Estado> Estados { get; set; }
        public ObservableCollection<Municipio> Municipios { get; set; }
        public ObservableCollection<Colonia> Colonias { get; set; }
        public ObservableCollection<Direccion> Direcciones { get; set; }
        public ObservableCollection<Escolaridad> Escolaridades { get; set; }
        public ObservableCollection<Necesidad> Necesidades { get; set; }
        public ObservableCollection<EstadoCivil> EstadoCiviles { get; set; }

        public Keyboard keyboard { get; set; }

        private Registro _registro = new Registro();

        public Registro registro {
            get
            {
                return _registro;
            }
            set
            {
                SetProperty(ref _registro, value);
            }
        }

        private bool _ErrorNombreVisible;

        public bool ErrorNombreVisible
        {
            get
            {
                return _ErrorNombreVisible;
            }
            set
            {
                SetProperty(ref _ErrorNombreVisible, value);
            }
        }

        private string _ErrorNombreMensaje;

        public string ErrorNombreMensaje
        {
            get
            {
                return _ErrorNombreMensaje;
            }
            set
            {
                SetProperty(ref _ErrorNombreMensaje, value);
            }
        }

        private bool _ErrorPaternoVisible;

        public bool ErrorPaternoVisible
        {
            get
            {
                return _ErrorPaternoVisible;
            }
            set
            {
                SetProperty(ref _ErrorPaternoVisible, value);
            }
        }

        private string _ErrorPaternoMensaje;

        public string ErrorPaternoMensaje
        {
            get
            {
                return _ErrorPaternoMensaje;
            }
            set
            {
                SetProperty(ref _ErrorPaternoMensaje, value);
            }
        }

        private bool _ErrorMaternoVisible;

        public bool ErrorMaternoVisible
        {
            get
            {
                return _ErrorMaternoVisible;
            }
            set
            {
                SetProperty(ref _ErrorMaternoVisible, value);
            }
        }

        private string _ErrorMaternoMensaje;

        public string ErrorMaternoMensaje
        {
            get
            {
                return _ErrorMaternoMensaje;
            }
            set
            {
                SetProperty(ref _ErrorMaternoMensaje, value);
            }
        }

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

        private bool _ErrorCalleVisible;

        public bool ErrorCalleVisible
        {
            get
            {
                return _ErrorCalleVisible;
            }
            set
            {
                SetProperty(ref _ErrorCalleVisible, value);
            }
        }

        private string _ErrorCalleMensaje;

        public string ErrorCalleMensaje
        {
            get
            {
                return _ErrorCalleMensaje;
            }
            set
            {
                SetProperty(ref _ErrorCalleMensaje, value);
            }
        }

        private bool _ErrorNumeroVisible;

        public bool ErrorNumeroVisible
        {
            get
            {
                return _ErrorNumeroVisible;
            }
            set
            {
                SetProperty(ref _ErrorNumeroVisible, value);
            }
        }

        private string _ErrorNumeroMensaje;

        public string ErrorNumeroMensaje
        {
            get
            {
                return _ErrorNumeroMensaje;
            }
            set
            {
                SetProperty(ref _ErrorNumeroMensaje, value);
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

        private bool _ErrorNacimientoVisible;

        public bool ErrorNacimientoVisible
        {
            get
            {
                return _ErrorNacimientoVisible;
            }
            set
            {
                SetProperty(ref _ErrorNacimientoVisible, value);
            }
        }

        private string _ErrorNacimientoMensaje;

        public string ErrorNacimientoMensaje
        {
            get
            {
                return _ErrorNacimientoMensaje;
            }
            set
            {
                SetProperty(ref _ErrorNacimientoMensaje, value);
            }
        }

        private bool _ErrorHijosVisible;

        public bool ErrorHijosVisible
        {
            get
            {
                return _ErrorHijosVisible;
            }
            set
            {
                SetProperty(ref _ErrorHijosVisible, value);
            }
        }

        private string _ErrorHijosMensaje;

        public string ErrorHijosMensaje
        {
            get
            {
                return _ErrorHijosMensaje;
            }
            set
            {
                SetProperty(ref _ErrorHijosMensaje, value);
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

        private bool _ErrorEstadoCivilVisible;

        public bool ErrorEstadoCivilVisible
        {
            get
            {
                return _ErrorEstadoCivilVisible;
            }
            set
            {
                SetProperty(ref _ErrorEstadoCivilVisible, value);
            }
        }

        private string _ErrorEstadoCivildMensaje;

        public string ErrorEstadoCivildMensaje
        {
            get
            {
                return _ErrorEstadoCivildMensaje;
            }
            set
            {
                SetProperty(ref _ErrorEstadoCivildMensaje, value);
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

        private bool _ErrorIneVisible;

        public bool ErrorIneVisible
        {
            get
            {
                return _ErrorIneVisible;
            }
            set
            {
                SetProperty(ref _ErrorIneVisible, value);
            }
        }

        private string _ErrorIneMensaje;

        public string ErrorIneMensaje
        {
            get
            {
                return _ErrorIneMensaje;
            }
            set
            {
                SetProperty(ref _ErrorIneMensaje, value);
            }
        }

        private bool _ErrorEmailVisible;

        public bool ErrorEmailVisible
        {
            get
            {
                return _ErrorEmailVisible;
            }
            set
            {
                SetProperty(ref _ErrorEmailVisible, value);
            }
        }

        private string _ErrorEmailMensaje;

        public string ErrorEmailMensaje
        {
            get
            {
                return _ErrorEmailMensaje;
            }
            set
            {
                SetProperty(ref _ErrorEmailMensaje, value);
            }
        }

        private bool _PanelUsuario;

        public bool PanelUsuario
        {
            get
            {
                return _PanelUsuario;
            }
            set
            {
                SetProperty(ref _PanelUsuario, value);
            }
        }

        private bool _PanelDireccion;

        public bool PanelDireccion
        {
            get
            {
                return _PanelDireccion;
            }
            set
            {
                SetProperty(ref _PanelDireccion, value);
            }
        }

        private bool _PanelComplementos;

        public bool PanelComplementos
        {
            get
            {
                return _PanelComplementos;
            }
            set
            {
                SetProperty(ref _PanelComplementos, value);
            }
        }

        private string _sEtapa;
        public string sEtapa {
            get {
                return _sEtapa;
            }

            set
            {
                SetProperty(ref _sEtapa, value);
            }
        }

        private double _Etapa;
        public double Etapa
        {
            get
            {
                return _Etapa;
            }

            set
            {
                SetProperty(ref _Etapa, value);

                if (_Etapa < 1.2)
                {
                    sEtapa = "(1/3)";
                    PanelUsuario = true;
                    PanelDireccion = false;
                    PanelComplementos = false;
                }

                if (_Etapa > 1.2 && _Etapa < 2.5)
                {
                    sEtapa = "(2/3)";
                    PanelUsuario = false;
                    PanelDireccion = true;
                    PanelComplementos = false;
                }

                if (_Etapa >= 2.5)
                {
                    sEtapa = "(3/3)";
                    PanelUsuario = false;
                    PanelDireccion = false;
                    PanelComplementos = true;
                }
            }
        }

        public object background { get; set; }

        #endregion

        public RegistroPageViewModel() {
            imageSorceLocation = ImageSource.FromResource("CreeGuanajuatoMovil.Images.pin.png");
            Etapa = 0;

            Estados = new ObservableCollection<Estado>();
            Municipios = new ObservableCollection<Municipio>();
            Colonias = new ObservableCollection<Colonia>();
            Direcciones = new ObservableCollection<Direccion>();
            Escolaridades = new ObservableCollection<Escolaridad>();
            Necesidades = new ObservableCollection<Necesidad>();
            EstadoCiviles = new ObservableCollection<EstadoCivil>();

            GuardaRegistroCommand = new Command(GuardaRegistro);
            GetCurrentLocation = new Command(ObtieneUbicacion);

            keyboard = Keyboard.Create(KeyboardFlags.All);

            SiguienteEntryCommand = new Command<View>((view) =>
            {
                view?.Focus();

                try
                {
                    Entry entry = (Entry)view;

                    switch (entry?.Placeholder)
                    {
                        case "Ingrese su estado":
                            Etapa = 2.0;
                            break;

                        case "Ingrese número de hijos":
                            Etapa = 3.0;
                            break;
                    }
                } catch(Exception ex)
                {
                    Debug.Print("@debug" + ex.Message);
                }

            });
        }

        async Task getEstados(string busqueda) {
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

        async Task getDirecciones(int id_colonia, string busqueda)
        {
            IsVisibleDireccion = false;
            if (id_colonia != 0 && (!string.IsNullOrEmpty(busqueda) && busqueda.Length > 2))
            {
                var count = Direcciones.Count();

                for (int i = 0; i < count; i++)
                {
                    Direcciones.RemoveAt(0);
                }

                List<Direccion> direcciones = await App.DataBase.ObtieneDireccionesPorColoniaByText(id_colonia, busqueda);

                if (direcciones.Count > 2)
                {
                    foreach (Direccion item in direcciones)
                    {
                        Direcciones.Add(item);
                    }
                    IsVisibleDireccion = true;
                }
                else
                {
                    ListDireccionClear();
                }
            }
            else
            {
                ListDireccionClear();
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

                if(necesidads.Count != 0)
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

        async Task getEstadosCiviles(string busqueda)
        {
            IsVisibleEstadoCivil = false;
            if (!string.IsNullOrEmpty(busqueda) && busqueda.Length > 2)
            {
                var count = EstadoCiviles.Count();

                for (int i = 0; i < count; i++)
                {
                    EstadoCiviles.RemoveAt(0);
                }

                List<EstadoCivil> estadoCivils = await App.DataBase.ObtieneEstadoCivilByText(busqueda);

                if (estadoCivils.Count != 0)
                {
                    foreach (EstadoCivil item in estadoCivils)
                    {
                        EstadoCiviles.Add(item);
                    }
                    IsVisibleEstadoCivil = true;
                }
                else
                {
                    ListEstadoCivilClear();
                }
            }
            else
            {
                ListEstadoCivilClear();
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

        void ListDireccionClear()
        {
            IsVisibleDireccion = false;
        }

        void ListEscolaridadClear()
        {
            IsVisibleEscolaridad = false;
        }

        void ListNecesidadClear()
        {
            IsVisibleNecesidad = false;
        }

        void ListEstadoCivilClear()
        {
            IsVisibleEstadoCivil = false;
        }
    
        async void GuardaRegistro()
        {
            if (valida())
            {
                IsBusy = true;
                Estado edo = new Estado();
                Municipio mun = new Municipio();
                Colonia col = new Colonia();
                Direccion dir = new Direccion();
                Escolaridad escola = new Escolaridad();
                EstadoCivil edoCivil = new EstadoCivil();
                Necesidad nec = new Necesidad();

                if (EstadoSeleccionado == null)
                {
                    edo.nombre_estado = sEstado;
                }
                else
                {
                    if (EstadoSeleccionado.nombre_estado != sEstado)
                    {
                        edo.nombre_estado = sEstado;
                    }
                    else
                    {
                        edo = EstadoSeleccionado;
                    }
                }

                if (MunicipioSeleccionado == null)
                {
                    mun.nombre_municipio = sMunicipio;
                }
                else
                {
                    if (MunicipioSeleccionado.nombre_municipio != sMunicipio)
                    {
                        mun.nombre_municipio = sMunicipio;
                    }
                    else
                    {
                        mun = MunicipioSeleccionado;
                    }
                }

                if (ColoniaSeleccionado.nombre_colonia != sColonia)
                {
                    col.nombre_colonia = sColonia;
                    col.codigo_postal = ColoniaSeleccionado.codigo_postal;
                }
                else
                {
                    col = ColoniaSeleccionado;
                }

                dir = DireccionSeleccionado;

                if (dir.calle != sDireccion)
                {
                    dir.calle = sDireccion;
                }

                if (EscolaridadSeleccionado == null)
                {
                    escola.nombre = sEscolaridad;
                }
                else
                {
                    if (EscolaridadSeleccionado.nombre != sEscolaridad)
                    {
                        escola.nombre = sEscolaridad;
                    }
                    else
                    {
                        escola = EscolaridadSeleccionado;
                    }
                }

                if (EstadoCivilSeleccionado == null)
                {
                    edoCivil.nombre = sEstadoCivil;
                }
                else
                {
                    if (EstadoCivilSeleccionado.nombre != sEstadoCivil)
                    {
                        edoCivil.nombre = sEstadoCivil;
                    } 
                    else
                    {
                        edoCivil = EstadoCivilSeleccionado;
                    }
                }

                if (NecesidadSeleccionado == null)
                {
                    nec.descripcion = sNecesidad;
                }
                else
                {
                    if (NecesidadSeleccionado.descripcion != sNecesidad)
                    {
                        nec.descripcion = sNecesidad;
                    }
                    else
                    {
                        nec = NecesidadSeleccionado;
                    }
                }

                registro.Estado = edo;
                registro.Municipio = mun;
                registro.Colonia = col;
                registro.Direccion = dir;
                registro.Escolaridad = escola;
                registro.EstadoCivil = edoCivil;
                registro.Necesidad = nec;

                try
                {
                   Registro registroexitoso = await App.oServiceManager.GuardaRegistroAsync(registro);

                    if(registroexitoso != null)
                    {
                        Estado estado = await App.DataBase.ObtieneEstados(registroexitoso.Estado.id_estado);
                        Municipio municipio = await App.DataBase.ObtieneMunicipio(registroexitoso.Municipio.id_municipio);
                        Colonia colonia = await App.DataBase.ObtieneColonias(registroexitoso.Colonia.id_colonia);
                        Direccion direccion = await App.DataBase.ObtieneDirecciones(registroexitoso.Direccion.id_direccion);
                        Escolaridad escolaridad = await App.DataBase.ObtieneEscolaridad(registroexitoso.Escolaridad.id_escolaridad);
                        EstadoCivil estadoCivil = await App.DataBase.ObtieneEstadoCivil(registroexitoso.EstadoCivil.id_estado_civil);
                        Necesidad necesidad = await App.DataBase.ObtieneNecesidades(registroexitoso.Necesidad.id_necesidad);

                        if(estado == null)
                        {
                            await App.DataBase.GuardaEstado(registroexitoso.Estado);
                        }

                        if (municipio == null)
                        {
                            await App.DataBase.GuardaMunicipio(registroexitoso.Municipio);
                        }

                        if (colonia == null)
                        {
                            await App.DataBase.GuardaColonia(registroexitoso.Colonia);
                        }

                        if (direccion == null)
                        {
                            await App.DataBase.GuardaDireccion(registroexitoso.Direccion);
                        }

                        if (escolaridad == null)
                        {
                            await App.DataBase.GuardaEscolaridad(registroexitoso.Escolaridad);
                        }

                        if (estadoCivil == null)
                        {
                            await App.DataBase.GuardaEstadoCivil(registroexitoso.EstadoCivil);
                        }

                        if (necesidad == null)
                        {
                            await App.DataBase.GuardaNecesidad(registroexitoso.Necesidad);
                        }

                        await Utilidades.ShowMessage("Notificación", "Su registro fue exitoso", "Aceptar", async () =>
                        {
                            limpiFormulario();
                        });
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio un error por favor intente mas tarde.", "Aceptar");
                    }
                } 
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Aceptar");
                }

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor verifique los campos obligatorios.", "Aceptar");
                Etapa = 0;
            }
        } 

        bool valida() {
            bool success = true;

            if (string.IsNullOrEmpty(registro.nombre))
            {
                ErrorNombreVisible = true;
                ErrorNombreMensaje = "Por favor ingrese su nombre";
                success = false;
            }
            else
            {
                ErrorNombreVisible = false;
            }

            if (string.IsNullOrEmpty(registro.apellido_paterno))
            {
                ErrorPaternoVisible = true;
                ErrorPaternoMensaje = "Por favor ingrese apellido paterno";
                success = false;
            }
            else
            {
                ErrorPaternoVisible = false;
            }

            if (string.IsNullOrEmpty(registro.apellido_materno))
            {
                ErrorMaternoVisible = true;
                ErrorMaternoMensaje = "Por favor ingrese apellido materno";
                success = false;
            } 
            else
            {
                ErrorMaternoVisible = false;
            }

            if (string.IsNullOrEmpty(registro.INE))
            {
                ErrorIneVisible = true;
                ErrorIneMensaje = "Por favor ingrese INE";
                success = false;
            }
            else
            {
                ErrorIneVisible = false;
            }

            if (string.IsNullOrEmpty(registro.email))
            {
                ErrorEmailVisible = true;
                ErrorEmailMensaje = "Por favor ingrese email";
                success = false;
            } 
            else 
            {
                if (!Validaciones.IsEmail(registro.email))
                {
                    ErrorEmailVisible = true;
                    ErrorEmailMensaje = "Su email no tiene el formato correcto";
                    success = false;
                }
                else
                {
                    ErrorEmailVisible = false;
                }
            }

            if (string.IsNullOrEmpty(sEstado))
            {
                ErrorEstadoVisible = true;
                ErrorEstadoMensaje = "Por favor ingrese su estado";
                success = false;
            }
            else
            {
                ErrorEstadoVisible = false;
            }

            if (string.IsNullOrEmpty(sMunicipio))
            {
                ErrorMunicipioVisible = true;
                ErrorMunicipioMensaje = "Por favor ingrese su municipio";
                success = false;
            }
            else
            {
                ErrorMunicipioVisible = false;
            }

            if (string.IsNullOrEmpty(sColonia))
            {
                ErrorColoniaVisible = true;
                ErrorColoniaMensaje = "Por favor ingrese su colonia";
                success = false;
            }
            else
            {
                ErrorColoniaVisible = false;
            }

            if (ColoniaSeleccionado == null)
            {
                ErrorCpVisible = true;
                ErrorCpMensaje = "Por favor ingrese Código postal";
                success = false;
            }
            else
            {
                if (string.IsNullOrEmpty(ColoniaSeleccionado.codigo_postal))
                {
                    ErrorCpVisible = true;
                    ErrorCpMensaje = "Por favor ingrese Código postal";
                    success = false;
                }
                else
                {
                    ErrorCpVisible = false;
                }
            }

            if (string.IsNullOrEmpty(sDireccion))
            {
                ErrorCalleVisible = true;
                ErrorCalleMensaje = "Por favor ingrese su calle";
                success = false;
            }
            else
            {
                ErrorCalleVisible = false;
            }

            if (DireccionSeleccionado == null)
            {
                ErrorNumeroVisible = true;
                ErrorNumeroMensaje = "Por favor ingrese su número de propiedad";
                success = false;
            }
            else
            {
                if (string.IsNullOrEmpty(DireccionSeleccionado.numero))
                {
                    ErrorNumeroVisible = true;
                    ErrorNumeroMensaje = "Por favor ingrese su número de propiedad";
                    success = false;
                } 
                else
                {
                    ErrorNumeroVisible = false;
                }
            }

            if (string.IsNullOrEmpty(sEscolaridad))
            {
                ErrorEscolaridadVisible = true;
                ErrorEscolaridadMensaje = "Por favor ingrese su escolaridad";
                success = false;
            }
            else
            {
                ErrorEscolaridadVisible = false;
            }

            if (string.IsNullOrEmpty(sNecesidad))
            {
                ErrorNecesidadVisible = true;
                ErrorNecesidadMensaje = "Por favor ingrese su necesidad";
                success = false;
            }
            else
            {
                ErrorNecesidadVisible = false;
            }

            if (string.IsNullOrEmpty(sEstadoCivil))
            {
                ErrorEstadoCivilVisible = true;
                ErrorEstadoCivildMensaje = "Por favor ingrese su estado civil";
                success = false;
            }
            else
            {
                ErrorEstadoCivilVisible = false;
            }

            return success;
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

                case "Calle":
                    IsSelectedDireccion = false;
                    break;

                case "Escolaridad":
                    IsSelectedEscolaridad = false;
                    break;

                case "EstadoCivil":
                    IsSelectedEstadoCivil = false;
                    break;

                case "Necesidad":
                    IsSelectedNecesidad = false;
                    break;
            }
        }

        public void UnfocusEnry()
        {
            valida();
        }

        public void limpiFormulario()
        {

            registro = new Registro();
            sDireccion = string.Empty;
            DireccionSeleccionado = new Direccion();
            sEscolaridad = string.Empty;
            EscolaridadSeleccionado = new Escolaridad();
            sEstadoCivil = string.Empty;
            EstadoCivilSeleccionado = new EstadoCivil();
            sNecesidad = string.Empty;
            NecesidadSeleccionado = new Necesidad();
            Etapa = 0;
            IsBusy = false;
        }
    
        public async void ObtieneUbicacion()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await Application.Current.MainPage.DisplayAlert("Ubicación", "Es necesario utilizar su Ubicación", "Aceptar");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    IsBusy = true;
                    var results = await CrossGeolocator.Current.GetPositionAsync();
                    string stEstado = string.Empty;
                    string stMunicipio = string.Empty;
                    string stColonia = string.Empty;
                    string stCalle = string.Empty;
                    string stNumero = string.Empty;
                    string stCP = string.Empty;

                    GoogleAPI ubicacion = await App.oServiceManager.ObtieneUbicacion(results.Latitude, results.Longitude);

                    foreach (AddressComponents item in ubicacion.results[0].address_components)
                    {
                        //busca estado
                        int pos = Array.IndexOf(item.types, "administrative_area_level_1");
                        if (pos > -1)
                            stEstado = item.long_name;

                        //busca municipio
                        pos = Array.IndexOf(item.types, "locality");
                        if (pos > -1)
                            stMunicipio = item.long_name;

                        //busca municipio
                        pos = Array.IndexOf(item.types, "sublocality_level_1");
                        if (pos > -1)
                            stColonia = item.long_name;

                        pos = Array.IndexOf(item.types, "route");
                        if (pos > -1)
                            stCalle = item.long_name;

                        pos = Array.IndexOf(item.types, "postal_code");
                        if (pos > -1)
                            stCP = item.long_name;

                        pos = Array.IndexOf(item.types, "street_number");
                        if (pos > -1)
                            stNumero = item.long_name;

                    }

                    if (!string.IsNullOrEmpty(stEstado))
                        await buscaEstado(stEstado);

                    if (!string.IsNullOrEmpty(stMunicipio))
                        await buscaMunicipio(stMunicipio);

                    ColoniaSeleccionado = new Colonia();
                    if (!string.IsNullOrEmpty(stColonia))
                        await buscaColonia(stColonia);

                    if (!string.IsNullOrEmpty(stCP))
                    {
                        if(ColoniaSeleccionado != null)
                        {
                            ColoniaSeleccionado.codigo_postal = stCP;
                        }
                        else
                        {
                            ColoniaSeleccionado = new Colonia();
                            ColoniaSeleccionado.codigo_postal = stCP;
                        }
                    }

                    DireccionSeleccionado = new Direccion();
                    if (!string.IsNullOrEmpty(stCalle))
                    {
                        if (DireccionSeleccionado != null)
                        {
                            DireccionSeleccionado.calle = stCalle;
                        }
                        else
                        {
                            DireccionSeleccionado = new Direccion();
                            DireccionSeleccionado.calle = stCalle;
                        }
                    }

                    if (!string.IsNullOrEmpty(stNumero))
                    {
                        if (DireccionSeleccionado != null)
                        {
                            DireccionSeleccionado.numero = stNumero;
                        }
                        else
                        {
                            DireccionSeleccionado = new Direccion();
                            DireccionSeleccionado.numero = stNumero;
                        }
                    }

                }
                else if (status != PermissionStatus.Unknown)
                {
                    await Application.Current.MainPage.DisplayAlert("Denegado", "Se nego la ubicación, no se puede continuar.", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                Debug.Print(@"Error - " + ex.Message);
            }

            IsBusy = false;
        }

        async Task buscaEstado(string estado)
        {
            await getEstados(estado);
            if (Estados.Any(i => i.nombre_estado.Contains(estado)))
            {
                EstadoSeleccionado = Estados.Where(i => i.nombre_estado.Contains(estado)).FirstOrDefault();
            }
            else
            {
                EstadoSeleccionado = new Estado();
                EstadoSeleccionado.nombre_estado = estado;
            }
        }

        async Task buscaMunicipio(string municipio)
        {
            await getMunicipios(EstadoSeleccionado.id_estado, municipio);
            if (Municipios.Any(i => i.nombre_municipio.Contains(municipio)))
            {
                MunicipioSeleccionado = Municipios.Where(i => i.nombre_municipio.Contains(municipio)).FirstOrDefault();
            }
            else
            {
                MunicipioSeleccionado = new Municipio();
                MunicipioSeleccionado.nombre_municipio = municipio;
            }
        }

        async Task buscaColonia(string colonia) {
            await getColonias(MunicipioSeleccionado.id_municipio, colonia);

            if (Colonias.Any(i => i.nombre_colonia.Contains(colonia))){
                ColoniaSeleccionado = Colonias.Where(i => i.nombre_colonia.Contains(colonia)).FirstOrDefault();
            }
            else
            {
                if (ColoniaSeleccionado != null)
                {
                    ColoniaSeleccionado.nombre_colonia = colonia;
                }
                else
                {
                    ColoniaSeleccionado = new Colonia();
                    ColoniaSeleccionado.nombre_colonia = colonia;
                }
            }
        }
    }
}
