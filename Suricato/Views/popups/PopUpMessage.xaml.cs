using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Suricato.Views.PopUps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopUpMessage : Rg.Plugins.Popup.Pages.PopupPage
    {
		public PopUpMessage(string Title, string Content, string Button)
		{
			InitializeComponent ();

            lblTitle.Text = Title;
            lblContent.Text = Content;
            btClose.Text = Button;

            btClose.Clicked += BtClose_Clicked;

        }

        private async void BtClose_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}