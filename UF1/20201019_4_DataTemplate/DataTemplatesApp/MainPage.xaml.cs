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
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            cboMarques.ItemsSource = Marca.GetLlistaMarques();
            lsvVehicles.ItemsSource = Vehicle.GetLlistatVehicles();

        }

        private void cboMarques_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Marca m = (Marca) cboMarques.SelectedValue;
            if (m == null)
            {
                lsvVehicles.ItemsSource = Vehicle.GetLlistatVehicles();
            }
            else
            {
                List<Vehicle> vehiclesFiltrats = new List<Vehicle>();
                foreach (Vehicle v in Vehicle.GetLlistatVehicles())
                {
                    if (v.MarcaP.Id == m.Id)
                    {
                        vehiclesFiltrats.Add(v);
                    }
                }
                lsvVehicles.ItemsSource = vehiclesFiltrats;
            }
        }

        private void Button_ContextCanceled(UIElement sender, RoutedEventArgs args)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cboMarques.SelectedValue = null;
        }
    }
}
