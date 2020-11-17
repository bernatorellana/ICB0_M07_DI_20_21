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
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace Grafics.View
{
    public sealed partial class SuperChart : UserControl
    {
        public SuperChart()
        {
            this.InitializeComponent();
        }



        public Color ColorBarra
        {
            get { return (Color)GetValue(ColorBarraProperty); }
            set { SetValue(ColorBarraProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColorBarra.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorBarraProperty =
            DependencyProperty.Register("ColorBarra", typeof(Color), typeof(SuperChart), new PropertyMetadata(Colors.BlueViolet));



        public Dictionary<String, Double> Valors
        {
            get { return (Dictionary<String, Double>)GetValue(ValorsProperty); }
            set { SetValue(ValorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Valors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValorsProperty =
            DependencyProperty.Register("Valors", 
                typeof(Dictionary<String,Double>), typeof(SuperChart), 
                new PropertyMetadata(null, ValorsChangedCallbackStatic));

        private static void ValorsChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SuperChart s = (SuperChart)d;
            s.ValorsChangedCallback(e);
        }
        private void ValorsChangedCallback(DependencyPropertyChangedEventArgs e)
        {
            dibuixaGrafica();
        }

        private void dibuixaGrafica()
        {
            /*
             * 
             * 
             * 
             * 
             *  **
             *  **
             *  **
             * **|*******************************************/
              //DI
            Double max = Valors.Values.Max();
            Double min = 0;// Valors.Values.Min();

            int midaColumna = (int)( Width / Valors.Count);
            int midaBarra = (int)( 0.75 * midaColumna);

            int Height2 = (int)(Height * 0.75);

            //------------------------------------------
            Line eixVertical = new Line();
            eixVertical.X1 = eixVertical.X2 =  0;
            eixVertical.Y1 = 0;
            eixVertical.Y2 = Height2;

            SolidColorBrush colorLinia = new SolidColorBrush(Colors.Black);
            eixVertical.Stroke = colorLinia;
            eixVertical.StrokeThickness = 1;
            //------------------------------------
            Line eixHoritzontal = new Line();
            eixHoritzontal.X1 = 0;
            eixHoritzontal.X2 = Width;
            eixHoritzontal.Y1 = Height2;
            eixHoritzontal.Y2 = Height2;
            eixHoritzontal.Stroke = colorLinia;
            eixHoritzontal.StrokeThickness = 1;

            cnvGrafica.Children.Add(eixVertical);
            cnvGrafica.Children.Add(eixHoritzontal);
            //------------------------------------
            SolidColorBrush colorBarra = 
                new SolidColorBrush(ColorBarra);
             

            int left = 0;
            foreach (String clau in Valors.Keys)
            {
                double valor = Valors[clau];
                int alsada = (int)(Height2 * (valor - min) / (max - min));
                Rectangle r = new Rectangle();
                r.Width = midaBarra;
                r.Height = alsada;
                r.Fill = colorBarra;
                r.Stroke = colorLinia;
                r.StrokeThickness = 1;
                Canvas.SetLeft(r, left);
                Canvas.SetTop(r, Height2 - alsada );
                cnvGrafica.Children.Add(r);
                
                TextBlock t = new TextBlock();
                t.Text = clau;
                t.FontSize = 8;
                
                Canvas.SetLeft(t, left+ midaBarra/2);
                Canvas.SetTop(t, Height2 + 2);

                RotateTransform gir = new RotateTransform();
                gir.Angle=30;                
                t.RenderTransform = gir;

                cnvGrafica.Children.Add(t);

                left += midaColumna;
            }        
        }

        // DI 30, ÉD 10, 

    }
}
