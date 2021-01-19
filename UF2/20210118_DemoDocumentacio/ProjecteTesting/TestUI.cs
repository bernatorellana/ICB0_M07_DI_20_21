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
            string ruta = System.AppDomain.CurrentDomain.BaseDirectory;
            ruta += @"\20210118_DemoDocumentacio.exe";
            Console.WriteLine(">" + ruta);
            Application app = Application.Launch(ruta);
            Window w = app.GetWindows()[0];
            TextBox txtOp1 = w.Get<TextBox>("txtOp1");
            txtOp1.Text = "4";
            TextBox txtOp2 = w.Get<TextBox>("txtOp2");
            txtOp2.Text = "3";
            Button btnProva = w.Get<Button>("btnProva");
            btnProva.Click();

            TextBox txtResultat = w.Get<TextBox>("txtResultat");
            Assert.AreEqual(7, Int32.Parse( txtResultat.Text) );

             

        }
    }
}
