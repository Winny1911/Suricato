using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Suricato.UI.Controls
{
    public class RegistrationTableHeader: Grid
    {
        public RegistrationTableHeader()
        {

            //header
            Grid dataGridHeader = new Grid()
            {
                BackgroundColor = Color.FromHex("#CCCCCC"),
                HorizontalOptions = LayoutOptions.Fill,
                Padding = new Thickness(0),
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = GridLength.Star },
                    new ColumnDefinition{ Width = GridLength.Star},
                    new ColumnDefinition{ Width = GridLength.Star }
                }
            };

            Label lblDateHeader = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 14, TextColor = Color.Black, LineBreakMode = LineBreakMode.TailTruncation, Text = "DATA" };
            Label lblRegistrationHeader = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 14, TextColor = Color.Black, LineBreakMode = LineBreakMode.TailTruncation, Text = "MARCAÇÂO" };
            Image IndicatorHeader = new Image() { }; //implementar

            dataGridHeader.Children.Add(lblDateHeader, 0, 0);
            dataGridHeader.Children.Add(lblRegistrationHeader, 1, 0);
            dataGridHeader.Children.Add(IndicatorHeader, 2, 0);

            this.Children.Add(dataGridHeader);

        }
    }
}
