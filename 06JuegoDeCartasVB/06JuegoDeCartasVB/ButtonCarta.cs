using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using _06JuegoDeCartasVB.Cartas;

namespace _06JuegoDeCartasVB
{
    class ButtonCarta:Button
    {
        private Carta carta = null;
        private string posicion = "";
             
        /// <summary>
        /// Método constructor para cartas en el tablero. Representa la carta puesta
        /// de revés sobre la mesa.
        /// </summary>
        /// <param name="carta">La carta representada</param>
        /// <param name="posicion">La posición de la carta en el tablero de juego.
        /// Debe estar formado por un letra para el palo de la carta
        /// y un número para el número de la carta
        /// </param>
        public ButtonCarta(Carta carta, string posicion)
        {
            this.Carta = carta;
            this.Posicion = posicion;

            Image im = Image.FromFile("imagen\\baraja\\reves.png");

            this.BackgroundImage = im;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }


        /// <summary>
        /// Método constructor para mostrar una posición de carta vacía
        /// </summary>
        public ButtonCarta()
        {
            Image im = Image.FromFile("imagen\\baraja\\vacia.png");

            this.BackgroundImage = im;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }


        public Carta Carta { 
            get => carta; 
            set => carta = value; 
        }


        public string Posicion { 
            get => posicion; 
            set => posicion = value; 
        }


        /// <summary>
        /// Establece el dato de la posición del botón en el tablero según el palo y el
        /// número de la carta que iría en esa posición.
        /// </summary>
        /// <param name="palo">El palo de la carta que corresponde a esa posición en el tablero</param>
        /// <param name="numero">El número de la carta que corresponde a esa posición en el tablero</param>
        public void SetPosicion(char palo, int numero)
        {
            this.Posicion = palo + numero.ToString();
        }


        /// <summary>
        /// Devuelve el dato de la posición del botón en el tablero
        /// </summary>
        /// <returns>Un string con el dato de posición del botón en el tablero</returns>
        public string GetPosicion()
        {
            return this.Posicion;
        }

        
        /// <summary>
        /// Permite establecer el atributo Carta de este botón
        /// </summary>
        /// <param name="carta">La Carta que este botón representa</param>
        public void SetCarta(Carta carta)
        {
            this.Carta = carta;
        }


        /// <summary>
        /// Permite obtener la Carta que este botón representa
        /// </summary>
        /// <returns>Un objeto de tipo Carta que representa la carta representada por el botón</returns>
        public Carta GetCarta()
        {
            return this.Carta;
        }


        public void DefinirImagen(Image imagen)
        {
            this.BackgroundImage = imagen;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }


        public void RevesRojo()
        {
            Image im = Image.FromFile("imagen\\baraja\\revesR.png");

            this.BackgroundImage = im;
        }
    }
}
