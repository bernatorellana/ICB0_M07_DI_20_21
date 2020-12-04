﻿using PelisApp.ViewModel;
using SakilaDB;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PelisApp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    /// 




    public sealed partial class MainPage : Page
    {

        private int itemsPerPagina = 10;
        private int numPagina = 0;
        private int totalPagines = 1;


        private enum Estat
        {
            VIEW,
            EDICIO,
            NOU
        }
        private Estat estat;

        private Estat EstatForm
        {
            get { return estat; }
            set
            {
                estat = value;
                btncancel.Visibility = toVisibility(estat != Estat.VIEW);
                btnSave.Visibility = Visibility.Visible;//btncancel.Visibility;
                btnDelete.Visibility = toVisibility(estat == Estat.VIEW);
                btnNew.Visibility = btnDelete.Visibility;
            }
        }

        private Visibility toVisibility(bool v)
        {
            return (v) ? Visibility.Visible : Visibility.Collapsed;
        }

        public String Test
        {
            get { return (String)GetValue(TestProperty); }
            set { SetValue(TestProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Test.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TestProperty =
            DependencyProperty.Register("Test", typeof(String), typeof(MainPage), new PropertyMetadata("HOLA"));


        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dtpPicker.Date = new DateTime(2000, 1, 1);
            actualitzaPaginacioDesDelFormulari();

            EstatForm = Estat.VIEW;
            
        }





        public ActorViewModel Actor
        {
            get { return (ActorViewModel)GetValue(ActorProperty); }
            set { SetValue(ActorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Actor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActorProperty =
            DependencyProperty.Register("Actor", typeof(ActorViewModel), typeof(MainPage), new PropertyMetadata(new ActorViewModel()));




        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            this.numPagina = 0;
            actualitzaPaginacioDesDelFormulari();
        }

        private void actualitzaPaginacioDesDelFormulari()
        {
            
            btnPagina.Content = (this.numPagina+1) + "";
            actualitzaPaginacio(txtNameFilter.Text,
                                            txtSurnameFilter.Text,
                                            dtpPicker.Date.DateTime, itemsPerPagina, numPagina);

            btnPrev.IsEnabled = btnFirst.IsEnabled = this.numPagina > 0;
            btnNext.IsEnabled = btnLast.IsEnabled = this.numPagina < this.totalPagines - 1;

        }

        private void actualitzaPaginacio(string v1, string v2, DateTime dateTime, int itemsPerPagina, int numPagina)
        {
            int numeroActors = ActorDB.getNumeroActors(v1, v2, dateTime);
            this.totalPagines =  (int)( Math.Ceiling((double)numeroActors) / itemsPerPagina);

            dtgActors.ItemsSource = ActorDB.getActors(v1,
                                            v2,
                                            dateTime, itemsPerPagina, numPagina);


        }

        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            this.numPagina = 0;
            actualitzaPaginacioDesDelFormulari();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (this.numPagina > 0)
            {
                this.numPagina--;
                actualitzaPaginacioDesDelFormulari();
            }
            
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if(this.numPagina<this.totalPagines-1)
            {
                this.numPagina++;
                actualitzaPaginacioDesDelFormulari();
            }            
        }

        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            this.numPagina = this.totalPagines - 1;
            actualitzaPaginacioDesDelFormulari();
        }

        private void dtgActors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Actor = new ActorViewModel((ActorDB)dtgActors.SelectedItem);
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            Actor = new ActorViewModel();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //fer validacions.....

            ActorDB aBD = new ActorDB(Actor.Actor_id, Actor.First_name, Actor.Last_name, Actor.Last_update.DateTime);
            aBD.Update();
        }
    }
}