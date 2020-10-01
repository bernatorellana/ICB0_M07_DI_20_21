using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace DemoControl_i_classes
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int a = 3;
            if (a == 2) a++;
            a++;
            //que val a?

            string color = (a > 3) ? "Blau" : "Vermell";
            int nota = (a==3)? 1:2;


            string[] persones = { "Maria", "Berta","", "Joan" };
            
            for(int i=0;  i<persones.Length;   i++)
            {
                Debug.WriteLine(">" + persones[i].ToUpper());
            }
            string[] buida = new string[10];
            
            foreach(string p in buida)
            {
                Debug.WriteLine(">" + p);
            }

            //----------------------------------
            Persona p1 = new Persona(1, "11111111H", "Maria"); 
            Persona p2 = new Persona(2, "12345678Z", "Joan");
            Persona p3 = new Persona(3, "XXXX", "ccc");

            

            p1.Id = 1;       
            int idDelPaio1 = p1.Id;
            p1.Id = -1;

        }
    }
}
