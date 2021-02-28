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
    public partial class vMessage : ContentPage
	{

        private Page pageToRedirect;

        public vMessage(string Content="", bool showTopBar=false, UI.Controls.TopBar.ACTION_SUB_BAR_TYPE Type = UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.MAIN, int Step=0, Page PageToRedirect =null, string ButtonLabel="PROSSEGUIR" )
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            if (showTopBar){
                MainStackLayout.Children.Insert(0, new UI.Controls.TopBar(Type, Step>0?Step:0));
            }

            MainStackLayout.Children.Insert(MainStackLayout.Children.Count(), new UI.Controls.Footer());

            lblContent.Text = Content;
            pageToRedirect = PageToRedirect;
            btIniciar.Text = ButtonLabel;

            btIniciar.Clicked += BtIniciar_Clicked;

        }


        private void BtIniciar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(pageToRedirect, false);
        }
    }
}