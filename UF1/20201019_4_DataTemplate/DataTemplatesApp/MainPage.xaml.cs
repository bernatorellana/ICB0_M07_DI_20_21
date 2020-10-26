using DataTemplatesApp.Model;
using System;
using System.Collections.Generic;
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

namespace DataTemplatesApp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private TipusVehicle? tipusVehicleSeleccionat;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            cboMarques.ItemsSource = Marca.GetLlistaMarques();
            lsvVehicles.ItemsSource = Vehicle.GetLlistatVehicles();

            /// associar cada radiobutton amb el valor de 
            /// tipus de vehicle pertinent
            /// 
            rdoQualsevol.Tag = null;
            rdoCotxe.Tag = TipusVehicle.COTXE;
            rdoMoto.Tag = TipusVehicle.MOTO;
            rdoFurgo.Tag = TipusVehicle.FURGONETA;
            rdoCamio.Tag = TipusVehicle.CAMIO;
            // assegurem que el radioQualsevol està checked
            rdoQualsevol.IsChecked = true;

        }

        private void cboMarques_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filtre();
        }

    
        private void Button_ContextCanceled(UIElement sender, RoutedEventArgs args)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cboMarques.SelectedValue = null;
        }

        private void txtMatricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            filtre();
        }



        /// <summary>
        /// Funció de filtrat
        /// </summary>
        private void filtre()
        {

   

            List<Vehicle> vehiclesFiltrats = new List<Vehicle>();
            Boolean criteriMarcaActiu = cboMarques.SelectedValue != null;
            Marca marcaSeleccionada = (Marca)cboMarques.SelectedValue;
            Boolean criteriMatriculaActiu = txtMatricula.Text.Trim().Length > 0;
            Boolean criterTipusVehicleActiu = tipusVehicleSeleccionat != null;
            foreach (Vehicle v in Vehicle.GetLlistatVehicles())
            {

                // si v compleix els criteris, l'afegim a la llista
                if (
                    (!criteriMarcaActiu         || v.MarcaP.Equals(marcaSeleccionada)) &&
                    (!criteriMatriculaActiu     || v.Matricula.Contains(txtMatricula.Text)) &&
                    (!criterTipusVehicleActiu   || v.TipusVehicle == tipusVehicleSeleccionat )
                )
                {
                    vehiclesFiltrats.Add(v);
                }
            }
            lsvVehicles.ItemsSource = vehiclesFiltrats;
                 
        }

        private void RadioButton_Checked(object sender, 
            RoutedEventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            if (r.Tag != null) {

                tipusVehicleSeleccionat = (TipusVehicle) r.Tag;
            } else
            {
                tipusVehicleSeleccionat = null;
            }
            filtre();
        }
    }
}
