using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Suricato.UI.Controls
{
    public class Footer: StackLayout
    {
        public Footer()
        {
            this.VerticalOptions = LayoutOptions.EndAndExpand;
            this.Margin = new Thickness(20);
            this.Children.Add(new Image()
            {
                Style = (Style)Application.Current.Resources[AppResource.StylesFooter]
            });
        }
    }
}
