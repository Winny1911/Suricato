using Rg.Plugins.Popup.Services;
using Suricato.DataTemplates;
using Suricato.Events;
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
	public partial class PopUpCompanies : Rg.Plugins.Popup.Pages.PopupPage
    {

        public event EventHandler<PopUpCompanyEvent> OnSelectedCompany;

        public PopUpCompanies()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            lblTitle.Text = AppResource.PopUpEmpregadoresTitulo;
            lblContent.Text = AppResource.PopUpEmpregadoresSeletor;

            var DadosLicenca = Persistence.Data.LicenceLocalData;

            lstCompanies.RowHeight = 65;
            lstCompanies.ItemTemplate = new DataTemplate(typeof(CompanyDataTemplate));
            lstCompanies.ItemSelected += lstCompanies_ItemSelected;
            lstCompanies.ItemsSource = DadosLicenca.empregador;
            lstCompanies.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                if (e.Item == null) return;
                ((ListView)sender).SelectedItem = null;
            };
        }
      

        private async void lstCompanies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;

            var selectedCompany = ((Model.Company)((ListView)sender).SelectedItem);

            if (selectedCompany != null)
            {
                OnSelectedCompany?.Invoke(this, new PopUpCompanyEvent(selectedCompany.empregador.ToString()));
            }

            await PopupNavigation.Instance.PopAsync();

        }


    }
}