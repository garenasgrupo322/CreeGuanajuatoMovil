using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Utils;
using Xamarin.Forms;

namespace CreeGuanajuatoMovil.ViewModels
{
    public class ReportePageViewModel : ViewModelBase, IAsyncInitialization
    {
        #region Commands
        public INavigation Navigation { get; set; }
        public Command OnClickable { get; set; }
        #endregion

        public Task Initialization { get; private set; }

        public ObservableCollection<Registro> RegistrosItemSource { get; set; }

        public int id_estado { get; set; }
        public int id_municipio { get; set; }
        public int id_colonia { get; set; }
        public int id_escolaridad { get; set; }
        public int id_necesidad { get; set; }
        public string Busqueda { get; set; }

        public ReportePageViewModel(int id_estado, int id_municipio, int id_colonia, int id_escolaridad, int id_necesidad, string Busqueda)
        {
            this.id_estado = id_estado;
            this.id_municipio = id_municipio;
            this.id_colonia = id_colonia;
            this.id_escolaridad = id_escolaridad;
            this.id_necesidad = id_necesidad;
            this.Busqueda = Busqueda;

            RegistrosItemSource = new ObservableCollection<Registro>();
            Initialization = InitializeAsync();
            OnClickable = new Command<View>((view) =>
            {
                view?.Focus();
            });
        }

        private async Task InitializeAsync()
        {
            List<Registro> list = await App.oServiceManager.ObtieneRegistrosFiltradosAsync(id_estado, id_municipio, id_colonia, id_escolaridad, id_necesidad, Busqueda);

            foreach (Registro item in list)
            {
                item.nombre_completo = item.nombre + "  " + item.apellido_paterno + " " + item.apellido_materno; 
                RegistrosItemSource.Add(item);
            }
        }
    }
}
