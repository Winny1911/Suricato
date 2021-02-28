using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
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
	public partial class vUserChekin : ContentPage
	{
        PopUps.PopUpCompanies popUpCompanies;
        string selectedCompanyId;
		public vUserChekin()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            MainStackLayout.Children.Insert(0, new UI.Controls.TopBar(UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.STEPS, 1));
            MainStackLayout.Children.Insert(1, new UI.Controls.Header(AppResource.InicioDadosTitulo, AppResource.InicioDadosConteudo));
            MainStackLayout.Children.Insert(3, new UI.Controls.Footer());

            //eMatricula.Placeholder = AppResource.PalavraMatricula;
            //eEmail.Placeholder = AppResource.PalavraEmail;
            listViewPlaceHolder.Text = AppResource.ListBoxCompanhia;
            grdCompanyListTrigger.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushPopupAsync(popUpCompanies, false);
                })
            });
            btProsseguir.Clicked += BtProsseguir_Clicked;
            popUpCompanies = new PopUps.PopUpCompanies();
            popUpCompanies.OnSelectedCompany += PopUpEmpresas_OnSelectedCompany;
        }

        private void PopUpEmpresas_OnSelectedCompany(object sender, Events.PopUpCompanyEvent e)
        {
            selectedCompanyId = e.companySuricatoId;
            listViewPlaceHolder.Text = Persistence.Data.LicenceLocalData.empregador.Where(x => x.empregador.Equals(selectedCompanyId)).FirstOrDefault().razao_social;
        }

        private void BtProsseguir_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new vStepsPin(), false);
            CheckUserAccount();
        }

        private void CheckUserAccount()
        {
            if(string.IsNullOrEmpty(selectedCompanyId))
            {
                Navigation.PushPopupAsync(new PopUps.PopUpMessage("Empresa", "Selecione uma empresa", "Ok"));
                return;
            }

            Model.APIInfoReturn api_return = new ViewModel.User().Validate(
                Persistence.Data.LicenceLocalData.empregador[0].licenca.suricato_key,
                selectedCompanyId, 
                eMatricula.Text,
                eEmail.Text,
                ""
                );

            if (!api_return.Return_status.Equals("200"))
            {
                Navigation.PushPopupAsync(new PopUps.PopUpMessage("Validação de Conta", api_return.Return_message, "Ok"));
            }
            else
            {
                List<Model.Account> accounts = Persistence.Data.UsersLocalData;

                if (accounts == null)
                {
                    accounts = new List<Model.Account>();
                }


            }

        }
    }
}