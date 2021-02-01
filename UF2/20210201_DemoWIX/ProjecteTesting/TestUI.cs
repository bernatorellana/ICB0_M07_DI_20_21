using _20210118_DemoDocumentacio.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace ProjecteTesting
{
    [TestClass]
    public class TestUI
    {
        [TestMethod]
        public void TestSumaUI()
        {
            Window w = StartApplicationAndGetWindow();
            TextBox txtOp1 = w.Get<TextBox>("txtOp1");
            txtOp1.Text = "4";
            TextBox txtOp2 = w.Get<TextBox>("txtOp2");
            txtOp2.Text = "3";
            Button btnProva = w.Get<Button>("btnProva");
            btnProva.Click();

            TextBox txtResultat = w.Get<TextBox>("txtResultat");
            Assert.AreEqual(7, Int32.Parse(txtResultat.Text));
            w.Close();
        }

        private static Window StartApplicationAndGetWindow()
        {
            string ruta = System.AppDomain.CurrentDomain.BaseDirectory;
            ruta += @"\20210118_DemoDocumentacio.exe";
            Console.WriteLine(">" + ruta);
            Application app = Application.Launch(ruta);
            Window w = app.GetWindows()[0];
            return w;
        }

        [TestMethod]
        public void TestSeleccioDatagrid()
        {
            Window w = StartApplicationAndGetWindow();
            ListView dtgVehicles = w.Get<ListView>("dtgVehicles");

            int indexVehicleSeleccionat = 1;
            dtgVehicles.Rows[indexVehicleSeleccionat].Cells[0].Click();
            TextBox txtMatricula = w.Get<TextBox>("txtMatricula");
            TextBox txtMarca = w.Get<TextBox>("txtMarca");
            // Fer verificació
            Vehicle vehicleSeleccionat = Vehicle.GetVehicles()[indexVehicleSeleccionat];
            Assert.AreEqual(vehicleSeleccionat.Matricula,   txtMatricula.Text);
            Assert.AreEqual(vehicleSeleccionat.Marca,       txtMarca.Text);
            w.Close();
        }
    }
}
