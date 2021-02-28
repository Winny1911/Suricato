using Rg.Plugins.Popup.Extensions;
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
    public partial class vLicenceValidation : ContentPage
	{
		public vLicenceValidation()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            MainStackLayout.Children.Insert(0, new UI.Controls.TopBar(UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.NONE));
            MainStackLayout.Children.Insert(1, new UI.Controls.Header(AppResource.InicioIntroTitulo, AppResource.InicioIntroConteudo));
            MainStackLayout.Children.Insert(MainStackLayout.Children.Count(), new UI.Controls.Footer());

            lblContent.Text = AppResource.InicioInfo;
            btNext.Text = AppResource.Iniciar;

            btNext.Clicked += BtIniciar_Clicked;

        }


        private void BtIniciar_Clicked(object sender, EventArgs e)
        {
            new ViewModel.Licence().LicenceRegistration(entSuricatoKey.Text);

            var licence_local_data = Persistence.Data.LicenceLocalData;

            if(licence_local_data!=null && licence_local_data.Return_status.Equals("200"))
            {
                Navigation.PushAsync(new vUserChekin(), false);
            }
            else
            {
                Navigation.PushPopupAsync(new PopUps.PopUpMessage("Licença de Uso", licence_local_data.Return_message, "Ok"));
            }
        }

        private void ProcessRegisration()
        {
            throw new NotImplementedException();
        }
    }
}