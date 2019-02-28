using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreeGuanajuatoMovil.Utils
{
    public class Utilidades
    {
        public static async Task ShowMessage(string title,
            string message,
            string buttonText,
            Action afterHideCallback)
        {
            await App.Current.MainPage.DisplayAlert(
                title,
                message,
                buttonText);

            afterHideCallback?.Invoke();
        }
    }
}
