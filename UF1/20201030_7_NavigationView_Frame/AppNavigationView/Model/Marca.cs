using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNavigationView.Model
{
    public class Marca
    {

        private static List<Marca> _marques;

        public static List<Marca> GetLlistaMarques()
        {
            if(_marques==null)
            {
                _marques = new List<Marca>();
                _marques.Add(new Marca(1, "Seat", "http://www.brandemia.org/wp-content/uploads/2012/10/logo_principal_seat.jpg"));
                _marques.Add(new Marca(2, "Volkswagen", "https://mpng.subpng.com/20180403/jjw/kisspng-car-volkswagen-group-mercedes-benz-nissan-ico-5ac3d9760c3471.87627301152278463005.jpg"));
                _marques.Add(new Marca(3, "Audi", "https://1000marcas.net/wp-content/uploads/2019/12/Audi-Logo-800x450.png"));
            }
            return _marques;
        }

        public static Marca GetMarcaPerId( int idBuscat )
        {
            foreach(Marca m in GetLlistaMarques())
            {
                if (m.Id == idBuscat) return m;
            }
            return null;
        }

        public override bool Equals(object obj)
        {
            var marca = obj as Marca;
            return marca != null &&
                   Id == marca.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }


        //-----------------------------------------------------
        private int id;
        private String nom;
        private String url;

        public Marca(int id, string nom, string url)
        {
            Id = id;
            Nom = nom;
            Url = url;

        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Url { get => url; set => url = value; }


    }
}
