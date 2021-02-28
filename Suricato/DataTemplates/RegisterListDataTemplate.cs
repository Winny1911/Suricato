using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Suricato.DataTemplates
{
    public class RegisterListDataTemplate : ViewCell
    {
        public static readonly BindableProperty dateProperty =
           BindableProperty.Create("Date", typeof(string), typeof(UserListDataTemplate), null);

        public string Date
        {
            get { return (string)GetValue(dateProperty); }
            set { SetValue(dateProperty, value); }
        }

        public static readonly BindableProperty registrationProperty =
         BindableProperty.Create("Registration", typeof(string), typeof(UserListDataTemplate), "");

        public string Registration
        {
            get { return (string)GetValue(registrationProperty); }
            set { SetValue(registrationProperty, value); }
        }

        public static readonly BindableProperty timeProperty =
         BindableProperty.Create("Time", typeof(string), typeof(UserListDataTemplate), "");

        public string Time
        {
            get { return (string)GetValue(timeProperty); }
            set { SetValue(timeProperty, value); }
        }

        Label lblDate;
        Label lblRegistration;
        Label lblTime;

        Grid dataGrid;
        Grid dataGridHeader;
        StackLayout gridBackColor;

        bool lastOddRow = false;

        public RegisterListDataTemplate()
        {
            try
            {
                gridBackColor = new StackLayout();
                ScrollView dataScrollContainer = new ScrollView();
                
                //layout
                lblDate = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 14, TextColor = Color.Black, LineBreakMode = LineBreakMode.TailTruncation };
                lblRegistration = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 14, TextColor = Color.Black, LineBreakMode = LineBreakMode.TailTruncation };
                lblTime = new Label() { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, FontSize = 14, TextColor = Color.Black, LineBreakMode = LineBreakMode.TailTruncation };

                dataGrid = new Grid()
                {
                    HorizontalOptions = LayoutOptions.Fill,
                    Padding = new Thickness(1),
                    ColumnDefinitions =
                    {
                        new ColumnDefinition{ Width = GridLength.Star },
                        new ColumnDefinition{ Width = GridLength.Star},
                        new ColumnDefinition{ Width = GridLength.Star }
                    }
                };

                dataGrid.Children.Add(lblDate, 0, 0);
                dataGrid.Children.Add(lblRegistration, 1, 0);
                dataGrid.Children.Add(lblTime, 2, 0);

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
                //if (BindingContext != null)
                //{
                //    Model.TimeClock.ResponseTimeClockPointments register = BindingContext as Model.TimeClock.ResponseTimeClockPointments;
                //    lblRegistration.Text = register.registroponto ToShortDateString();
                //    lblTime.Text = register.Data.ToShortTimeString();
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
