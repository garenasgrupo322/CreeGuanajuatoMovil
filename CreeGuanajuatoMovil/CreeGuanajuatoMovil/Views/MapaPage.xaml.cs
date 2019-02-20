using CreeGuanajuatoMovil.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreeGuanajuatoMovil.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapaPage : ContentPage
	{
        string GooglePlacesApiKey = Constants.googleKey;

        public MapaPage ()
		{
			InitializeComponent ();
            map.UiSettings.ZoomControlsEnabled = false;
        }
	}
}