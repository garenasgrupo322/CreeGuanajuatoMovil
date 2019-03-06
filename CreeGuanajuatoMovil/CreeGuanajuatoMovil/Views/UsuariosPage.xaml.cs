using System;
using System.Collections.Generic;
using CreeGuanajuatoMovil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreeGuanajuatoMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuariosPage : ContentPage
    {
        private UsuariosPageViewModel viewModel;

        public UsuariosPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UsuariosPageViewModel();
            viewModel.Navigation = this.Navigation;
        }
    }
}
