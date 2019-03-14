using CreeGuanajuatoMovil.ViewModels;
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
	public partial class RegistroPage : ContentPage
	{
        private RegistroPageViewModel viewModel;

        public RegistroPage ()
		{
			InitializeComponent();
            BindingContext = viewModel = new RegistroPageViewModel();
            viewModel.Navigation = this.Navigation;
        }

        #region eventos focus

        void Handle_FocusedEstado(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            viewModel.focusEnry("Estado");
        }

        void Handle_FocusedMunicipio(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            viewModel.focusEnry("Municipio");
        }

        void Handle_FocusedColonia(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            viewModel.focusEnry("Colonia");
        }

        void Handle_FocusedCalle(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            viewModel.focusEnry("Calle");
        }

        void Handle_FocusedEscolaridad(object sender, Xamarin.Forms.FocusEventArgs e)   
        {
            viewModel.focusEnry("Escolaridad");
        }

        void Handle_FocusedEstadoCivil(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            viewModel.focusEnry("EstadoCivil");
        }

        void Handle_FocusedNecesidad(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            viewModel.focusEnry("Necesidad");
        }

        void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            viewModel.focusEnry("Seccion");
        }

        #endregion

        void Handle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            viewModel.UnfocusEnry();
        }
    }
}