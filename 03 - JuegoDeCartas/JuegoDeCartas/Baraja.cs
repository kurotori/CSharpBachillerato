using System;
using System.Collections.Generic;

namespace JuegoDeCartas
{
    public class Baraja
    {
        Herramientas herramientas = new Herramientas();

        public Carta[] baraja = new Carta[50];

        private string[] palos = { "Oro", "Espada", "Copa", "Basto" };

        /*
         * Método constructor de la baraja      
         */       
        public Baraja()
        {
            int posicion = 0;

            while (posicion < 50) {
                Carta nuevaCarta = null;

                if (posicion < 48)
                {
                    foreach (var palo in palos)
                    {
                        for (int num = 1; num < 13; num++)
                        {
                            nuevaCarta = new Carta(num, palo);
                            baraja[posicion] = nuevaCarta;
                            posicion++;
                        }
                    }
                }
                else
                {
                    nuevaCarta = new Carta(0, "Comodín");
                    baraja[posicion] = nuevaCarta;
                    posicion++;
                }
            }

        }

        /*
         * Muestra cada carta de la baraja
         */
        public void MostrarBaraja() {
            Console.WriteLine("\nCartas:");
            foreach (var carta in baraja)
            {
                string dato = carta.GetNumero().ToString() + " - " + carta.GetPalo();
                Console.WriteLine(dato);

            }
        }

        public void Barajar_nuevo()
        {
            for (int c = 0; c < 50; c++)
            {
                Carta barajada = null;

                int numCarta2 = herramientas.AlAzarEntre(0, 49);

                barajada = baraja[c];
                baraja[c] = baraja[numCarta2];
                baraja[numCarta2] = barajada;
            }

        }


        public void Barajar_viejo()
        {
            for (int c = 0; c < 1500; c++)
            {
                Carta barajada = null;
                int numCarta1 = herramientas.AlAzarEntre(0, 49);
                int numCarta2 = herramientas.AlAzarEntre(0, 49);
                barajada = baraja[numCarta1];
                baraja[numCarta1] = baraja[numCarta2];
                baraja[numCarta2] = barajada;
            }
        }


    }
}
