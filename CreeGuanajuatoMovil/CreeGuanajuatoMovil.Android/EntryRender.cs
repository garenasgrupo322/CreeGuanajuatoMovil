
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CreeGuanajuatoMovil.Custom.Controls;
using CreeGuanajuatoMovil.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEntry), typeof(EntryRender))]
namespace CreeGuanajuatoMovil.Droid
{
    public class EntryRender : EntryRenderer
    {
        public EntryRender(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {

            }
        }
    }
}
