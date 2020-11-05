using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoControlsPersonalitzats.Model
{
    public class Usuari
    {
        private long id;
        private String nom;

        public Usuari(long id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public long Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public override bool Equals(object obj)
        {
            var usuari = obj as Usuari;
            return usuari != null &&
                   Id == usuari.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }
    }
}
