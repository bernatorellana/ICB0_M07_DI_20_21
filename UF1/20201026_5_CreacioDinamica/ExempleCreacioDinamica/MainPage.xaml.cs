using System;
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
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ExempleCreacioDinamica
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

        private void Button_Click_Afegir(object sender, RoutedEventArgs e)
        {
            /*
                <StackPanel Orientation="Horizontal">
                    <Button Content="X"></Button>
                    <TextBox IsEnabled="False"></TextBox>
                </StackPanel>
            */

            StackPanel stp = new StackPanel();
            stp.Orientation = Orientation.Horizontal;

            Button b = new Button();
            b.Content = "X";
            // Ara volem programar dinàmicament el click sobre aquest botó
            b.Click += B_Click;
            b.Tag = false;


            TextBox t = new TextBox();
            t.IsEnabled = false;

            stp.Children.Add(b);
            stp.Children.Add(t);

            stkBotons.Children.Add(stp);
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Boolean actiu = !(Boolean)b.Tag;
            b.Tag = actiu;

            b.Background = actiu?   new SolidColorBrush(Colors.Lime): 
                                    new SolidColorBrush(Colors.Transparent);

            StackPanel stp = (StackPanel) b.Parent;
            TextBox t = (TextBox) stp.Children[1];

            t.Background = b.Background;
            /*
               <StackPanel Orientation="Horizontal">
                 -->  <Button Content="X"></Button>
                   <TextBox IsEnabled="False"></TextBox>
               </StackPanel>
           */

        }

        private void Button_Click_Esborrar(object sender, RoutedEventArgs e)
        {
            if (stkBotons.Children.Count > 0)
            {
                stkBotons.Children.RemoveAt(0);
            }
        }
    }
}
