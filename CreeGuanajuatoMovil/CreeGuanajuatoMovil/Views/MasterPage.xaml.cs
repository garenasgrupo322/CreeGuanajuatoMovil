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
    public partial class MasterPage : ContentPage
    {
        private MasterPageViewModel viewModel;

        public MasterPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MasterPageViewModel();
        }
    }
}