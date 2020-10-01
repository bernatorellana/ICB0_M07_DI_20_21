using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoControl_i_classes
{
    class Persona
    {
        private int id;
        private string nif;
        private string nom;

        public Persona(int pId, string pNIF, string pNom)
        {
            this.Id = pId;
            this.Nif = pNIF;
            this.Nom = pNom;
        }

        public int Id {
            get
            {
             return   id;
            }
            set
            {
                if (value < 0) throw new Exception("Id negatiu no permés");
                id = value;
            }
        }


        public string Nom
        {
            get
            {
                return nom;
            }
            set//(string value)
            {
                if ( value.Length<5 || value.Length > 10) throw new Exception("Noms amb menys de 5 caràcters no permesos");
                nom = value;
            }
        }

        public string Nif
        {
            get
            {
                return nif;
            }
            set//(string value)
            {
                if (!validaNif(value)) throw new Exception("NIF erroni");
                nif = value;
            }
        }

        private bool validaNif(string pNif)
        {
            ///--------------------------------------------
            /// Versió 1: casolà
            /// 
            /// 
            /*if (pNif.Length != 9) return false;
            for(int i=0;i<8;i++)
            {
                if (pNif[i] < '0' || pNif[i] > '9') return false;
            }
            if ("MYFPDXBNJZSQVHLCKE".IndexOf(pNif[8])<0) return false;
            
            return true;*/
            /// --------------------------------------------
            /// Versió 2: RegularExpression
            /// 
            // Step 1: create new Regex.
            /*Regex regex = new Regex(@"[0-9]{8}[MYFPDXBNJZSQVHLCKE]");

            // Step 2: call Match on Regex instance.
            Match match = regex.Match(pNif);

            // Step 3: test for Success.
            return (match.Success);
            */

            /// --------------------------------------------
            /// Versió 3: StackOverflow (Powered by Dani)
            /// 
            return validDNIDownloaded(pNif);
        }

        

        public static bool validDNIDownloaded(string data)
        {
            if (data == String.Empty)
                return false;
            try
            {
                String letra;
                letra = data.Substring(data.Length - 1, 1);
                data = data.Substring(0, data.Length - 1);
                int nifNum = int.Parse(data);
                int resto = nifNum % 23;
                string tmp = getLetra(resto);
                if (tmp.ToLower() != letra.ToLower())
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        private static string getLetra(int id)
        {
            Dictionary<int, String> letras = new Dictionary<int, string>();
            letras.Add(0, "T");
            letras.Add(1, "R");
            letras.Add(2, "W");
            letras.Add(3, "A");
            letras.Add(4, "G");
            letras.Add(5, "M");
            letras.Add(6, "Y");
            letras.Add(7, "F");
            letras.Add(8, "P");
            letras.Add(9, "D");
            letras.Add(10, "X");
            letras.Add(11, "B");
            letras.Add(12, "N");
            letras.Add(13, "J");
            letras.Add(14, "Z");
            letras.Add(15, "S");
            letras.Add(16, "Q");
            letras.Add(17, "V");
            letras.Add(18, "H");
            letras.Add(19, "L");
            letras.Add(20, "C");
            letras.Add(21, "K");
            letras.Add(22, "E");
            return letras[id];

        }

    }
}
