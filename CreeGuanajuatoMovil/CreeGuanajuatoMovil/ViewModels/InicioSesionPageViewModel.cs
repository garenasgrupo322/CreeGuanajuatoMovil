using CreeGuanajuatoMovil.Helpers;
using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class InicioSesionPageViewModel : ViewModelBase
    {
        #region Commands
        public INavigation Navigation { get; set; }
        public ICommand IniciaSesion { get; set; }
        public ICommand IniciaSesionQR { get; set; }
        public ICommand legalesCommand { get; set; }
        #endregion

        #region Properties
        public ImageSource imageSorceLogo { get; set; }
        public ImageSource imageHR { get; set; }
        public ImageSource iconQR { get; set; }
        public ImageSource imageEntry { get; set; }

        private string _ErrorUsuarioMensaje;

        public string ErrorUsuarioMensaje
        {
            get { return _ErrorUsuarioMensaje; }
            set { SetProperty(ref _ErrorUsuarioMensaje, value); }
        }

        private bool _ErrorUsuarioVisible;

        public bool ErrorUsuarioVisible
        {
            get { return _ErrorUsuarioVisible; }
            set { SetProperty(ref _ErrorUsuarioVisible, value); }
        }

        private string _ErrorContraMensaje;

        public string ErrorContraMensaje
        {
            get { return _ErrorContraMensaje; }
            set { SetProperty(ref _ErrorContraMensaje, value); }
        }

        private bool _ErrorContraVisible;

        public bool ErrorContraVisible
        {
            get { return _ErrorContraVisible; }
            set { SetProperty(ref _ErrorContraVisible, value); }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _sUsuario;

        public string sUsuario
        {
            get { return _sUsuario; }
            set { SetProperty(ref _sUsuario, value); }
        }

        private string _sContrasena;

        public string sContrasena
        {
            get { return _sContrasena; }
            set { SetProperty(ref _sContrasena, value); }
        }

        #endregion

        public InicioSesionPageViewModel() {
            imageSorceLogo = ImageSource.FromResource("CreeGuanajuatoMovil.Images.logo_color.png");
            iconQR = ImageSource.FromResource("CreeGuanajuatoMovil.Images.code_qr.png");
            imageHR = ImageSource.FromResource("CreeGuanajuatoMovil.Images.hr_up.png");
            imageEntry = ImageSource.FromResource("CreeGuanajuatoMovil.Images.Entry.png");
            IniciaSesion = new Command(IniciaSesionAsync);
            IniciaSesionQR = new Command(IniciaSesionQRAsync);
            legalesCommand =  new Command(RedireccionaLegales);
        }

        async void RedireccionaLegales() {
            await Navigation.PushAsync(new LegalesPage());
        }


        /// <summary>
        /// Metódo para el inicio de sesión
        /// </summary>
        public async void IniciaSesionAsync() {
            IsBusy = true;
            if (!valida())
                IsBusy = false;
            else {

                string usuario = await App.oServiceManager.IniciarSesion(sUsuario, sContrasena);

                if (string.IsNullOrEmpty(usuario))
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "Usuario incorrecto", "Aceptar");
                }
                else
                {

                    Settings.AccessToken = usuario;
                    ///Obtenemos los catalogos de los ws
                    await loadData();

                    Usuario user = await App.oServiceManager.ObtieneUsuarioPerfil();
                    InicioCorrectoRedireccion(user);
                }
            }
        }

        async Task loadData()
        {
            List<Estado> estados = await App.oServiceManager.ObtieneEstados();
            List<Colonia> colonias = await App.oServiceManager.ObtieneColonias();
            List<Municipio> municipios = await App.oServiceManager.ObtieneMunicipios();
            List<Direccion> direcciones = await App.oServiceManager.ObtieneDirecciones();
            List<Necesidad> necesidades = await App.oServiceManager.ObtieneNecesidades();
            List<Escolaridad> escolaridads = await App.oServiceManager.ObtieneEscolaridadAsync();
            List<EstadoCivil> estadoCivils = await App.oServiceManager.ObtieneEstadoCivilAsync();
            List<Seccion> seccions = await App.oServiceManager.ObtieneSeccionales();

            ///Eliminamos tablas de la base de datos
            App.DataBase.dropTables();

            //Guardamos nuevos datos en base de datos local
            await App.DataBase.GuardaEstado(estados);
            await App.DataBase.GuardaMunicipio(municipios);
            await App.DataBase.GuardaColonia(colonias);
            await App.DataBase.GuardaDireccion(direcciones);
            await App.DataBase.GuardaNecesidad(necesidades);
            await App.DataBase.GuardaEscolaridad(escolaridads);
            await App.DataBase.GuardaEstadoCivil(estadoCivils);
            await App.DataBase.GuardaSeccion(seccions);
        }


        /// <summary>
        /// Validaciones de usuario y contraseña
        /// </summary>
        public bool valida() {
            bool success = true;

            if (string.IsNullOrEmpty(sUsuario))
            {
                success = false;
                ErrorUsuarioVisible = true;
                ErrorUsuarioMensaje = "Por favor ingrese su usuario";
            }
            else
            {
                ErrorUsuarioVisible = false;
            }

            if (string.IsNullOrEmpty(sContrasena))
            {
                success = false;
                ErrorContraVisible = true;
                ErrorContraMensaje = "Por favor ingrese su contraseña";
            }
            else
            {
                ErrorContraVisible = false;
            }

            return success;

        }

        /// <summary>
        /// Metodo para iniciar sesion con QR
        /// </summary>
        public async void IniciaSesionQRAsync() {
            var options = new MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.QR_CODE,
                BarcodeFormat.CODABAR
            };

            var escaneaQR = new ZXingScannerPage(options) { Title = "Escanear Código" };

            var closeItem = new ToolbarItem { Text = "Close" };
            closeItem.Clicked += (object sender, EventArgs e) =>
            {
                escaneaQR.IsScanning = false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                });
            };

            escaneaQR.ToolbarItems.Add(closeItem);

            escaneaQR.OnScanResult += (result) =>
            {
                escaneaQR.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () => {

                    if (string.IsNullOrEmpty(result.Text))
                    {
                        await Application.Current.MainPage.DisplayAlert("Notificacion", "El código escaneado no es valido", "Aceptar");
                    }
                    else
                    {
                        Settings.AccessToken = string.Empty;
                        Settings.AccessToken = result.Text;

                        if (await App.oServiceManager.IniciarSesionToken())
                        {
                            Usuario user = await App.oServiceManager.ObtieneUsuarioPerfil();
                            await loadData();
                            InicioCorrectoRedireccion(user);
                        }
                        else
                        {
                            Settings.AccessToken = string.Empty;
                            await Application.Current.MainPage.DisplayAlert("Notificacion", "Por favor veririfique su codigo con el admisnistrador", "Aceptar");
                        }
                    }

                    await Navigation.PopAsync();
                });
            };

            await Navigation.PushAsync(escaneaQR);
        }

        /// <summary>
        /// Funcion para redireccionar a la pantalla de registro
        /// </summary>
        public void InicioCorrectoRedireccion(Usuario usuario) {
            Settings.NameUserLogin = usuario.nombre + " " + usuario.apellido_paterno;
            Settings.AccessTokenType = usuario.roles;
            Settings.UserImageProfiler = usuario.url;
            Settings.IsDateLogin = DateTime.Now;
            Settings.IsLoggedIn = true;

            Application.Current.MainPage = new MasterDetailPage()
            {
                Master = new MasterPage() { Title = "Menú" },
                Detail = new NavigationPage(new RegistroPage())
                {
                    BarBackgroundColor = Color.White,
                    BarTextColor = Color.Gray,
                }
            };
        }
    }
}
