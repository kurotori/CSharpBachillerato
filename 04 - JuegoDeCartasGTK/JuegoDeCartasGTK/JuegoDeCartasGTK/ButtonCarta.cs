using System;
using Gtk;
using JuegoDeCartasGTK.Baraja;

namespace JuegoDeCartasGTK
{
    public class ButtonCarta:Button
    {
        private Carta carta = null;

        public ButtonCarta(Carta carta)
        {
            this.carta = carta;
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
