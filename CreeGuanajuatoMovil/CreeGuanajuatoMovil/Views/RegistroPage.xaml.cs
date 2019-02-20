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
	}
}