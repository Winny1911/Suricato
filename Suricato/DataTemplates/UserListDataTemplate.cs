using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Suricato.DataTemplates
{
    public class UserListDataTemplate : ViewCell
    {
        public static readonly BindableProperty pictureProperty =
           BindableProperty.Create("Picture", typeof(ImageSource), typeof(UserListDataTemplate), null);

        public ImageSource Picture
        {
            get { return (ImageSource)GetValue(pictureProperty); }
            set { SetValue(pictureProperty, value); }
        }

        public static readonly BindableProperty userNameProperty =
         BindableProperty.Create("UserName", typeof(string), typeof(UserListDataTemplate), "");

        public string UserName
        {
            get { return (string)GetValue(userNameProperty); }
            set { SetValue(userNameProperty, value); }
        }

        public static readonly BindableProperty companyProperty =
         BindableProperty.Create("Company", typeof(string), typeof(UserListDataTemplate), "");

        public string Company
        {
            get { return (string)GetValue(companyProperty); }
            set { SetValue(companyProperty, value); }
        }

        Image imgUserPicture;
        Label lblUserName;
        Label lblCompany;

        Grid dataGrid;

        public UserListDataTemplate()
        {
            try
            {
                //layout
                imgUserPicture = new Image() { Aspect = Aspect.AspectFit, HeightRequest = 65, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start };
                lblUserName = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start, FontSize = 14, TextColor = Color.Black, LineBreakMode = LineBreakMode.TailTruncation };
                lblCompany = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.End, FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = Color.Black };

                Image imgArrowRight = new Image()
                {
                    HeightRequest = 12,
                    Source = ImageSource.FromFile("right-arrow.png"),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                };

                imgUserPicture = new Image()
                {
                    HeightRequest = 65,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.Start
                };

                dataGrid = new Grid()
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    Padding = new Thickness(1),
                    ColumnDefinitions =
                    {
                        new ColumnDefinition{ Width = 65 },
                        new ColumnDefinition{ Width = GridLength.Star},
                        new ColumnDefinition{ Width = 32 }
                    },
                    RowDefinitions =
                    {
                        new RowDefinition{ Height = GridLength.Star },
                        new RowDefinition{ Height = GridLength.Star }
                    }
                };

                dataGrid.Children.Add(imgUserPicture, 0, 0);
                dataGrid.Children.Add(lblUserName, 1, 0);
                dataGrid.Children.Add(lblCompany, 1, 1);
                dataGrid.Children.Add(imgArrowRight, 2, 0); //span

                Grid.SetRowSpan(imgUserPicture, 2);
                Grid.SetRowSpan(imgArrowRight, 2);

                View = dataGrid;


            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            try
            {
                if (BindingContext != null)
                {
                    //Model.Conta user = BindingContext as Model.Conta;
                    ////imgUserPicture.Source = new Helpers.Media().Base64ToImage(user.Picture);
                    //lblUserName.Text = user.;
                    //lblCompany.Text = user.Company;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
