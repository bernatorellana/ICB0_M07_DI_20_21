using DemoControlsPersonalitzats.Model;
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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace DemoControlsPersonalitzats.View
{
    public sealed partial class NavegacioVehicles : UserControl
    {
        public NavegacioVehicles()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Esdeveniment que llançarem quan canvii la selecció !
        /// </summary>
        public event EventHandler SelectionChanged;

        private void mostraLlista()
        {
            if (LlistaVehicles != null &&
                SelectedIndex < LlistaVehicles.Count
                && SelectedIndex >= 0)
            {
                cardVehicle.vehicle = LlistaVehicles[SelectedIndex];
                txtNum.Text = (SelectedIndex + 1) + "";
            }
        }

        #region propietat LlistaVehicles i callbacks

        public List<Vehicle> LlistaVehicles
        {
            get { return (List<Vehicle>)GetValue(vehiclesProperty); }
            set { SetValue(vehiclesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for vehicles.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty vehiclesProperty =
            DependencyProperty.Register("LlistaVehicles", 
                typeof(List<Vehicle>),
                typeof(NavegacioVehicles), 
                new PropertyMetadata(new List<Vehicle>(),llistaVehiclesCanviadaStatic));

        // Mètode de callback que és cridat quan la LlistaVehicles canvia
        private static void llistaVehiclesCanviadaStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NavegacioVehicles n = (NavegacioVehicles)d;
            n.llistaVehiclesCanviada(e);
        }
        // Mètode de classe que és cridat quan la LlistaVehicles canvia
        // HEU DE PROGRAMAR AQUí !!!!!!
        private void llistaVehiclesCanviada(
            DependencyPropertyChangedEventArgs e)
        {
            mostraLlista();
        }

        #endregion propietat LlistaVehicles i callbacks

        #region propietat SelectedValue i callbacks
        public Vehicle SelectedValue
        {
            get { return (Vehicle)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register("SelectedValue", typeof(Vehicle), 
                typeof(NavegacioVehicles), new PropertyMetadata(null, SelectedValueChangedCallbackStatic));

        private static void SelectedValueChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NavegacioVehicles n = (NavegacioVehicles)d;
            n.SelectedValueChangedCallback(e);
        }
        private  void SelectedValueChangedCallback( DependencyPropertyChangedEventArgs e)
        {
            SelectedIndex = LlistaVehicles.IndexOf(SelectedValue);            
        }

        #endregion propietat SelectedValue i callbacks

        #region propietat SelectedIndex i callbacks

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", 
                typeof(int), typeof(NavegacioVehicles), 
                new PropertyMetadata(0, selectedIndexChangedCallbackStatic));

        private static void selectedIndexChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NavegacioVehicles n = (NavegacioVehicles)d;
            n.selectedIndexChangedCallback(e);
        }
        private void selectedIndexChangedCallback(DependencyPropertyChangedEventArgs e)
        {
            // Si estic aquí és que alguna mala persona vol
            // canviar el SelectedIndex
            SelectedValue = LlistaVehicles[SelectedIndex];
            mostraLlista();
            // Llancem l'esdeveniment que el valor seleccionat ha canviat
            SelectionChanged?.Invoke(this, new EventArgs());
        }

        #endregion propietat SelectedIndex i callbacks

        #region events de botonera
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            SelectedIndex = 0;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            passarSeguent(-1);
        }

        private void passarSeguent(int inc)
        {
            int index = SelectedIndex + inc;
            if (index < 0) index = LlistaVehicles.Count-1;
            else if (index > LlistaVehicles.Count - 1) index = 0;
            SelectedIndex = index; // aquí salta el callback de SelectedIndex
                       
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            passarSeguent(+1);
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            SelectedIndex = LlistaVehicles.Count-1;
        }

        #endregion events de botonera
    }
}
