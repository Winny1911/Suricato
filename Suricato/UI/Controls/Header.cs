using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Suricato.UI.Controls
{
    public class Header: Grid
    {

        public Header(string Title, string Content)
        {

            this.Style = (Style)Application.Current.Resources["header_grid"];
            this.ColumnDefinitions = new ColumnDefinitionCollection()
            {
                 new ColumnDefinition{ Width = 100 },
                 new ColumnDefinition{ Width = GridLength.Star},
            };

            this.RowDefinitions = new RowDefinitionCollection()
            {
                 new RowDefinition{ Height = GridLength.Auto},
                 new RowDefinition{ Height = GridLength.Auto},
            };

            Image avatar = new Image() { Style = (Style)Application.Current.Resources["header_logotype"] };

            Label title = new Label()
            {
                Style =  (Style)Application.Current.Resources["header_title"],
                Text = Title
            };

            Label content = new Label()
            {
                Style =  (Style)Application.Current.Resources["header_content"],
                Text = Content
            };

            this.Children.Add(avatar,0,0);
            SetRowSpan(avatar, 2);
            this.Children.Add(title, 1, 0);
            this.Children.Add(content, 1, 1);

        }


    }
}
