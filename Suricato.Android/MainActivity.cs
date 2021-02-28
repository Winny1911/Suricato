using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using SaturdayMP.XPlugins.Notifications.Droid;
using Android.Content;
using Rg.Plugins.Popup;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Android;
using Android.Support.V4.App;
using Plugin.CurrentActivity;

namespace Suricato.Droid
{
    [Activity(Theme = "@style/suricato.Splash", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            DependencyService.Register<NotificationScheduler>();
            Popup.Init(this, bundle);
            CrossCurrentActivity.Current.Activity = this;
            SolicitarPermissoes();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            var listener = new NotificationListener();
            listener.NotificationRecieved(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
        }

        private void SolicitarPermissoes()
        {
            try
            {
                string[] permissoes = new string[]
                {
                    Manifest.Permission.ReadPhoneState,
                    Manifest.Permission.AccessCoarseLocation,
                    Manifest.Permission.AccessFineLocation,
                    Manifest.Permission.AccessLocationExtraCommands,
                    Manifest.Permission.AccessNetworkState,
                    Manifest.Permission.AccessWifiState,
                    Manifest.Permission.ReadExternalStorage,
                    Manifest.Permission.Camera,
                    Manifest.Permission.CallPhone,
                    Manifest.Permission.Internet,
                    Manifest.Permission.AccessMockLocation,
                    Manifest.Permission.WakeLock,
                    Manifest.Permission.MediaContentControl
                };

                int codigo = 1;
                foreach (string permissao in permissoes)
                {
                    if (Android.Support.V4.App.ActivityCompat.CheckSelfPermission(this, permissao) != Android.Content.PM.Permission.Granted)
                    {
                        ActivityCompat.RequestPermissions(this, new String[] { permissao }, codigo);
                        codigo++;
                    }
                }
            }
            catch (Exception)
            {
            }
        }


    }
}

