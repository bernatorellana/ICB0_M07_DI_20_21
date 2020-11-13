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

            double hue =  360 * PercentatgeCarrega /100.0;
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
    }
}
