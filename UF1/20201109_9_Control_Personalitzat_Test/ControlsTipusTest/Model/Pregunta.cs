using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlsTipusTest.Model
{
    public class Pregunta
    {
        #region singleton_get_preguntes
        private static List<Pregunta> _preguntes;
        public static List<Pregunta> GetPreguntes()
        {
            if(_preguntes==null)
            {

                _preguntes = new List<Pregunta>();
                Pregunta p1 = new Pregunta("H2O és?", 0, 1.0);
                    p1.addResposta("Aigua");
                    p1.addResposta("Amoniac");
                    p1.addResposta("Whisky");
                    p1.addResposta("Hidroalcoholic");
                _preguntes.Add(p1);

                Pregunta p2 = new Pregunta("NH3 és?", 1, 1.0);
                p2.addResposta("Aigua");
                p2.addResposta("Whisky");
                p2.addResposta("Amoniac");                
                p2.addResposta("Hidroalcoholic");
                _preguntes.Add(p2);

                Pregunta p3 = new Pregunta("O3 és?", 2, 1.0);
                p3.addResposta("Superoxigen");
                p3.addResposta("Tres os");
                p3.addResposta("Ozó");
                p3.addResposta("WTF?");
                _preguntes.Add(p3);

            }
            return _preguntes;
        }
        #endregion

        //---------------------------------------------------

        private List<String> respostes;
        private String enunciat;
        private int indexRespostaCorrecta;
        private double valor;
        private int indexRespostaSeleccionada;
        private const int NO_SELECCIONAT = -1;

        public Pregunta(string enunciat, int indexRespostaCorrecta, double valor)
        {
            this.Enunciat = enunciat;
            this.IndexRespostaCorrecta = indexRespostaCorrecta;
            this.Valor = valor;
            respostes = new List<String>();
            IndexRespostaSeleccionada = NO_SELECCIONAT;
        }

        public double GetPuntuacio()
        {
            if (IndexRespostaSeleccionada == NO_SELECCIONAT) return 0;
            if (IndexRespostaSeleccionada == indexRespostaCorrecta) return Valor;
            else return - Valor / (double)(Respostes.Count);
        }

        public void addResposta(String r)
        {
            respostes.Add(r);
        }

        #region Propietats

        public string Enunciat { get => enunciat; set => enunciat = value; }
        public List<string> Respostes { get => respostes; set => respostes = value; }
        public int IndexRespostaCorrecta { get => indexRespostaCorrecta; set => indexRespostaCorrecta = value; }
        public double Valor { get => valor; set => valor = value; }
        public int IndexRespostaSeleccionada { get => indexRespostaSeleccionada; set => indexRespostaSeleccionada = value; }

        #endregion
    }
}
