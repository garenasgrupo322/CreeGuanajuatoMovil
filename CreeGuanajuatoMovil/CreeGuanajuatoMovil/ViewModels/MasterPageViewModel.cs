using CreeGuanajuatoMovil.Helpers;
using CreeGuanajuatoMovil.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class MasterPageViewModel
    {
        public string NombreUsuario { get; set; }

        public MasterPageViewModel() {
            NombreUsuario = Settings.NameUserLogin;
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
                            navPage.PushAsync(new RegistroPage());
                            break;
                        case "100":
                            Settings.IsLoggedIn = false;
                            App.Current.MainPage = new NavigationPage(new InicioSesionPage());
                            break;
                    }

                });
            }
        }
    }
}
