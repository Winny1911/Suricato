using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static Suricato.UI.Controls.PinControlEvents;

namespace Suricato.UI.Controls
{
    public class PinControl: StackLayout
    {
        public string pin;
        public string pinCompare;
        public Grid pinIndicatorGrid;
        public StackLayout mainContainer;
        private bool matchPins;

        public event EventHandler<PinControlEvents> OnDoAction;

        public PinControl(bool comparePins = false, string PinCompare="")
        {
            matchPins = comparePins;
            pinCompare = PinCompare;
        }

        public StackLayout RenderPinControl()
        {
            mainContainer = new StackLayout() {
                Style = (Style)Application.Current.Resources["pin_control_main_container"],
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                ClassId  = "mainContainer"
            };

            pin = string.Empty;

            pinIndicatorGrid = new Grid()
            {
                Style = (Style)Application.Current.Resources["pin_indicator_grid"],
                ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition{ Width = 14 },
                    new ColumnDefinition{ Width = 14 },
                    new ColumnDefinition{ Width = 14},
                    new ColumnDefinition{ Width = 14 },
                },
                ClassId = "pinIndicatorGrid",
                HorizontalOptions = LayoutOptions.Center
            };

            //fill grid indicator
            for (int indicator = 0; indicator <= 3; indicator++)
            {
                Image pinIndicatorImage = new Image()
                {
                    Style = (Style)Application.Current.Resources["pin_key_indicator_empty"],
                    ClassId = string.Format("pin_slot_{0}", indicator)
                };

                pinIndicatorGrid.Children.Add(pinIndicatorImage, indicator, 0);
            }

            Grid keyboardGrid = new Grid()
            {
                Style = (Style)Application.Current.Resources["keyboard_grid"],
                ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition{ Width = 80 },
                    new ColumnDefinition{ Width = 80 },
                    new ColumnDefinition{ Width = 80}
                },
                RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition{Height=80},
                    new RowDefinition{Height=80},
                    new RowDefinition{Height=80},
                    new RowDefinition{Height=80}
                },
                ClassId= "keyboardGrid"
            };

            //fill keyboard grid
            int row = 0;
            int col = 0;

            for (int keys = 0; keys <= 11; keys++)
            {
                string style = string.Empty;
                string text = string.Empty;

                switch (keys)
                {
                    case 9:
                        style = "keyboard_button_clear";
                        text = "LIMPAR";
                        break;
                    case 11:
                        style = "keyboard_button_backspace";
                        text = "VOLTAR";
                        break;
                    default:
                        style = "keyboard_button_numeric";
                        text = (keys + 1).ToString();
                        break;
                }

                Button btKey = new Button()
                {
                    Style = (Style)Application.Current.Resources[style],
                    Text = text.Equals("11") ? "0" : text,
                    ClassId = keys.ToString() == "10" ? "0" : keys.ToString()
                };

                btKey.Clicked += BtKey_Clicked;

                keyboardGrid.Children.Add(btKey, col, row);

                if (keys == 2 || keys == 5 || keys == 8 || keys == 11)
                {
                    row++;
                    col = 0;
                }
                else
                {
                    col++;
                }
            }

            //add children
            mainContainer.Children.Add(pinIndicatorGrid);
            mainContainer.Children.Add(keyboardGrid);

            return mainContainer;
        }

        private void BtKey_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            int value = 0;

            if (clickedButton.Text.Equals("LIMPAR")) {
                value = 10;
            }
            else if (clickedButton.Text.Equals("VOLTAR"))
            {
                value = 11;
            }
            else 
            {
                value = int.Parse(clickedButton.Text);
            }

            switch (value)
                {
                    case 10:
                        ClearPinNumber();
                        break;
                    case 11:
                        RemovePinNumber();
                        break;
                    default:
                        AddPinNumber(value);
                        break;
                }
        }

        private void AddPinNumber(int PinNumber)
        {
            if (pin.Length <= 3)
            {
                pin += PinNumber.ToString();
                UpdatePinIndicator(pin.Length);

                if (pin.Length == 4)
                {
                    if (matchPins)
                    {
                        if (!pin.Equals(pinCompare))
                        {
                            ClearPinNumber();
                            OnDoAction?.Invoke(this, new PinControlEvents(ACTIONS.PINS_NOT_MATCH, pin));
                        }
                        else
                        {
                            OnDoAction?.Invoke(this, new PinControlEvents(ACTIONS.GO_NEXT_VIEW, pin));
                        }
                    }
                    else
                    {
                        OnDoAction?.Invoke(this, new PinControlEvents(ACTIONS.GO_NEXT_VIEW, pin));
                    }
                }
            }
        }

        private void RemovePinNumber()
        {
            if (pin.Length > 0)
            {
                UpdatePinIndicator(pin.Length, false);
                pin = pin.Substring(0, pin.Length - 1);
            }
        }

        private void ClearPinNumber()
        {
            pin = string.Empty;

            for (int x = 0; x <= 3; x++)
            {
                Image pinIndicator = (Image)pinIndicatorGrid.Children.Where(i => i.ClassId.Equals(string.Format("pin_slot_{0}", x))).FirstOrDefault();

                if (pinIndicator != null)
                    pinIndicator.Style = (Style)Application.Current.Resources["pin_key_indicator_empty"]; 
            }
        }

        private void UpdatePinIndicator(int Position, bool AddIndicator = true)
        {

            var pinIndicatorGrid = mainContainer.Children.Where(x => x.ClassId!=null && x.ClassId.Equals("pinIndicatorGrid")).FirstOrDefault();

            if (pinIndicatorGrid != null)
            { 
                Image pinIndicator = (Image)((Grid)pinIndicatorGrid).Children.Where(x => x.ClassId.Equals(string.Format("pin_slot_{0}", Position - 1))).FirstOrDefault();
  
                if (pinIndicator != null)
                {
                    if (!AddIndicator)
                        pinIndicator.Style = (Style)Application.Current.Resources["pin_key_indicator_empty"];
                    else
                        pinIndicator.Style = (Style)Application.Current.Resources["pin_key_indicator_full"];
                }
            }
        }

    }
}
