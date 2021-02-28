using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Suricato.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class vNewUser : ContentPage
	{
		public vNewUser()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            MainStackLayout.Children.Insert(0, new UI.Controls.TopBar(UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.MAIN));
            MainStackLayout.Children.Insert(3, new UI.Controls.Footer());

            btNext.Clicked += BtProsseguir_Clicked; 
        }

        private void BtProsseguir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new vStepsPin(), false);

        }
    }
}