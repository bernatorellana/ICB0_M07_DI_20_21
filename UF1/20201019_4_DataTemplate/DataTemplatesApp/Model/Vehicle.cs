using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataTemplatesApp.Model
{
    public class Vehicle
    {
        private static List<Vehicle> _vehicles; // SINGLETON

        public static List<Vehicle> GetLlistatVehicles()
        {
            if (_vehicles == null)
            {

                _vehicles = new List<Vehicle>();

                Vehicle v1 = new Vehicle("4545FRT", Marca.GetMarcaPerId(1), "Leon");
                Vehicle v2 = new Vehicle("6322KKK", Marca.GetMarcaPerId(2), "FI");
                Vehicle v3 = new Vehicle("8888NNN", Marca.GetMarcaPerId(3), "A8");
                Vehicle v4 = new Vehicle("6666NNN", Marca.GetMarcaPerId(3), "A5");
                //--------------------------------------------
                _vehicles.Add(v1);
                _vehicles.Add(v2);
                _vehicles.Add(v3);
                //--------------------------------------------

                //---------------------------------------------
                Usuari u1 = new Usuari(1, "Maria");
                Usuari u2 = new Usuari(2, "Joan");
                Usuari u3 = new Usuari(3, "Cristina");
                Usuari u4 = new Usuari(4, "Pep");
                v1.AfegirUsuari(u1);
                v1.AfegirUsuari(u2);
                v2.AfegirUsuari(u3);
                v3.AfegirUsuari(u4);
            }
            return _vehicles;
        }





        public const int MAX_USUARIS = 3;

        private Marca marca;
        private string model;
        private string matricula;
        private ObservableCollection<Usuari> usuaris;
        private int tipusAsseguranca;
        private List<string> extres;

        public Vehicle(string matricula, Marca marca, string model)
        {
            Matricula = matricula;
            MarcaP = marca;
            Model = model;
            //-------------
            // inicialitzem la llista
            usuaris = new ObservableCollection<Usuari>();
            extres = new List<string>();
        }

        public List<string> Extres { get => extres;  }

        public bool afegirExtra(String codi)
        {
            if (!extres.Contains(codi))
            {
                extres.Add(codi);
                return true;
            }
            return false;
        }

        // Només pot haver-hi 3 usuaris com a màxim
        // No es poden repetir usuaris
        public Boolean AfegirUsuari(Usuari nouUsuari)
        {
            if (usuaris.Count == MAX_USUARIS) return false;
            if (usuaris.Contains(nouUsuari)) return false;
             usuaris.Add(nouUsuari);
            return true;
        }

        /// <summary>
        /// Llista d'usuaris (només lectura)
        /// </summary>
        public ObservableCollection<Usuari> Usuaris {
            get => usuaris;
        }

        public int GetNumeroUsuaris()
        {
            return usuaris.Count;
        }
        public Usuari GetUsuari(int index)
        {
            return usuaris[index];
        }



        public Marca MarcaP { get => marca; set => marca = value; }
        public string Model { get => model; set => model = value; }
        public string Matricula { get => matricula;
            set {
                if (!validaMatricula(value)) throw new Exception("Matrícula no vàlida.");
                matricula = value; }
        }

        public string NomComplet
        {
            get
            {
                return Matricula + ">" + MarcaP.Nom + " " + Model;
            }
        }

        public int TipusAsseguranca { get => tipusAsseguranca;
            set
            {
                if (value < 0 || value > 2) throw new Exception("Tipus assegurança invàlid");
                tipusAsseguranca = value;
            }
        }


        public override bool Equals(object obj)
        {
            var vehicle = obj as Vehicle;
            return vehicle != null &&
                   Matricula == vehicle.Matricula;
        }

        public override int GetHashCode()
        {
            return -388471697 + EqualityComparer<string>.Default.GetHashCode(Matricula);
        }

        public override string ToString()
        {
            return NomComplet;
        }

        public static bool validaMatricula(string text)
        {
            return Regex.Match(text, "^[0-9]{4}[QWRTYPSDFGHJKLZXCVBNM]{3}$", RegexOptions.IgnoreCase).Success;
        }

    }
}
