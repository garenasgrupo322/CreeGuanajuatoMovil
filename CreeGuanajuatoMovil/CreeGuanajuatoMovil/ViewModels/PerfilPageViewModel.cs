using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CreeGuanajuatoMovil.Utils;
using Xamarin.Forms;
using CreeGuanajuatoMovil.Helpers;
using CreeGuanajuatoMovil.Models;
using Plugin.Media;
using System.IO;
using CreeGuanajuatoMovil.Views;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class PerfilPageViewModel : ViewModelBase, IAsyncInitialization
    {
        public INavigation Navigation { get; internal set; }
        public ImageSource _imageProfiler;

        public ImageSource imageProfiler
        {
            get { return _imageProfiler; }
            set { SetProperty(ref _imageProfiler, value); }
        }


        public Task Initialization { get; private set; }
        public ObservableCollection<Input> PerfilSource { get; set; }
        public Command ImageProfilerCommand { get; set; }

        public PerfilPageViewModel()
        {
            if (string.IsNullOrEmpty(Settings.UserImageProfiler))
            {
                imageProfiler = ImageSource.FromResource("CreeGuanajuatoMovil.Images.profile.png");
            }
            else
            {
                var uri = new Uri(Settings.UserImageProfiler);
                imageProfiler = ImageSource.FromUri(uri);
            }

            PerfilSource = new ObservableCollection<Input>();
            ImageProfilerCommand = new Command(takePhoto);
            Initialization = InitializeAsync();
        }

        async void takePhoto()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Name = "imageProfiler.jpg"
            });

            if (file == null)
                return;

            string image = Convert.ToBase64String(ReadFully(file.GetStream()));

            await App.oServiceManager.setImageProfiler(image);

            image = string.Empty;

            Usuario user = await App.oServiceManager.ObtieneUsuarioPerfil();
            Settings.UserImageProfiler = user.url;

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

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public class Input
        {
            public string titulo { get; set; }
            public string descripcion { get; set; }
        }

        private async Task InitializeAsync()
        {
            Usuario usuario = new Usuario();
            usuario = await App.oServiceManager.ObtieneUsuarioPerfil();

            Input inputRol = new Input();
            inputRol.titulo = "Rol";
            inputRol.descripcion = usuario.roles;

            Input input = new Input();
            input.titulo = "Nombre";
            input.descripcion = usuario.nombre;

            Input inputPaterno = new Input();
            inputPaterno.titulo = "Apellido paterno";
            inputPaterno.descripcion = usuario.apellido_paterno;

            Input inputMaterno = new Input();
            inputMaterno.titulo = "Apellido materno";
            inputMaterno.descripcion = usuario.apellido_materno;

            Input inputEmail = new Input();
            inputEmail.titulo = "Correo";
            inputEmail.descripcion = usuario.Email;

            PerfilSource.Add(inputRol);
            PerfilSource.Add(input);
            PerfilSource.Add(inputPaterno);
            PerfilSource.Add(inputMaterno);
            PerfilSource.Add(inputEmail);
        }


    }
}
