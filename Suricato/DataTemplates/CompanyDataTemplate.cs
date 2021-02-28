using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Suricato.DataTemplates
{
    public class CompanyDataTemplate : ViewCell
    {

        public static readonly BindableProperty CompanyNameProperty =
          BindableProperty.Create("CompanyName", typeof(string), typeof(CompanyDataTemplate), null);

        public string CompanyName
        {
            get { return (string)GetValue(CompanyNameProperty); }
            set { SetValue(CompanyNameProperty, value); }
        }

        Label lblCompany;

        Grid dataGrid;

        public CompanyDataTemplate()
        {
            try
            {
                //layout
                lblCompany = new Label() {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    FontSize = 14,
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Color.Black };

                Image imgArrowRight = new Image()
                {
                    HeightRequest = 12,
                    Source = ImageSource.FromFile("right_arrow.png"),
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                };

                dataGrid = new Grid()
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    Padding = new Thickness(1),
                    ColumnDefinitions =
                    {
                        new ColumnDefinition{ Width = GridLength.Star},
                        new ColumnDefinition{ Width = 32 }
                    }
                };
                dataGrid.Children.Add(lblCompany, 0, 0);
                dataGrid.Children.Add(imgArrowRight, 1, 0);
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
                    Model.Company item = BindingContext as Model.Company;
                    lblCompany.Text = item.razao_social.ToUpper();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

