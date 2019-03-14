using System;
using System.Collections.Generic;
using CreeGuanajuatoMovil.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreeGuanajuatoMovil.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilPage : ContentPage
    {
        private PerfilPageViewModel viewModel;

        public PerfilPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PerfilPageViewModel();
            viewModel.Navigation = this.Navigation;
        }
    }
}
