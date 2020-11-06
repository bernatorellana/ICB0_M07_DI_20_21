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




        public List<Vehicle> LlistaVehicles
        {
            get { return (List<Vehicle>)GetValue(vehiclesProperty); }
            set { SetValue(vehiclesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for vehicles.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty vehiclesProperty =
            DependencyProperty.Register("LlistaVehicles", typeof(List<Vehicle>), typeof(NavegacioVehicles), new PropertyMetadata(new List<Vehicle>()));



        public Vehicle SelectedValue
        {
            get { return (Vehicle)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register("SelectedValue", typeof(Vehicle), typeof(NavegacioVehicles), new PropertyMetadata(null));



        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(NavegacioVehicles), new PropertyMetadata(-1));





    }
}
