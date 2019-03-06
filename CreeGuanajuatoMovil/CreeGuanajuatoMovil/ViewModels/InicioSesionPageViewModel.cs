using CreeGuanajuatoMovil.Helpers;
using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class InicioSesionPageViewModel : ViewModelBase
    {
        #region Commands
        public INavigation Navigation { get; set; }
        public ICommand IniciaSesion { get; set; }
        public ICommand IniciaSesionQR { get; set; }
        #endregion

        #region Properties
        public ImageSource imageSorceLogo { get; set; }
        public ImageSource iconQR { get; set; }

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
            IniciaSesion = new Command(IniciaSesionAsync);
            IniciaSesionQR = new Command(IniciaSesionQRAsync);
        }


        /// <summary>
        /// Metódo para el inicio de sesión
        /// </summary>
        public async void IniciaSesionAsync() {
            IsBusy = true;
            if (!valida())
                IsBusy = false;
            else {

                Usuario usuario = await App.oServiceManager.IniciarSesion(sUsuario, sContrasena);

                if (!string.IsNullOrEmpty(usuario.message))
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("Error", usuario.message, "Aceptar");
                }
                else
                {
                    Settings.AccessToken = usuario.token;
                    Settings.NameUserLogin = usuario.nombre + " " + usuario.apellido_paterno;
                    Settings.AccessTokenType = usuario.rol;

                    ///Obtenemos los catalogos de los ws
                    List<Estado> estados = await App.oServiceManager.ObtieneEstados();
                    List<Colonia> colonias = await App.oServiceManager.ObtieneColonias();
                    List<Municipio> municipios = await App.oServiceManager.ObtieneMunicipios();
                    List<Direccion> direcciones = await App.oServiceManager.ObtieneDirecciones();
                    List<Necesidad> necesidades = await App.oServiceManager.ObtieneNecesidades();
                    List<Escolaridad> escolaridads = await App.oServiceManager.ObtieneEscolaridadAsync();
                    List<EstadoCivil> estadoCivils = await App.oServiceManager.ObtieneEstadoCivilAsync();

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

                    Settings.IsDateLogin = DateTime.Now;
                    InicioCorrectoRedireccion();
                }
            }
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
        /// Método para iniciar sesion con QR
        /// </summary>
        public async void IniciaSesionQRAsync() {
            var escaneaQR = new ZXingScannerPage();
            await Navigation.PushAsync(escaneaQR);

            escaneaQR.OnScanResult += (result) =>
            {
                // Stop scanning
                escaneaQR.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //await Navigation.PopAsync();
                    //await DisplayAlert("Scanned Barcode", result.Text, "OK");
                    InicioCorrectoRedireccion();
                });
            };
        }


        /// <summary>
        /// Funcion para redireccionar a la pantalla de registro
        /// </summary>
        public void InicioCorrectoRedireccion() {
            Settings.IsLoggedIn = true;
            Application.Current.MainPage = new MasterDetailPage()
            {
                Master = new MasterPage() { Title = "Main Page" },
                Detail = new NavigationPage(new RegistroPage())
                {
                    BarBackgroundColor = Color.White,
                    BarTextColor = Color.Gray,
                }
            };
        }
    }
}
