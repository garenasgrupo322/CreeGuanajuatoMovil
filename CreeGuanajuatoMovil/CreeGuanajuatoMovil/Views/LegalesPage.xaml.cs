using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreeGuanajuatoMovil.Utils;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace CreeGuanajuatoMovil.Views
{
    public partial class LegalesPage : ContentPage, IAsyncInitialization
    {
        public Task Initialization { get; private set; }

        public LegalesPage()        
        {
            InitializeComponent();
            activity.IsRunning = true;
            Initialization = InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            string list = await App.oServiceManager.ObtieneLegales();

            string[] br = list.Split(new string[] { "<br>" }, StringSplitOptions.None);

            StackLayout stackAll = new StackLayout();
            stackAll.Margin = 30;

            foreach (string item in br)
            {

                string textto = string.Empty;
                Label label = new Label();

                if (item.Contains("<center>"))
                {
                    int inicio = item.IndexOf("<center>");
                    int fin = item.IndexOf("</center>");
                    textto = item;
                    textto = textto.Replace("<center>", string.Empty);
                    textto = textto.Replace("</center>", string.Empty);
                    label.FontSize = 30;
                    label.Margin = 30;
                }

                if (item.Contains("<tel>"))
                {
                    int inicio = item.IndexOf("<tel>");
                    int fin = item.IndexOf("</tel>");
                    textto = item;
                    textto = textto.Replace("<tel>", string.Empty);
                    textto = textto.Replace("</tel>", string.Empty);
                    label.FontSize = 20;
                    label.Margin = 10;
                    label.TextColor = Color.SkyBlue;

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) => {
                        try
                        {
                            PhoneDialer.Open(textto);
                        }
                        catch (ArgumentNullException anEx)
                        {
                            // Number was null or white space
                        }
                        catch (FeatureNotSupportedException ex)
                        {
                            // Phone Dialer is not supported on this device.
                        }
                        catch (Exception ex)
                        {
                            // Other error has occurred.
                        }
                    };
                    label.GestureRecognizers.Add(tapGestureRecognizer);
                }

                if (item.Contains("<url>"))
                {
                    int inicio = item.IndexOf("<url>");
                    int fin = item.IndexOf("</url>");
                    textto = item;
                    textto = textto.Replace("<url>", string.Empty);
                    textto = textto.Replace("</url>", string.Empty);    
                    label.FontSize = 20;
                    label.Margin = 10;
                    label.TextColor = Color.SkyBlue;

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) => {
                        var uri = new Uri(textto);
                        Browser.OpenAsync(uri);
                    };
                    label.GestureRecognizers.Add(tapGestureRecognizer);
                }


                label.Text = textto;

                StackLayout stack = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    Children = { label }
                };

                stackAll.Children.Add(stack);
            }

            Content = stackAll;
            activity.IsRunning = false;
        }
    }
}
