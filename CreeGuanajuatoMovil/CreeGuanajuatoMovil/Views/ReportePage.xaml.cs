using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreeGuanajuatoMovil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreeGuanajuatoMovil.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportePage : ContentPage
	{
        private ReportePageViewModel viewModel;

        public ReportePage(int id_estado, int id_municipio, int id_colonia, int id_escolaridad, int id_necesidad, string Busqueda)
        {
			InitializeComponent();
            BindingContext = viewModel = new ReportePageViewModel(id_estado, id_municipio, id_colonia, id_escolaridad, id_necesidad, Busqueda);
            viewModel.Navigation = this.Navigation;
        }
	}
}