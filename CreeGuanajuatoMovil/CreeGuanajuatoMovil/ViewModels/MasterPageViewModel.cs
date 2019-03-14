using CreeGuanajuatoMovil.Helpers;
using CreeGuanajuatoMovil.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class MasterPageViewModel
    {
        public string NombreUsuario { get; set; }
        public bool IsUsuarioVisible { get; set; }
        public ImageSource imageProfiler { get; set; }

        public MasterPageViewModel() {
            NombreUsuario = Settings.NameUserLogin;

            if (string.IsNullOrEmpty(Settings.UserImageProfiler))
            {
                imageProfiler = ImageSource.FromResource("CreeGuanajuatoMovil.Images.profile.png");
            }
            else
            {
                var uri = new Uri(Settings.UserImageProfiler);
                imageProfiler = ImageSource.FromUri(uri);
            }


            if (Settings.AccessTokenType.Contains("Administrador"))
            {
                IsUsuarioVisible = true;
            }
            else
            {
                IsUsuarioVisible = false;
            }

        }

        public ICommand NavigationCommand
        {
            get
            {
                return new Command((value) =>
                {
                    // COMMENT: This is just quick demo code. Please don't put this in a production app.
                    var mdp = (Application.Current.MainPage as MasterDetailPage);
                    var navPage = mdp.Detail as NavigationPage;

                    // Hide the Master page
                    mdp.IsPresented = false;

                    switch (value)
                    {
                        case "1":
                            navPage.PushAsync(new RegistroPage());
                            break;

                        case "2":
                            navPage.PushAsync(new FiltrosPage());
                            break;

                        case "3":
                            navPage.PushAsync(new UsuariosPage());
                            break;

                        case "4":
                            navPage.PushAsync(new LegalesPage());
                            break;

                        case "5":
                            navPage.PushAsync(new PerfilPage());
                            break;

                        case "100":
                            Settings.IsLoggedIn = false;
                            App.DataBase.dropTables();
                            Application.Current.MainPage = new NavigationPage(new InicioSesionPage());
                            break;
                    }

                });
            }
        }
    }
}
