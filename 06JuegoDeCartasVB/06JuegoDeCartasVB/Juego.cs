using _06JuegoDeCartasVB.Cartas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06JuegoDeCartasVB
{
    public class Juego
    {
        private List<char> letrasPalo = new List<char>(
            new char[] { 'o', 'e', 'c', 'b' }
            );

        public Juego()
        {
            //Array con las letras iniciales de los palos para identificar 
            // las posiciones de las cartas en el tablero
        }

        public bool ChequearCarta(Carta carta)
        {
            bool resultado = false;

            int numero = carta.GetNumero();
            if (numero != 12)
            {
                resultado = true;
            }

            return resultado;
        }


        public void UbicarCarta(Carta carta, TableLayoutPanel tablero)
        {
            char palo = carta.GetPalo()[0];
           
            int fila = letrasPalo.FindIndex(item => item.Equals(palo));
            int columna = carta.GetNumero() - 1;

            Console.WriteLine("Palo es fila " + fila + " y columna " + columna);

            ButtonCarta boton = (ButtonCarta)tablero.GetControlFromPosition(columna, fila);
            boton.Enabled = true;
            boton.RevesRojo();

        }

        

    }
}
