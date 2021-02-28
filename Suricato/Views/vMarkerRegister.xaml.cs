using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Extensions;
using Suricato.Views.PopUps;
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
    public partial class vMarkerRegister : ContentPage
	{
		public vMarkerRegister()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);

            MainStackLayout.Children.Insert(0, new UI.Controls.TopBar(UI.Controls.TopBar.ACTION_SUB_BAR_TYPE.NONE));
             MainStackLayout.Children.Insert(MainStackLayout.Children.Count(), new UI.Controls.Footer());

            lblContent.Text = AppResource.RegistrarPontoInfo;
            btNext.Text = AppResource.RegistrarPonto;

            btNext.Clicked += btNext_Clicked;

        }


        private async void btNext_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            try
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Navigation.PushPopupAsync(new PopUpMessage(AppResource.TituloAcessoCamera, AppResource.CameraBloqueadaConteudo, AppResource.TextoBotaoGenericoFechar));
                    return;
                }

                string fileName = string.Format("reg_{0}_{1}.jpg", Persistence.Data.CurrentUserLocalData.matricula.ToString(), DateTime.Now.ToString("ddMMyyyyHHmmss"));

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = false,
                    Directory = "SuricatoLocalData",
                    Name = fileName,
                    PhotoSize = PhotoSize.Small,
                    CustomPhotoSize = 80,
                    CompressionQuality = 50
                });

                //if (file != null)
                //    new Controller.RegisterMark().AddRegisterMark(file);

                file.Dispose();

               // await Navigation.PushAsync(new vMain(true), false);

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                await Navigation.PushPopupAsync(new PopUpMessage(AppResource.Alerta, err.Message, AppResource.TextoBotaoGenericoFechar));
            }
            finally
            {
               
            }
        }
    }
}