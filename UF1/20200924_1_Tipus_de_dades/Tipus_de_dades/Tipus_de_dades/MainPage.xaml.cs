using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

            //---------------------------------------------------
            String frase = "Hola bon dia que tal esteu?";
            txtSortida.Text += troceja(frase);
            //---------------------------------------------------
            string[] paraules = frase.Split(' ');
            for(int i = 0; i < paraules.Length; i++)
            {
                txtSortida.Text += ">" + paraules[i] +"\n";
            }
            //------------
            decimal preu = 1236.4M;
            txtSortida.Text += preu.ToString("#,###,###.00") + "\n";
            
            CultureInfo ci = new CultureInfo("en-UK");//idioma-país
            txtSortida.Text += preu.ToString("#,###,###.00",ci) + "\n";
            //-------------------

            // Juguem amb dates
            DateTime a = DateTime.Now;  //  28/09/2020 20:34:12 
            DateTime b = DateTime.Today; // 28/09/2020 00:00:00
            if(b<a)
            {
                txtSortida.Text += "El món té sentit\n";
                
            }
            int dia = b.Day;
            DayOfWeek dotw = b.DayOfWeek;
            txtSortida.Text += "Avui és dia " + dia + " i dia de la setmana" + dotw + "\n";

            TimeSpan ts = a.Subtract(b);
            txtSortida.Text += ts.Hours + ":" + ts.Minutes +":"+ ts.Seconds + "\n";
            txtSortida.Text += ts.TotalMinutes + "\n";

            //-------------------------
            // formateig 
            CultureInfo cic = new CultureInfo("ca-ES");
            txtSortida.Text += b.ToString("dddd, dd 'de' MMMM 'de' yyyy', a les' hh:mm:ss tt", cic) +"\n";



            //--------------------
            DateTime dilluns = new DateTime(2020, 09, 28);        
            string[] nomsDiesSetmana = new string[7];
            for(int i=0;i<nomsDiesSetmana.Length;i++)
            {
                nomsDiesSetmana[i] = dilluns.AddDays(i).ToString("dddd", ci);
            }
            // carreguem aquestes opcions al ComboBox
            cboDOTW.ItemsSource = nomsDiesSetmana;
            /*
             "ca-ES"
             "en-UK"
             "fr-FR"
            */


        }

        private String troceja(String frase)
        {
            String sortida = "";
            int posActual = 0;
            Boolean finalDeFrase = false;
            do
            {
                frase = frase.Trim();
                int i = frase.IndexOf(" ");
                if (i != -1)
                {
                    // hi ha un espai
                    // prenem des de la posició actual fins a i (exclòs)
                    sortida += frase.Substring(posActual, i - posActual);
                    sortida += "\n";
                    frase = frase.Substring(i);
                    //  maria
                } else
                {
                    finalDeFrase = true;
                    sortida += frase;
                }
            } while (!finalDeFrase);
            return sortida;
        }


    }
}
