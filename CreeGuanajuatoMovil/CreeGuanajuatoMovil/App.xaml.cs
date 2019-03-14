using CreeGuanajuatoMovil.Database;
using CreeGuanajuatoMovil.Helpers;
using CreeGuanajuatoMovil.Views;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CreeGuanajuatoMovil
{
    public partial class App : Application
    {
        public static Services.ServiceManager oServiceManager { get; private set; }
        static dbLogic database;


        public App()
        {
            InitializeComponent();

            ///Implementamos la intancia para el consumo de ws
            oServiceManager = new Services.ServiceManager(new Services.RestService());

            if (Settings.IsLoggedIn)
            {
                TimeSpan ts = DateTime.Now - Settings.IsDateLogin;

                if (ts.Days > 0) {
                    Settings.AccessToken = string.Empty;
                    Settings.NameUserLogin = string.Empty;
                    Settings.AccessTokenType = string.Empty;
                    Settings.IsLoggedIn = false;
                    MainPage = new NavigationPage(new InicioSesionPage());
                }
                else
                {
                    MainPage = new MasterDetailPage()
                    {
                        Master = new MasterPage() { Title = "Menú" },
                        Detail = new NavigationPage(new RegistroPage())
                        {
                            BarBackgroundColor = Color.White,
                            BarTextColor = Color.Gray
                        }
                    };
                }
            }
            else {
                MainPage = new NavigationPage(new InicioSesionPage());
            }

        }

        public static dbLogic DataBase
        {
            get
            {
                if (database == null)
                {
                    try
                    {
                        database = new dbLogic(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CreeEnGuanajuato.db3"));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(@"ERROR {0}", ex.Message);
                    }
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
