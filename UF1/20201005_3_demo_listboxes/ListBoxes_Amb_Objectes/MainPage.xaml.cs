using ListBoxes_Amb_Objectes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

namespace ListBoxes_Amb_Objectes
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();
        private ObservableCollection<string> marques = new ObservableCollection<string>();


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Vehicle v1 = new Vehicle("4545FRT", "Seat", "Leon");
            Vehicle v2 = new Vehicle("6322KKK", "Papamobil", "FI");
            Vehicle v3 = new Vehicle("8888NNN", "Audi", "A8");
            //--------------------------------------------
            vehicles.Add(v1);
            vehicles.Add(v2);
            vehicles.Add(v3);
            //--------------------------------------------
            lsbVehicles.ItemsSource = vehicles;
            lsbVehicles.DisplayMemberPath = "NomComplet";
            //---------------------------------------------

            marques.Add("Seat");
            marques.Add("VW");
            marques.Add("Audi");
            marques.Add("Skoda");
            marques.Add("Ferrari");
            cboMarques.ItemsSource = marques;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string matricula = txtMatricula.Text;
            Vehicle nou = new Vehicle(matricula, "Seat", "Leon");
            vehicles.Add(nou);
            txtMatricula.Text = "";
            
            // 
            //lsbVehicles.ItemsSource = null;
            //lsbVehicles.ItemsSource = vehicles;
        }

        private void txtMatricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            //txtMatricula.Text = txtMatricula.Text.ToUpper();
            bool matriculaValida =verificaMatriculaHechaPorDani(
                txtMatricula.Text);
            if(matriculaValida)
            {
                matriculaValida = !(vehicles.Contains(new Vehicle(txtMatricula.Text, "dummy", "dummy")));
                     

                // existeix la matrícula?
                /*foreach (Vehicle v in vehicles)
                {
                    if (v.Matricula.Equals(txtMatricula.Text))
                    {
                        matriculaValida = false;
                        break;
                    }
                }*/
            }
            btnAlta.IsEnabled = matriculaValida;
        }

        private bool verificaMatriculaHechaPorDani(string text)
        {
            return  Regex.Match(text, "^[0-9]{4}[QWRTYPSDFGHJKLZXCVBNM]{3}$", RegexOptions.IgnoreCase).Success;
        }
    }
}
