using CreeGuanajuatoMovil.Models;
using CreeGuanajuatoMovil.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace CreeGuanajuatoMovil.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapaPage : ContentPage, IAsyncInitialization
    {
        string GooglePlacesApiKey = Constants.googleKey;
        bool bEntro = false;
        public Task Initialization { get; private set; }
        public int id_estado { get; set; }
        public int id_municipio { get; set; }
        public int id_colonia { get; set; }
        public int id_escolaridad { get; set; }
        public int id_necesidad { get; set; }
        public string Busqueda { get; set; }

        public MapaPage (int id_estado, int id_municipio, int id_colonia, int id_escolaridad, int id_necesidad, string Busqueda)
		{
            this.id_estado = id_estado;
            this.id_municipio = id_municipio;
            this.id_colonia = id_colonia;
            this.id_escolaridad = id_escolaridad;
            this.id_necesidad = id_necesidad;
            this.Busqueda = Busqueda;

            InitializeComponent ();
            map.UiSettings.ZoomControlsEnabled = false;
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(21.1218994, -101.7360513), Distance.FromMeters(8000)), true);
            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            consultaRegistros();
        }

        async void consultaRegistros()
        {
            List<Registro> registros = await App.oServiceManager.ObtieneRegistrosFiltradosAsync(id_estado, id_municipio, id_colonia, id_escolaridad, id_necesidad, Busqueda);
            bEntro = false;

            foreach (Registro item in registros)
            {
                if (!item.latitud.Equals(0) && !item.longitud.Equals(0))
                {
                    addMarker(item);
                }
            }
        }

        void addMarker(Registro registro)
        {
            if(!bEntro) {
                bEntro = true;
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(registro.latitud, registro.longitud), Distance.FromMeters(8000)), true);
            }

            Position position = new Position(registro.latitud,
                registro.longitud);

            Pin pin = new Pin()
            {
                Icon = BitmapDescriptorFactory.FromBundle("pin.png"),
                Type = PinType.Place,
                Label = registro.Necesidad.descripcion,
                Position = position,
                Address = registro.nombre_completo
            };

            map.Pins.Add(pin);
        }
    }
}