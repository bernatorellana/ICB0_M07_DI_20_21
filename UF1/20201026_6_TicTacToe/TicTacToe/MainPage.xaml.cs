﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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

       private const string URL_EMPTY = "ms-appx:///Assets/FFFFFF-0.png";
       private const string URL_P1 =    "https://img.icons8.com/officel/2x/delete-sign.png";
       private const string URL_P2 =    "https://img.icons8.com/emoji/2x/hollow-red-circle-emoji.png";
       private  string[] URL_PLAYERS = { URL_P1, URL_P2 };
       private BitmapImage[] imatges; 
       private int playerActual = 0;


        private enum CASELLA
        {
            CBUIDA,
            CP1,
            CP2
        }

        private CASELLA[,] tauler;


        public MainPage()
        {
            this.InitializeComponent();
        }

        private int N = 5;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tauler = new CASELLA[N,N];

            // Precarreguem les imatges
            imatges = new BitmapImage[URL_PLAYERS.Length];
            for (int i = 0; i < URL_PLAYERS.Length; i++)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.UriSource = new Uri(URL_PLAYERS[i]);
                imatges[i] = bitmap;
            }

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

            // Creem totes les NxN imatges del tauler
            for (int r = 0; r < N; r++)
            {
                for (int c = 0; c < N; c++)
                {
                    tauler[r, c] = CASELLA.CBUIDA;

                    //<Border BorderThickness="1" BorderBrush="Red">
                    //  <Image Source="https://img.icons8.com/officel/2x/delete-sign.png"></Image>
                    //</Border>
                    Border b = new Border();

                    //   _______________
                    //  |               
                    //  |               
                    //  |               

                    //   _______________
                    //  |               
                    //  |               
                    //  |               

                    //   _______________
                    //  |               
                    //  |               
                    //  |               
                    b.BorderThickness = new Thickness(2, 2, c==N-1?2:0, r==N-1?2:0);
                    b.BorderBrush = new SolidColorBrush(Colors.Black);

                    Image im = new Image();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.UriSource = new Uri(URL_EMPTY);
                    im.Source = bitmap;

                    im.Tapped += Im_Tapped;

                    b.Child = im;

                    im.Tag = new Coord(r, c); //a quina fila i a quina columna estic;

                    Grid.SetColumn(b, c);
                    Grid.SetRow(b, r);
                    grdTauler.Children.Add(b);

                }
            }


        }

        private void Im_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Image i = (Image)sender;
            Coord c = (Coord) i.Tag;
            if( tauler[c.r, c.c] == CASELLA.CBUIDA )
            {
                tauler[c.r, c.c] = playerActual==0?CASELLA.CP1:CASELLA.CP2;                
                i.Source = imatges[playerActual]; //P1                
                playerActual= (playerActual+1)%2;
            }
        }
    }
}
