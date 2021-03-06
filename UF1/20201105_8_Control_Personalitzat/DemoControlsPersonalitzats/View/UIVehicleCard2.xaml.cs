﻿using DemoControlsPersonalitzats.Model;
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
    public sealed partial class UIVehicleCard2 : UserControl
    {
        public UIVehicleCard2()
        {
            this.InitializeComponent();
        }




        public Vehicle vehicle
        {
            get { return (Vehicle)GetValue(vehicleProperty); }
            set { SetValue(vehicleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for vehicle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty vehicleProperty =
            DependencyProperty.Register("vehicle", typeof(Vehicle), typeof(UIVehicleCard2), new PropertyMetadata(new Vehicle()));



    }
}
