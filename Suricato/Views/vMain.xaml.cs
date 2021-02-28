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
    public partial class vMain : ContentPage
	{
        public vMain(bool ShowRegisterMark=false)
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            MainStackLayout.Children.Insert(0, new UI.Controls.TopBar(UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.MAIN));
            MainStackLayout.Children.Insert(MainStackLayout.Children.Count(), new UI.Controls.Footer());
           // lblContent.Text = string.Format(AppResource.PrincipalConteudo, Persistence.Data.UserStorage.Name.ToUpper());

            lblMarkEntrance.Text = AppResource.PrincipalOpcaoMarcarPonto;
            lblMarksList.Text = AppResource.PrincipalEspelhoPonto;
            lblNewUser.Text = AppResource.PrincipalNovoUsuario;

            btEntraceMark.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new vMarkerRegister(), false);
                })
            });

            btMarksMirror.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new vNewUser(), false);
                })
            });

            btNewUser.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new vNewUser(), false);
                })
            });

            try
            {
                //control if need show or not the picture
                if (ShowRegisterMark)
                {
                    imgRegisterMark.Source = new Controller.RegisterMark().GetLastBase64MarkRegister();

                    if (imgRegisterMark != null)
                    {
                        StackInfo.IsVisible = false;
                        StackMark.IsVisible = true;
                    }
                }
            }
            catch (Exception err)
            {
                Navigation.PushAsync(new PopUps.PopUpMessage(AppResource.Alerta, err.Message, AppResource.TextoBotaoGenericoFechar));
            }
        }

    }
}