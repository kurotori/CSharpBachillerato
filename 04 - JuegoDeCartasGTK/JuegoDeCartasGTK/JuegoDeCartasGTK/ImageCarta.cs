using System;
using Gtk;
using JuegoDeCartasGTK.Baraja;

namespace JuegoDeCartasGTK
{
    public class ImageCarta:Image
    {
        private Carta carta = null;

        public ImageCarta()
        {
        }

        public void SetCarta(Carta carta)
        {
            this.carta = carta;
        }

        public Carta GetCarta()
        {
            return this.carta;
        }


    }
}
