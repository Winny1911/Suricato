using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Extensions;

namespace Suricato.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class vStepsPinMatch : ContentPage
	{
		public vStepsPinMatch()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            UI.Controls.PinControl pinControl = new UI.Controls.PinControl(true, Persistence.Session.Instance.Pin);

            MainStackLayout.Children.Insert(0, new UI.Controls.TopBar(UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.STEPS,3));
            MainStackLayout.Children.Insert(1, new UI.Controls.Header(AppResource.InicioSenhaConfirmaTitulo, AppResource.InicioSenhaConfirmaConteudo));
            MainStackLayout.Children.Insert(2, pinControl.RenderPinControl());
            MainStackLayout.Children.Insert(3, new UI.Controls.Footer());

            pinControl.OnDoAction += PinControl_OnDoAction;

        }

        private void PinControl_OnDoAction(object sender, UI.Controls.PinControlEvents e)
        {
            UI.Controls.PinControlEvents.ACTIONS action = ((UI.Controls.PinControlEvents.ACTIONS)e.action);

            if (action == UI.Controls.PinControlEvents.ACTIONS.GO_NEXT_VIEW)
            {
                Navigation.PushAsync(new Suricato.Views.vMessage(
                AppResource.InicioConteudoFinal,
                true,
                UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.STEPS,
                4,
                new Views.vMain(),
                AppResource.Iniciar));
            }
            else if (action == UI.Controls.PinControlEvents.ACTIONS.PINS_NOT_MATCH) {
                Navigation.PushPopupAsync(new PopUps.PopUpMessage(AppResource.InicioSenhaConfirmaTituloPopup, AppResource.InicioSenhaConfirmaNaoBatePopUp, AppResource.TextoBotaoGenericoFechar));
            };
        }
    }
}