using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace UWP_HelloWorld
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int semafor =0;


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
      
            txtSalutacio.Text = "Hola Mon!";
            //-------------------------------------------------------------------------
            // Versió amb una taula de colors
            Color [] taulaDeColors = {  Color.FromArgb(255, 255, 0, 0) ,
                                        Color.FromArgb(255, 0, 255, 0),
                                        Color.FromArgb(255, 255, 255, 0)
                                      };
            txtSalutacio.Background = new SolidColorBrush(taulaDeColors[semafor]);
            semafor = (semafor + 1) % 3;

            /*
             * // Versió amb if's
             Color color;
            if(semafor==0)
            {
                color = Color.FromArgb(255, 255, 0, 0);
            }
            else if(semafor==1)
            {
                color = Color.FromArgb(255, 0, 255, 0);
            }
            else
            {
                color = Color.FromArgb(255, 255, 255, 0);
            }
            txtSalutacio.Background = new SolidColorBrush(color);
            semafor = (semafor+1)%3;
            */




            // vermell --> verd --> groc --> vermell
            //   |______________________________|
        }
    }
}
