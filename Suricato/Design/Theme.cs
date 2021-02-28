using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Suricato.Design
{
    public class Theme
    {
        public Theme()
        {
        }

        //MAIN COLORS
        public const string ORANGE_COLLOR = "#FDBB2F"; //ORANGE >> SPLASH BACKGROUND, BUTTON
        public const string LIGHT_ORANGE_COLLOR = "#F7C874"; //LIGHT ORANGE >> KEYBOARD CLEAR BUTTON
        public const string RED_COLLOR = "#FF0000"; //RED >> ALERT ICONS
        public const string LIGHT_GREEN_COLLOR = "#00FF00"; //LIGHT GREEN >> OK ICONS
        public const string GREEN_COLLOR = "#169A46"; //GREEN >> TOP HEADER SECTION
        public const string MEDIUM_GREEN_COLLOR = "#5FA364"; //MEDIUM GREEN >> KEYBOARD BACK BUTTON
        public const string PALE_GREEN_COLLOR = "#CBE4B9"; //PALE GREEN >> 
        public const string DARK_GREEN_COLLOR = "#18606E"; //DARK GREEN >> MAIN BACKGROUND
        public const string LIGHT_BLUE_COLLOR = "#6897A0"; //LIGHT BLUE >> KEYBOARD KEYS
        public const string LIGHT_GREY_COLLOR = "#E6E6E6"; //LIGHT GREY >> ODD LIST ITEMS
        public const string DARK_GREY_COLLOR = "#2B2C30"; //dark grey to top bar first access step background
        public const string MEDIUM_GREY_COLLOR = "#666264"; //medium grey to top bar first access step indicator
        public const string PLACEHOLDER_GRAY_COLOR = "#9d9b9b";


        //

        public static void LoadTheme()
        {

            Application.Current.Resources = new ResourceDictionary();


            //CONTAINERS
            //main container (all pages)
            Application.Current.Resources.Add("main_container",
                new Style(typeof(StackLayout))
                {
                    Setters = {
                new Setter {
                        Property = View.HorizontalOptionsProperty, Value = "FillAndExpand" },
                        new Setter { Property = View.VerticalOptionsProperty, Value = "FillAndExpand" },
                        new Setter { Property = StackLayout.OrientationProperty, Value = "Vertical" },
                        new Setter { Property = StackLayout.BackgroundColorProperty, Value = Color.FromHex(DARK_GREEN_COLLOR) },
                        new Setter { Property = Layout.PaddingProperty, Value = new Thickness(0) },
                        new Setter { Property = StackLayout.SpacingProperty, Value = 15 },
                    }
                }
            );

            //footer
            Application.Current.Resources.Add("main_footer",
            new Style(typeof(Image))
            {
                Setters = {
                        new Setter { Property = Image.SourceProperty, Value = "logotipo_rodape.png" },
                        new Setter { Property = Image.WidthRequestProperty, Value = 150 },
                        new Setter { Property = Image.VerticalOptionsProperty, Value = "EndAndExpand" },
                        new Setter { Property = Image.HorizontalOptionsProperty, Value = "Center" },
                        new Setter { Property = Image.AspectProperty, Value = "AspectFit" },

                }
            }
        );

            Application.Current.Resources.Add("default_button",
                new Style(typeof(Button))
                {
                    Setters =
                    {
                        new Setter { Property = Button.HeightRequestProperty, Value = 60 },
                        new Setter { Property = Button.TextColorProperty, Value = "White" },
                        new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex(ORANGE_COLLOR) },
                        new Setter { Property = Button.MarginProperty, Value = 10 },
                        new Setter { Property = Button.BorderRadiusProperty, Value = 60 },
                    }
                });


            #region "TOP BAR - STEPS - MAIN MENU"
            //topbar
            Application.Current.Resources.Add("top_bar",
               new Style(typeof(StackLayout))
               {
                   Setters = {
                new Setter {
                        Property = View.HorizontalOptionsProperty, Value = "FillAndExpand" },
                        new Setter { Property = View.VerticalOptionsProperty, Value = "Start" },
                        new Setter { Property = StackLayout.OrientationProperty, Value = "Horizontal" },
                        new Setter { Property = View.HeightRequestProperty, Value = 60 },
                        new Setter { Property = View.MinimumHeightRequestProperty, Value = 60 },
                        new Setter { Property = StackLayout.BackgroundColorProperty, Value = Color.FromHex(DARK_GREY_COLLOR) },
                        new Setter { Property = Layout.PaddingProperty, Value = new Thickness(0) },
                   }
               }
           );

            //Grid to topbar
            Application.Current.Resources.Add("main_grid_top_bar",
                new Style(typeof(Grid))
                {
                    Setters = {
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "FillAndExpand" },
                        new Setter { Property = View.VerticalOptionsProperty, Value = "FillAndExpand" },
                    }
                }
            );

            //top bar logotype
            Application.Current.Resources.Add("main_top_bar_logotype",
              new Style(typeof(Image))
              {
                  Setters = {
                        new Setter { Property = Image.SourceProperty, Value = "logotipo_barra_topo.png" },
                        new Setter { Property = View.VerticalOptionsProperty, Value = "Center" },
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "Center" },
                        new Setter { Property = Image.AspectProperty, Value = "AspectFit" },
                  }
              }
          );


            //FONTS
            Application.Current.Resources.Add("top_bar_step_indicator",
               new Style(typeof(Label))
               {
                   Setters = {
                        new Setter { Property = Label.FontSizeProperty, Value = 18 },
                        new Setter { Property = Label.TextColorProperty, Value = Color.FromHex (MEDIUM_GREY_COLLOR)},
                        new Setter { Property = Label.FontAttributesProperty, Value = "Bold"  },
                   }
               }
           );

            Application.Current.Resources.Add("top_bar_step_indicator_highlight",
                new Style(typeof(Label))
                {
                    BaseResourceKey = "top_bar_step_indicator",
                    Setters = {
                            new Setter { Property = Label.TextColorProperty, Value = Color.FromHex (ORANGE_COLLOR)},
                    }
                }
            );

            //steps grid
            Application.Current.Resources.Add("steps_grid_top_bar",
                new Style(typeof(Grid))
                {
                    Setters = {
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "FillAndExpand" },
                        new Setter { Property = Grid.MarginProperty, Value= new Thickness(15,17,0,0)},
                        new Setter { Property = Grid.VerticalOptionsProperty, Value="Center"}
                    }
                }
            );

            #endregion


            #region "MAIN HEADER"

            Application.Current.Resources.Add("header_grid",
               new Style(typeof(Grid))
               {
                   Setters = {
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "FillAndExpand" },
                        new Setter { Property = Grid.MarginProperty, Value= new Thickness(15,0,15,0)},
                        new Setter { Property = Grid.VerticalOptionsProperty, Value="Start"},
                        new Setter { Property = Grid.ColumnSpacingProperty, Value="5"}

                   }
               }
           );

            Application.Current.Resources.Add("header_title",
              new Style(typeof(Label))
              {
                  Setters = {
                    new Setter { Property = Label.TextColorProperty, Value = Color.White},
                    new Setter { Property = Label.FontSizeProperty, Value = 18 },
                    new Setter { Property = Label.FontAttributesProperty, Value = "Bold"  },
                    new Setter { Property = View.VerticalOptionsProperty, Value="Start"}
                  }
              }
            );
            Application.Current.Resources.Add("header_content",
                new Style(typeof(Label))
                {
                    BaseResourceKey = "header_title",
                    Setters = {
                        new Setter { Property = Label.FontSizeProperty, Value = 14 },
                        new Setter { Property = Label.FontAttributesProperty, Value = "None"  }
                    }
                }
            );

            //top bar logotype
            Application.Current.Resources.Add("header_logotype",
              new Style(typeof(Image))
              {
                  Setters = {
                        new Setter { Property = Image.SourceProperty, Value = "suricato_avatar.png" },
                        new Setter { Property = View.VerticalOptionsProperty, Value = "Start" },
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "Start" },
                        new Setter { Property = Image.AspectProperty, Value = "AspectFit" },
                        new Setter { Property = Image.WidthRequestProperty, Value = "80" },

                  }
              }
          );


            #endregion


            #region "CONTENT"
            Application.Current.Resources.Add("content_container",
              new Style(typeof(StackLayout))
              {
                  Setters = {
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "FillAndExpand" },
                        new Setter { Property = View.VerticalOptionsProperty, Value = "FillAndExpand" },
                        new Setter { Property = StackLayout.OrientationProperty, Value = "Vertical" },
                        new Setter { Property = Layout.PaddingProperty, Value = new Thickness(20,10,20,10) },
                  }
              }
          );

            Application.Current.Resources.Add("content_text",
              new Style(typeof(Label))
              {
                  Setters = {
                        new Setter { Property = Label.FontSizeProperty, Value = 16 },
                        new Setter { Property = Label.FontAttributesProperty, Value = "None"  },
                        new Setter { Property= Label.HorizontalTextAlignmentProperty, Value ="Center"},
                        new Setter { Property= Label.TextColorProperty, Value ="White"}
                  }
              }
          );


            #endregion

            #region "PIN CONTROL"

                //control main container
                Application.Current.Resources.Add("pin_control_main_container",
                  new Style(typeof(StackLayout))
                  {
                      Setters = {
                          new Setter { Property = StackLayout.OrientationProperty, Value = "Vertical" },
                          new Setter { Property = StackLayout.SpacingProperty, Value = new Thickness(0) },
                          new Setter { Property = View.MarginProperty, Value = new Thickness(0) },
                          new Setter { Property = View.HorizontalOptionsProperty, Value = "Center" },
                          new Setter { Property = View.VerticalOptionsProperty, Value = "Start" },
                      }
                  }
              );

                //pin keys indicator panel
                Application.Current.Resources.Add("pin_indicator_grid",
                new Style(typeof(Grid))
                {
                    Setters = {
                        new Setter { Property = Grid.VerticalOptionsProperty, Value="Start"},
                        new Setter { Property = Grid.MarginProperty, Value= new Thickness(30,0,30,10)},
                        new Setter { Property = Grid.MinimumHeightRequestProperty, Value=14},
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "Center" },
                        }
                }
                );


            //key indicator image
            //WidthRequest = "18" HeightRequest = "18" HorizontalOptions = "Center" VerticalOptions = "Center"
            Application.Current.Resources.Add("pin_key_indicator",
            new Style(typeof(Image))
            {
                Setters = {
                        new Setter { Property = View.VerticalOptionsProperty, Value = "Center" },
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "Center" },
                        new Setter { Property = Image.WidthRequestProperty, Value = 18 },
                        new Setter { Property = Image.HeightRequestProperty, Value = 18 },

                    }
                }
            );

            Application.Current.Resources.Add("pin_key_indicator_full",
                new Style(typeof(Image))
                {
                    BaseResourceKey = "pin_key_indicator",
                    Setters = {
                        new Setter { Property = Image.SourceProperty, Value = "ic_pin_cheio.png"},
                    }
                }
            );

            Application.Current.Resources.Add("pin_key_indicator_empty",
              new Style(typeof(Image))
              {
                  BaseResourceKey = "pin_key_indicator",
                  Setters = {
                        new Setter { Property = Image.SourceProperty, Value = "ic_pin_vazio.png"},
                  }
              }
          );

            Application.Current.Resources.Add("keyboard_grid",
             new Style(typeof(Grid))
             {
                 Setters = {
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "Center" },
                        new Setter { Property = Grid.VerticalOptionsProperty, Value="FillAndExpand"},
                        new Setter { Property = Grid.MarginProperty, Value= new Thickness(0,10,0,0)},
                        new Setter { Property = Grid.ColumnSpacingProperty, Value=1},
                        new Setter { Property = Grid.RowSpacingProperty, Value=1}
                     }
                 }
             );



            //keyboard button
            Application.Current.Resources.Add("keyboard_button",
                new Style(typeof(Button))
                {
                    Setters =
                        {
                            new Setter { Property= Button.HorizontalOptionsProperty, Value ="FillAndExpand"},
                            new Setter { Property = Button.VerticalOptionsProperty, Value = "FillAndExpand" },
                            new Setter { Property = Button.TextColorProperty, Value = "White" },
                            new Setter { Property = Button.FontAttributesProperty, Value = "Bold" },
                        }
                });

                Application.Current.Resources.Add("keyboard_button_numeric",
                new Style(typeof(Button))
                {
                    BaseResourceKey = "keyboard_button",
                    Setters =
                        {
                            new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex("#80B3BD") },
                            new Setter { Property = Button.FontSizeProperty, Value = 35 },

                    }
                });

                Application.Current.Resources.Add("keyboard_button_clear",
                new Style(typeof(Button))
                {
                    BaseResourceKey = "keyboard_button",
                    Setters =
                        {
                            new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex(ORANGE_COLLOR) },

                    }
                });

                Application.Current.Resources.Add("keyboard_button_backspace",
              new Style(typeof(Button))
              {
                  BaseResourceKey = "keyboard_button",
                  Setters =
                      {
                            new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex(GREEN_COLLOR) },

                  }
              });


            #endregion


            #region "POPUP"
            Application.Current.Resources.Add("PopUpTitle",
            new Style(typeof(Label))
            {
                Setters = {
                            new Setter { Property = Label.TextColorProperty, Value = Color.FromHex ("#000000")},
                            new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = "Center" },
                            new Setter { Property = Label.VerticalTextAlignmentProperty, Value = "Center" },
                            new Setter { Property = Label.FontSizeProperty, Value = 20 },
                            new Setter { Property = Label.FontAttributesProperty, Value = "Bold" },
                 }
            });

            Application.Current.Resources.Add("PopUpContent",
               new Style(typeof(Label))
               {
  
                   Setters = {
                                new Setter { Property = Label.TextColorProperty, Value = Color.DarkGray},
                                new Setter {Property = Label.HorizontalOptionsProperty, Value = "CenterAndExpand"},
                                new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = "Center" },
                                new Setter { Property = Label.VerticalTextAlignmentProperty, Value = "Center" },
                                new Setter { Property = Label.FontSizeProperty, Value = 16 },
                                new Setter { Property = Label.FontAttributesProperty, Value = "Bold" },
                    }
               });

            Application.Current.Resources.Add("PopUpButton",
         new Style(typeof(Button))
         {
             Setters = {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.Transparent},
                    new Setter { Property = Button.FontSizeProperty, Value = 14 },
                    new Setter { Property = Button.FontAttributesProperty, Value = "Normal" },
                    new Setter { Property = Button.TextColorProperty, Value = "Gray"  },
             }
         }
         );

            #endregion


            #region "Main"

            Application.Current.Resources.Add("main_view_avatar",
             new Style(typeof(Image))
             {
                 Setters = {
                        new Setter { Property = Image.SourceProperty, Value = "suricato_avatar.png"},
                        new Setter { Property = Image.HorizontalOptionsProperty, Value = "Center"},
                        new Setter { Property = Image.VerticalOptionsProperty, Value = "Start"},
                        new Setter { Property = Image.HeightRequestProperty, Value = 190},
                        new Setter { Property = Image.MarginProperty, Value = new Thickness(0,50,0,0)},

                 }
             }
         );
            //HorizontalOptions="CenterAndExpand" VerticalOptions="EndAndExpand" Orientation="Horizontal" Spacing="15"  Margin="20,0,20,0"
            Application.Current.Resources.Add("main_options_container",
              new Style(typeof(StackLayout))
              {
                  Setters = {
                      new Setter { Property = View.HorizontalOptionsProperty, Value = "CenterAndExpand" },
                      new Setter { Property = View.VerticalOptionsProperty, Value = "EndAndExpand" },
                      new Setter { Property = StackLayout.OrientationProperty, Value = "Horizontal" },
                      new Setter { Property = StackLayout.SpacingProperty, Value = 15 },
                      new Setter { Property = View.MarginProperty, Value = new Thickness(20,0,20,0) },
                  }
              }
          );

            Application.Current.Resources.Add("main_options_button_container",
              new Style(typeof(StackLayout))
              {
                  Setters = {
                          new Setter { Property = StackLayout.OrientationProperty, Value = "Vertical" },
                          new Setter { Property = StackLayout.HorizontalOptionsProperty, Value = "FillAndExpand" },
                          new Setter { Property = View.VerticalOptionsProperty, Value = "EndAndExpand" },
                  }
              }
          );

            Application.Current.Resources.Add("main_options_icon",
           new Style(typeof(Image))
           {
               Setters = {
                        new Setter { Property = Image.AspectProperty, Value = "AspectFit"},
                        new Setter { Property = Image.HeightRequestProperty, Value = 80},
               }
           }
       );
            Application.Current.Resources.Add("main_options_label", new Style(typeof(Label))
              {
                 Setters = {
                        new Setter { Property = Label.TextColorProperty, Value = Color.White},
                        new Setter {Property = Label.HorizontalOptionsProperty, Value = "Center"},
                        new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = "Center" },
                        new Setter { Property = Label.VerticalTextAlignmentProperty, Value = "Center" },
                        new Setter { Property = Label.FontSizeProperty, Value = 12 },
                   }
              });

            Application.Current.Resources.Add("main_info_label", new Style(typeof(Label)) {
                BaseResourceKey = "header_title",
                Setters = {
                        new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = "Center" },
                        new Setter { Property = Label.MarginProperty, Value = new Thickness(0,20,0,40) },
                 }
            });

            #endregion


            #region "COMMOM"
            //header_title}" Text="Novo Usuário" FontSize="20" FontAttributes="Bold"  
            Application.Current.Resources.Add("common_title", new Style(typeof(Label))
            {
                //BaseResourceKey = "header_title",
                Setters = {
                        new Setter { Property = Label.TextColorProperty, Value = Color.White},
                        new Setter { Property = Label.FontSizeProperty, Value = 20 },
                        new Setter { Property = Label.FontAttributesProperty, Value = "Bold"},
                        new Setter { Property = View.HorizontalOptionsProperty, Value = "CenterAndExpand"},
                        new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = "Center"},
                   }
            });


            Application.Current.Resources.Add("common_entry", new Style(typeof(Entry))
            {
                Setters =
                {
                    new Setter {Property= Entry.MarginProperty, Value= new Thickness(15,5,15,5) },
                    new Setter {Property= Entry.BackgroundColorProperty, Value= "White" },
                }
            });


            Application.Current.Resources.Add("litbox_trigger_label", new Style(typeof(Entry))
            {
                Setters =
                {
                    new Setter { Property = Label.HorizontalTextAlignmentProperty, Value = "Start"},
                    new Setter { Property = Label.VerticalTextAlignmentProperty, Value = "Center"},
                    new Setter { Property = View.HorizontalOptionsProperty, Value = "FillAndExpand"},
                    new Setter { Property = View.VerticalOptionsProperty, Value = "Center"},
                    new Setter { Property = Label.FontSizeProperty, Value = 18 },
                    new Setter { Property = Label.TextColorProperty, Value = Color.FromHex(PLACEHOLDER_GRAY_COLOR) },
                    new Setter {Property= Entry.MarginProperty, Value= new Thickness(10,0,0,0) },
                }
            });

            Application.Current.Resources.Add("listbox_grid_container",
             new Style(typeof(Grid))
             {
                 Setters = {
                     new Setter { Property = View.BackgroundColorProperty, Value = Color.White },
                     new Setter { Property = View.HorizontalOptionsProperty, Value = "FillAndExpand" },
                     new Setter { Property = Grid.PaddingProperty, Value = new Thickness(5)  },
                     new Setter { Property = Grid.HeightRequestProperty, Value = 36  },
                     new Setter { Property = Grid.MarginProperty, Value= new Thickness(15,5,15,5)},
                 }
             }
             );
              #endregion


        }



    }
}
