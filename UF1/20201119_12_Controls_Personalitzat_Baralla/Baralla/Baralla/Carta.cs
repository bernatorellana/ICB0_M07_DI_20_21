using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace Baralla
{
    public class Carta
    {
        private EnumNumeracio numero;
        private EnumPal pal;
        private char caracter;
        private int[][] distribucio;
        private Boolean estaGirada;
        private BitmapImage imatge;
        private BitmapImage backFace;

        public EnumNumeracio Numero { get => numero; set => numero = value; }
        public EnumPal Pal { get => pal; set => pal = value; }
        public char Caracter { get => caracter; set => caracter = value; }
        public int[][] Distribucio { get => distribucio; set => distribucio = value; }
        public BitmapImage Imatge { get => imatge; set => imatge = value; }
        public BitmapImage BackFace { get => backFace; set => backFace = value; }
        public bool EstaGirada { get => estaGirada; set => estaGirada = value; }
    }
}