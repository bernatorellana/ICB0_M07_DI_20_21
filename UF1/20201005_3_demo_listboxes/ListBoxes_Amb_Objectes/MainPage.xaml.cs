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
using Windows.UI;
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
        private Dictionary<String, List<String>> modelsPerMarca = new Dictionary<String, List<String>>();


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
            Usuari u1 = new Usuari(1, "Maria");
            Usuari u2 = new Usuari(2, "Joan");
            Usuari u3 = new Usuari(3, "Cristina");
            Usuari u4 = new Usuari(4, "Pep");
            v1.AfegirUsuari(u1);
            v1.AfegirUsuari(u2);
            v2.AfegirUsuari(u3);
            v3.AfegirUsuari(u4);
            //---------------------------------------------
            lsbUsuaris.DisplayMemberPath = "Nom";
            //---------------------------------------------

            /*marques.Add("Seat");
            marques.Add("VW");
            marques.Add("Audi");
            marques.Add("Skoda");
            marques.Add("Ferrari");
            cboMarques.ItemsSource = marques;*/
            //------------------------------
            //         "Seat"--> {"Leon", "Altea", "Ibiza"}
            //           |            |
            List<String> llistaSeat = new List<String>();
            llistaSeat.Add("Leon");
            llistaSeat.Add("Ibiza");
            llistaSeat.Add("Alhambra");
            llistaSeat.Add("Exeo");
            modelsPerMarca["Seat"] = llistaSeat;
            //-------------------------------------------------------
            modelsPerMarca["VW"] = new List<String>() {"Passat", "Golf", "Tuareg", "Scirocco" };
            modelsPerMarca["Audi"] = new List<String>() {"A3", "A4", "A5", "A6" };

            cboMarques.ItemsSource = modelsPerMarca.Keys;

            btnBaixa.IsEnabled = false;

         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string matricula = txtMatricula.Text;
            Vehicle nou = new Vehicle(matricula,
                cboMarques.SelectedValue.ToString(), 
                cboModels.SelectedValue.ToString());
            vehicles.Add(nou);

            // Neteja la matrícula
            txtMatricula.Text = "";
            // Netejar model i marca
            cboMarques.SelectedIndex = -1;
            cboModels.SelectedIndex = -1;
            
            // 
            //lsbVehicles.ItemsSource = null;
            //lsbVehicles.ItemsSource = vehicles;
        }

        private void txtMatricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            validaDadesCotxe();
        }



        private void cboMarques_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboMarques.SelectedValue != null)
            {
                cboModels.ItemsSource = modelsPerMarca[cboMarques.SelectedValue.ToString()];                
            }
            validaDadesCotxe();
        }


        private Boolean validaDadesCotxe()
        {

           

            bool valid = false;
            String error = "";
            // valida matricula
            bool matriculaValida = Vehicle.validaMatricula(txtMatricula.Text);

            if (matriculaValida)
            {
                matriculaValida = !(vehicles.Contains(new Vehicle(txtMatricula.Text, "dummy", "dummy")));
                if(!matriculaValida)
                {
                    error = "Cotxe repetit.";
                }
                // existeix la matrícula?
                /*foreach (Vehicle v in vehicles)
                {
                    if (v.Matricula.Equals(txtMatricula.Text))
                    {
                        matriculaValida = false;
                        break;
                    }
                }*/
            } else if(txtMatricula.Text.Length>0)
            {
                error = "Format de matricula erroni.";
            }
            if(!matriculaValida)
            {
                tbkErrorMatricula.Text =  error;
                txtMatricula.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                tbkErrorMatricula.Text = "";
                txtMatricula.Background = new SolidColorBrush(Colors.Transparent);
            }


            if (matriculaValida)
            {
                // valida marca
                bool marcaValida = cboMarques.SelectedIndex != -1;
                if (marcaValida)
                {
                    // valida model
                    bool modelValid = cboModels.SelectedIndex != -1;
                    valid = modelValid;
                }
            }
            btnAlta.IsEnabled = valid;

            return valid;
            //return matriculaValida && marcaValida && modelValid;
        }

        private void cboModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            validaDadesCotxe();
        }

        private void btnBaixa_Click(object sender, RoutedEventArgs e)
        {
            if(lsbVehicles.SelectedValue!=null)
            {
                //Vehicle v = (Vehicle)lsbVehicles.SelectedValue;                
                //vehicles.Remove(v);
                //---------------------------
                vehicles.RemoveAt(lsbVehicles.SelectedIndex);
            }
        }

        private void lsbVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnBaixa.IsEnabled = lsbVehicles.SelectedValue != null;
            Vehicle vehicleSeleccionat = (Vehicle) lsbVehicles.SelectedValue;
            // Carreguem els usuaris del 
            // vehicle seleccionat (si n'hi ha un , és clar! )
            if(vehicleSeleccionat!=null)
            {
                lsbUsuaris.ItemsSource = vehicleSeleccionat.Usuaris;
            }
        }
    }
}
