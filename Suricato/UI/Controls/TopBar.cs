using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Suricato.UI.Controls
{
    public class TopBar:StackLayout
    {

        public enum ACTION_SUB_BAR_TYPE { NONE=0, MAIN = 1, STEPS = 2, AUTHORIZATION=3 }

        public TopBar(ACTION_SUB_BAR_TYPE TopBarType = ACTION_SUB_BAR_TYPE.MAIN, int CurrentStep = 1) {

            this.Style = (Style)Application.Current.Resources["top_bar"];

            Grid mainGridTopBar = new Grid()
            {
                Style = (Style)Application.Current.Resources["main_grid_top_bar"],
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = 120 },
                    new ColumnDefinition{ Width = GridLength.Star},
                    new ColumnDefinition{ Width = 40 }
                }
            };

            //topbar logotype
            Image logotype = new Image() { Style = (Style)Application.Current.Resources["main_top_bar_logotype"] };

            //sub bar type
            Grid gridSubBar = new Grid();

            //main bar icons

            Image ic_home = new Image() { Source = "ic_top_home.png" };
            Image ic_user = new Image() { Source = "ic_top_user.png" };
            Image ic_gps = new Image() { Source = "ic_top_gps.png" };
            Image ic_alert = new Image() { Source = "ic_top_alert.png" };


            ic_home.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new Views.vMain(), false);
                })
            });

            ic_user.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new Views.vNewUser(), false);
                })
            });

            ic_gps.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new Views.vNewUser(), false);
                })
            });

            ic_alert.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PushAsync(new Views.vNewUser(), false);
                })
            });

            if (TopBarType == ACTION_SUB_BAR_TYPE.STEPS)
            {
                //Grid stepsGridSubBar = new Grid()
                //{
                gridSubBar.Style = (Style)Application.Current.Resources["steps_grid_top_bar"];
                gridSubBar.ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition{ Width = GridLength.Auto },
                    new ColumnDefinition{ Width = GridLength.Auto },
                    new ColumnDefinition{ Width = GridLength.Auto },
                    new ColumnDefinition{ Width = GridLength.Auto },
                };

                for (int index = 1; index <= 4; index++)
                {
                    Style labelStyle = new Style(typeof(Label));

                    if (index == CurrentStep)
                    {
                        labelStyle = (Style)Application.Current.Resources["top_bar_step_indicator_highlight"];
                    }
                    else
                    {
                        labelStyle = (Style)Application.Current.Resources["top_bar_step_indicator"];
                    }

                    Label step = new Label()
                    {
                        Style = labelStyle,
                        Text = index.ToString(),
                    };

                    //add to grid
                    gridSubBar.Children.Add(step, index - 1, 0);

                }
            }
            else
            {
                gridSubBar.ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition{ Width = GridLength.Star },
                    new ColumnDefinition{ Width = GridLength.Star },
                    new ColumnDefinition{ Width = GridLength.Star },
                  
                };

                gridSubBar.Children.Add(ic_home, 0, 0);
                gridSubBar.Children.Add(ic_user, 1, 0);
                gridSubBar.Children.Add(ic_gps, 2, 0);

                StackLayout icon_container = new StackLayout() { Padding = new Thickness(2), Margin =new Thickness(0,10,0,0) };
                icon_container.Children.Add(ic_alert);

                mainGridTopBar.Children.Add(icon_container, 2, 0);

            }

            //add controls dependencies
            mainGridTopBar.Children.Add(logotype, 0, 0);
            Grid.SetColumnSpan(logotype, 3);//logotype with span

            //add sub bar
            mainGridTopBar.Children.Add(gridSubBar, 0, 0);

        
        

            //create bar
            this.Children.Add(mainGridTopBar);
        }
    }
}
