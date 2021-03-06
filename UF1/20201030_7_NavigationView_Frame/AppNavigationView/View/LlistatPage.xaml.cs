﻿using AppNavigationView.Model;
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
    public sealed partial class LlistatPage : Page
    {
        private MainPage paginaPrincipal;

        public LlistatPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lsvVehicles.ItemsSource = Vehicle.GetLlistatVehicles();
        }

        private void lsvVehicles_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (lsvVehicles.SelectedItem != null)
            {
                paginaPrincipal.mostraEdicioVehicle((Vehicle) lsvVehicles.SelectedItem);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            paginaPrincipal = (MainPage) e.Parameter;
        }
    }
}
