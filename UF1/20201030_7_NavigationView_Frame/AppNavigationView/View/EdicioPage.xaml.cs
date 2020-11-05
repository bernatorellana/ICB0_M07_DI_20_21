using AppNavigationView.Model;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppNavigationView.View
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EdicioPage : Page
    {
        private EdicioPageParams parametres;

        public class EdicioPageParams
        {
            public MainPage paginaPrincipal;
            public Vehicle  vehicleAEditar;

            public EdicioPageParams(MainPage paginaPrincipal, Vehicle vehicleAEditar)
            {
                this.paginaPrincipal = paginaPrincipal;
                this.vehicleAEditar = vehicleAEditar;
            }
        }

        public EdicioPage()
        {
            this.InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            parametres = (EdicioPageParams)e.Parameter;
            /*if(parametres.vehicleAEditar==null)
            {
                parametres.vehicleAEditar = new Vehicle();
            }*/
            if (parametres.vehicleAEditar != null)
            {
                mostrarVehicle(parametres.vehicleAEditar);
            }
            btnDelete.Visibility = (parametres.vehicleAEditar == null) ? 
                Visibility.Collapsed : Visibility.Visible;
        }

        private void mostrarVehicle(Vehicle vehicleAEditar)
        {
            txtMatricula.Text = vehicleAEditar.Matricula;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string errors = "";
            bool dadesValides = validacions(out errors);
            if(dadesValides)
            {
                if(parametres.vehicleAEditar==null)
                {
                    parametres.vehicleAEditar = new Vehicle();
                    Vehicle.GetLlistatVehicles().Add(parametres.vehicleAEditar);
                }
                parametres.vehicleAEditar.Matricula = txtMatricula.Text;                
            }
            txbError.Text = errors;
        }

        private bool validacions(out string error)
        {
            error = "";
            if (!Vehicle.validaMatricula(txtMatricula.Text))
            {
                error = "Matricula incorrecta";
                return false;
            }
            return true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txbError.Text = "";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            mostrarVehicle(parametres.vehicleAEditar);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Vehicle.GetLlistatVehicles().Remove(parametres.vehicleAEditar);
            parametres.paginaPrincipal.AnarALListatVehicles();
        }
    }
}
