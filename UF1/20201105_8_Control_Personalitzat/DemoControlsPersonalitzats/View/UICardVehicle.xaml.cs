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
    public sealed partial class UICardVehicle : UserControl
    {
        public UICardVehicle()
        {
            this.InitializeComponent();
        }


        // escriviu "propdp" i tabuleu 2 cops (dibuixant prèviament un pentacle a terra)

        public String Matricula
        {
            get { return (String)GetValue(MatriculaProperty); }
            set { SetValue(MatriculaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Matricula.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MatriculaProperty =
            DependencyProperty.Register("Matricula", typeof(String), typeof(UICardVehicle), new PropertyMetadata(""));





        public String Model
        {
            get { return (String)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(String), typeof(UICardVehicle), new PropertyMetadata(""));



        public String Marca
        {
            get { return (String)GetValue(MarcaProperty); }
            set { SetValue(MarcaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Marca.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MarcaProperty =
            DependencyProperty.Register("Marca", typeof(String), typeof(UICardVehicle), new PropertyMetadata(""));



        public String ImageURL
        {
            get { return (String)GetValue(ImageURLProperty); }
            set { SetValue(ImageURLProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageURL.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageURLProperty =
            DependencyProperty.Register("ImageURL", typeof(String), typeof(UICardVehicle), new PropertyMetadata(""));



    }
}
