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

namespace Tipus_de_dades
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
            txtSortida.Text = "Carregant...";

            decimal totalFactura = 100.12M;

            


            Debug.WriteLine("Hello World estic depurant");



            ///--------------------------------
            /// Strings
            /// 
            String nomICognoms = "Paco";
            nomICognoms = nomICognoms + " Sánchez";
            int lletres = nomICognoms.Length;
            txtSortida.Text = nomICognoms + "\n";
            txtSortida.Text += lletres.ToString() + "\n";
            txtSortida.Text += lletres + "" + "\n";
            //int i;
            //for (i = 0; i < nom.Length && nom[i] != ' '; i++);
            // 01234567890123
            // Maria Sánchez
            int i1 = nomICognoms.IndexOf("ar");//1
            int i2 = nomICognoms.IndexOf(' ');//5
            int i3 = nomICognoms.IndexOf('a', 2);//4
            int i4 = nomICognoms.IndexOf('k');// -1

            string test = nomICognoms.Substring(1, 3);//ari
            string nom = nomICognoms.Substring(0, nomICognoms.IndexOf(' '));
            txtSortida.Text += nom + "\n";
            string NIF = "   11111111-H  ";
            NIF = NIF.Trim();
            txtSortida.Text += NIF + "\n" ;
            NIF = NIF.Remove(NIF.IndexOf("-"), 1);
            txtSortida.Text += NIF + "\n";

            String frase = "Hola bon dia que tal esteu?";


        }
    }
}
