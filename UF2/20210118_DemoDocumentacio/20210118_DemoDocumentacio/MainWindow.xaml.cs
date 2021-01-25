using _20210118_DemoDocumentacio.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _20210118_DemoDocumentacio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dtgVehicles.ItemsSource = Vehicle.GetVehicles();
        }

        private void btnProva_Click(object sender, RoutedEventArgs e)
        {
            int op1, op2;
            bool ok1 = Int32.TryParse(txtOp1.Text, out op1);
            bool ok2 = Int32.TryParse(txtOp2.Text, out op2);
            if(ok1&&ok2) {
                txtResultat.Text = (op1+op2)+"";
            } else {
                txtResultat.Text = "";
            }
             
        }
    }
}
