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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace TicTacToe
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

        private int N = 3;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

                /*
                 <Grid.RowDefinitions>
                    <RowDefinition Height="1*"></RowDefinition>
                    <RowDefinition Height="1*"></RowDefinition>
                    <RowDefinition Height="1*"></RowDefinition>
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="1*"></ColumnDefinition>
                    <ColumnDefinition Width="1*"></ColumnDefinition>
                    <ColumnDefinition Width="1*"></ColumnDefinition>
                </Grid.ColumnDefinitions>
                 */
            for (int i = 0; i < N; i++) {
                RowDefinition rd = new RowDefinition();
                rd.Height = new GridLength(1, GridUnitType.Star);
                grdTauler.RowDefinitions.Add(rd);
                //---------------------------------------------
                ColumnDefinition cd = new ColumnDefinition();
                cd.Width = rd.Height;
                grdTauler.ColumnDefinitions.Add(cd);
            }

            //<Image Source="https://img.icons8.com/officel/2x/delete-sign.png"></Image>
            Image im = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.UriSource = new Uri("ms-appx:///Assets/FFFFFF-0.png");
            im.Source = bitmap;
           

            Grid.SetColumn(im, 2);
            Grid.SetRow(im, 1);
            grdTauler.Children.Add(im);  




        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            int i = 0;
        }
    }
}
