﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06JuegoDeCartasVB.Cartas

{
    class Baraja
    {
        Herramientas herramientas = new Herramientas();

        //public Carta[] baraja = new Carta[50];
        public List<Carta> baraja = new List<Carta>();


        private string[] palos = { "oro", "espada", "copa", "basto" };

        /// <summary>
        /// Método constructor de la baraja.
        /// Crea una nueva instancia de la baraja
        /// </summary>
        public Baraja()
        {
            int posicion = 0;

            while (posicion < 50)
            {
                Carta nuevaCarta = null;

                if (posicion < 48)
                {
                    foreach (var palo in palos)
                    {
                        for (int num = 1; num < 13; num++)
                        {
                            nuevaCarta = new Carta(num, palo);
                            baraja.Add(nuevaCarta);
                            posicion++;
                        }
                    }
                }
                else
                {
                    break;
                    nuevaCarta = new Carta(0, "comodin");
                    baraja.Add(nuevaCarta);
                    posicion++;
                }

            }

        }

        /// <summary>
        /// Muestra en la consola cada carta de la baraja
        /// </summary>
        public void MostrarBaraja()
        {
            Console.WriteLine("\nCartas:");
            foreach (var carta in baraja)
            {
                string dato = carta.GetNumero().ToString() + " - " + carta.GetPalo();
                Console.WriteLine(dato);

            }
        }

        /// <summary>
        /// Método para barajar la baraja
        /// </summary>
        public void Barajar_nuevo()
        {
            for (int c = 0; c < baraja.Count; c++)
            {
                Carta barajada = null;

                int numCarta2 = herramientas.AlAzarEntre(0, baraja.Count);

                barajada = baraja[c];
                baraja[c] = baraja[numCarta2];
                baraja[numCarta2] = barajada;
            }

        }

        /// <summary>
        /// Método para barajar la baraja. (Obsoleto, usar Barajar_nuevo)
        /// </summary>
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
