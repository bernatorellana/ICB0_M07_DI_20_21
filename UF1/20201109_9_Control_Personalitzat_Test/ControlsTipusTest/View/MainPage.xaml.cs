﻿using ControlsTipusTest.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ControlsTipusTest.View
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
            uiexam.Preguntes = Pregunta.GetPreguntes();
        }

        private async void uiexam_OnFinishedExamen(object sender, EventArgs e)
        {

            string url = "https://previews.123rf.com/images/cubrazol/cubrazol1004/cubrazol100400336/6845693-a-winner-flag-with-checkered-pattern.jpg";

            var rass = RandomAccessStreamReference.CreateFromUri(new Uri(url));
            using (IRandomAccessStream stream = await rass.OpenReadAsync())
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(stream);
                imgFinal.Source = bitmapImage;
            }

        }
    }
}
