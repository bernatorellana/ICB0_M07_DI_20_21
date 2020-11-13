using ControlsTipusTest.Model;
using System;
using System.Collections.Generic;
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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace ControlsTipusTest.View
{
    public sealed partial class UIExam : UserControl
    {
        public event EventHandler OnFinishedExamen;

        List<RadioButton> radioButtonsRespostes = new List<RadioButton>();
        private int indexPreguntaActual=0;

        public UIExam()
        {
            this.InitializeComponent();
        }




        public bool HaFinalitzat
        {
            get { return (bool)GetValue(HaFinalitzatProperty); }
            set { SetValue(HaFinalitzatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HaFinalitzat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HaFinalitzatProperty =
            DependencyProperty.Register("HaFinalitzat", typeof(bool), typeof(UIExam), new PropertyMetadata(false));



        public double Puntuacio
        {
            get { return (double)GetValue(PuntuacioProperty); }
            set { SetValue(PuntuacioProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Puntuacio.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PuntuacioProperty =
            DependencyProperty.Register("Puntuacio", typeof(double), typeof(UIExam), new PropertyMetadata(0));



        public Pregunta PreguntaActual
        {
            get { return (Pregunta)GetValue(PreguntaActualProperty); }
            set { SetValue(PreguntaActualProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreguntaActualProperty =
            DependencyProperty.Register("PreguntaActual", typeof(Pregunta), typeof(UIExam), new PropertyMetadata(null));




        public List<Pregunta> Preguntes
        {
            get { return (List<Pregunta>)GetValue(PreguntesProperty); }
            set { SetValue(PreguntesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Preguntes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreguntesProperty =
            DependencyProperty.Register("Preguntes", 
                typeof(List<Pregunta>), 
                typeof(UIExam), new PropertyMetadata(null, PreguntesChangedCallbackStatic));

        private static void PreguntesChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIExam ui = (UIExam)d;
            ui.PreguntesChangedCallback(e);
        }

        private void PreguntesChangedCallback(DependencyPropertyChangedEventArgs e)
        {
            if (Preguntes.Count > 0)
            {
                indexPreguntaActual = 0;
                PreguntaActual = Preguntes[indexPreguntaActual];
            }
        }


        private void MoveClickPrev(object sender, RoutedEventArgs e)
        {
            indexPreguntaActual--;
            if (indexPreguntaActual < 0) indexPreguntaActual = Preguntes.Count - 1;

            mostraPreguntaActual();
            

        }

        private void mostraPreguntaActual()
        {
            PreguntaActual = Preguntes[indexPreguntaActual];
            if (PreguntaActual.IndexRespostaSeleccionada != -1)
            {
                // seleccionar radio button concret
                radioButtonsRespostes[PreguntaActual.IndexRespostaSeleccionada].IsChecked = true;
            } else
            {
                // no contestada
                DesseleccionarRadioButtons();
            }
        }

        private void MoveClickNext(object sender, RoutedEventArgs e)
        {
            indexPreguntaActual++;
            if (indexPreguntaActual >= Preguntes.Count) indexPreguntaActual = 0;
            mostraPreguntaActual();
          
        }

 
        private void btnUnselect_Click(object sender, RoutedEventArgs e)
        {
            DesseleccionarRadioButtons();
        }

        private void DesseleccionarRadioButtons()
        {
            PreguntaActual.IndexRespostaSeleccionada = -1;
            
            foreach (RadioButton element in radioButtonsRespostes)
            {
                element.IsChecked = false;                
            }
            VerificaSiTotesLesPreguntesEstanRespostes();
        }



        private void uiExam_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            foreach (UIElement element in stkPregunta.Children)
            {
                if (element is RadioButton)
                {
                    RadioButton r = (RadioButton)element;
                    radioButtonsRespostes.Add(r);
                    r.Tag=i++;
                    r.Checked += R_Checked; 
                }
            }
            VerificaSiTotesLesPreguntesEstanRespostes();
        }

        private void R_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            int indexSeleccionat = (int)r.Tag;
            PreguntaActual.IndexRespostaSeleccionada = indexSeleccionat;

            VerificaSiTotesLesPreguntesEstanRespostes();
        }

        private void VerificaSiTotesLesPreguntesEstanRespostes()
        {
            Boolean totesLesRespostesContestades = true;
            if (Preguntes == null)
            {
                totesLesRespostesContestades = false;
            }
            else
            {

                foreach (Pregunta p in Preguntes)
                {
                    if (p.IndexRespostaSeleccionada == -1)
                    {
                        totesLesRespostesContestades = false;
                        break;
                    }
                }
            }

            HaFinalitzat = totesLesRespostesContestades;
     
            btnFinish.Visibility = totesLesRespostesContestades ? Visibility.Visible : Visibility.Collapsed;
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            double puntuacio = 0;
            foreach(Pregunta p in Preguntes)
            {
                puntuacio += p.GetPuntuacio();
            }
            Puntuacio = puntuacio;
            this.IsEnabled = false;

  
            // Cridar l'esdeveniment
            OnFinishedExamen?.Invoke(this, new EventArgs());          
        }
    }
}
