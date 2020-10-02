using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace DemoControl_i_classes
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int a = 3;
            if (a == 2) a++;
            a++;
            //que val a?

            string color = (a > 3) ? "Blau" : "Vermell";
            int nota = (a==3)? 1:2;


            string[] persones = { "Maria", "Berta","", "Joan" };
            
            for(int i=0;  i<persones.Length;   i++)
            {
                Debug.WriteLine(">" + persones[i].ToUpper());
            }
            string[] buida = new string[10];
            
            foreach(string p in buida)
            {
                Debug.WriteLine(">" + p);
            }

            //----------------------------------
            Persona p1 = new Persona(1, "11111111H", "Maria"); 
            Persona p2 = new Persona(2, "12345678Z", "Joanola");
            Persona p3 = new Persona(3, "22222222J", "Anabel");
            //----------------------------------

            List<Persona> llistaPersones = new List<Persona>();
            Debug.WriteLine(llistaPersones.Count);
            llistaPersones.Add(p1);
            llistaPersones.Add(p2);
            llistaPersones.Add(p3);
            foreach(Persona p in llistaPersones)
            {
                Debug.WriteLine(">" + p.Id + " " + p.Nom);
            }

            Debug.WriteLine(llistaPersones.Count);
            //----------------------------------------------
            //llistaPersones.RemoveAt(0);
            llistaPersones.Remove(p1);
            for(int i=0;i< llistaPersones.Count; i++)
            {
                Persona p = llistaPersones[i];
                Debug.WriteLine(">" + p.Id + " " + p.Nom);
            }
            //-----------------------------------------------
            Debug.WriteLine("p2 existeix?" + llistaPersones.Contains(p2));

            Persona p2bis = new Persona(2, "12345678Z", "Joanola");
            Debug.WriteLine("p2 existeix?" + llistaPersones.Contains(p2bis));
            //-----------------------------------------------
            Dictionary<Int32, String> equip = new Dictionary<Int32, string>();
            equip[10] = "Messi";
            equip[3] = "Piquè";
            Dictionary<String, Int32> noms = new Dictionary<String, Int32>();
            noms["Messi"] = 10;
            noms["Pique"] = 3;
            noms["Dembelè"] = 3;
            //---------------------------------------
            Debug.WriteLine(noms["Messi"]);
            if (noms.ContainsKey("Dembelè"))
            {
                Debug.WriteLine(noms["Dembelè"]);
            } else
            {
                Debug.WriteLine("Dembelè not found exception");
            }
            //---------------------------------------




        }
    }
}
