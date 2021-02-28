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
	public partial class vStepsPin : ContentPage
	{

        //public string pin;

		public vStepsPin()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            UI.Controls.PinControl pinControl = new UI.Controls.PinControl();

            MainStackLayout.Children.Insert(0, new UI.Controls.TopBar(UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.STEPS,2));
            MainStackLayout.Children.Insert(1, new UI.Controls.Header(AppResource.InicioSenhaTitulo, AppResource.InicioSenhaConteudo));
            MainStackLayout.Children.Insert(2, pinControl.RenderPinControl());
            MainStackLayout.Children.Insert(3, new UI.Controls.Footer());

            pinControl.OnDoAction += PinControl_OnDoAction;

        }

        private void PinControl_OnDoAction(object sender, UI.Controls.PinControlEvents e)
        {
            if (((UI.Controls.PinControlEvents.ACTIONS) e.action)== UI.Controls.PinControlEvents.ACTIONS.GO_NEXT_VIEW)
            {
                Persistence.Session.Instance.Pin = (string)e.pin;
                Navigation.PushAsync(new vStepsPinMatch());
            };
        }
    }
}