using Suricato.DataTemplates;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Suricato.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class vRegisterList : ContentPage
	{
		public vRegisterList()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            MainStackLayout.Children.Insert(0, new UI.Controls.TopBar(UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.MAIN));
            MainStackLayout.Children.Insert(3, new UI.Controls.Footer());

            lstUsers.RowHeight = 65;
            lstUsers.ItemTemplate = new Xamarin.Forms.DataTemplate(typeof(UserListDataTemplate));
            lstUsers.ItemSelected += LstUsers_ItemSelected;
            lstUsers.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                if (e.Item == null) return;
                ((ListView)sender).SelectedItem = null;
            };

        }

        private void LstUsers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}