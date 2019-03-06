using CreeGuanajuatoMovil.Helpers;
using CreeGuanajuatoMovil.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class MasterPageViewModel
    {
        public string NombreUsuario { get; set; }
        public bool IsUsuarioVisible { get; set; }

        public MasterPageViewModel() {
            NombreUsuario = Settings.NameUserLogin;

            if(Settings.AccessTokenType.Contains("Administrador"))
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
                            Application.Current.MainPage = new MasterDetailPage()
                            {
                                Master = new MasterPage() { Title = "Main Page" },
                                Detail = new NavigationPage(new RegistroPage())
                            };
                            break;

                        case "2":
                            Application.Current.MainPage = new MasterDetailPage()
                            {
                                Master = new MasterPage() { Title = "Main Page" },
                                Detail = new NavigationPage(new FiltrosPage())
                            };
                            break;

                        case "3":
                            Application.Current.MainPage = new MasterDetailPage()
                            {
                                Master = new MasterPage() { Title = "Main Page" },
                                Detail = new NavigationPage(new UsuariosPage())
                            };
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
