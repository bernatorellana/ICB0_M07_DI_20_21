using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBoxes_Amb_Objectes.Model
{
    public class Vehicle
    {
        private string marca;
        private string model;
        private string matricula;

        public Vehicle(string matricula, string marca, string model)
        {
            Matricula = matricula;
            Marca = marca;
            Model = model;
        }

        public string Marca { get => marca.ToUpper(); set => marca = value; }
        public string Model { get => model; set => model = value; }
        public string Matricula { get => matricula; set => matricula = value; }

        public string NomComplet
        {
            get
            {
                return Matricula + ">" + Marca + " " + Model;
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
            return Matricula + ">" + Marca + " " + Model;
        }



    }
}
