using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Suricato
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            Suricato.Design.Theme.LoadTheme();

            //check persistent data
            var licenceLocalData = Persistence.Data.LicenceLocalData;

            if (licenceLocalData != null)
            {
                var usersLocalData = Persistence.Data.UsersLocalData;

                if (usersLocalData != null)
                {
                    MainPage = new NavigationPage(new Views.vUserList());
                }
                else
                {
                    MainPage = new NavigationPage(new Views.vUserChekin());
                }
            }
            else
            {
                MainPage = new NavigationPage(new Views.vLicenceValidation());
            }
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
