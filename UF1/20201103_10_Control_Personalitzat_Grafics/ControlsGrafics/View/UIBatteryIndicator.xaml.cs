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
using Microsoft.Toolkit.Uwp.Helpers;
// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace ControlsGrafics.View
{
    public sealed partial class UIBatteryIndicator : UserControl
    {
        public UIBatteryIndicator()
        {
            this.InitializeComponent();
        }



        public int PercentatgeCarrega
        {
            get { return (int)GetValue(PercentatgeCarregaProperty); }
            set { SetValue(PercentatgeCarregaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PercentatgeCarrega.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PercentatgeCarregaProperty =
            DependencyProperty.Register("PercentatgeCarrega", typeof(int), typeof(UIBatteryIndicator), 
                new PropertyMetadata(0,PercentatgeChangedCallbackStatic));

        private static void PercentatgeChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIBatteryIndicator bat = (UIBatteryIndicator)d;
            bat.PercentatgeChangedCallback(e);
        }


        
        private  void PercentatgeChangedCallback(DependencyPropertyChangedEventArgs e)
        {
            if (PercentatgeCarrega > 100) PercentatgeCarrega = 100;

            double hue =  120 * PercentatgeCarrega /100.0;
            Color c = Microsoft.Toolkit.Uwp.Helpers.ColorHelper.FromHsv(hue, 1, 1);

            LinearGradientBrush lgb = (LinearGradientBrush) recPila.Fill;
            lgb.GradientStops[1].Color = c;// PercentatgeCarrega > 50 ? Colors.GreenYellow : Colors.Red;


            // estic aquí quan des de l'exterior m'assignen un nou percentatge
            //<Rectangle  Width="7" Height="38" Fill="Black" Margin="1"></Rectangle>
            int numRectangles = PercentatgeCarrega / 10;
            stkRalletes.Children.Clear();
            for (int i=0;i<numRectangles;i++)
            {
                Rectangle r = new Rectangle();
                r.Width = 7;
                r.Height = 38;
                r.Fill = new SolidColorBrush(Colors.Black);
                r.Margin = new Thickness( 1 );
                stkRalletes.Children.Add(r);
            }

        }






        public bool EsVertical
        {
            get { return (bool)GetValue(EsVerticalProperty); }
            set { SetValue(EsVerticalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EsVertical.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EsVerticalProperty =
            DependencyProperty.Register("EsVertical", typeof(bool), 
                typeof(UIBatteryIndicator), new PropertyMetadata(false, EsVerticalChangedCallbackStatic));

        private static void EsVerticalChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIBatteryIndicator b = (UIBatteryIndicator)d;
            b.EsVerticalChangedCallback(e);
        }
        private void EsVerticalChangedCallback(
            DependencyPropertyChangedEventArgs e)
        {
            CompositeTransform ct = new CompositeTransform();
            if (EsVertical)
            {
                Width = 50;
                Height = 112;
                ct.Rotation = -90;
                ct.TranslateY = 112;
            } else
            {
                Height = 50;
                Width= 112;
            }
            cnvPila.RenderTransform = ct; 
        }
        // cnvPila
        //<!--.RenderTransform>
        //    <CompositeTransform Rotation = "-90" TranslateY="112"></CompositeTransform>
        //</-->

            /*
        public new int Height
        {
            get { return EsVertical ? 120 : 50; }
            
        }

        public new int Width
        {
            get { return !EsVertical ? 120 : 50; }

        }*/



    }
}
