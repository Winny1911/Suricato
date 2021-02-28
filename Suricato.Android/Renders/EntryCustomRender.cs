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
using Suricato.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(EntryCustomRender))]
namespace Suricato.Droid.Renders
{
    public class EntryCustomRender : EntryRenderer
    {
        public EntryCustomRender()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.White);
            //Control?.SetHeight(60);
            Control?.SetPadding(10,10,10,10);
            
        }
    }
}