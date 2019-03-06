using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Utils;
using Xamarin.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class UsuariosPageViewModel : ViewModelBase, IAsyncInitialization
    {
        #region Commands
        public INavigation Navigation { get; set; }
        public Task Initialization { get; private set; }
        public ObservableCollection<Items> UsuarioItemSource { get; set; }
        #endregion

        public UsuariosPageViewModel()
        {
            UsuarioItemSource = new ObservableCollection<Items>();
            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            IsBusy = true;
            List<Usuario> usuarios = await App.oServiceManager.ObtieneUsuario();

            foreach(Usuario item in usuarios)
            {
                Items items = new Items();
                items.Nombre = item.nombre + " " + item.apellido_paterno + " " + item.apellido_materno;
                items.Rol = item.rol;

                UsuarioItemSource.Add(items);
            }

            IsBusy = false;
        }

        public class Items
        {
            public string Rol { get; set; }
            public string Nombre { get; set; }
        }
    }
}
