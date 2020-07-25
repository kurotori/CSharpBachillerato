using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06JuegoDeCartasVB.Cartas;

namespace _06JuegoDeCartasVB
{
    class ButtonCarta:Button
    {
        private Carta carta = null;
        private string posicion = "";

        /// <summary>
        /// Establece el dato de la posición del botón en el tablero según el palo y el
        /// número de la carta que iría en esa posición.
        /// </summary>
        /// <param name="palo">El palo de la carta que corresponde a esa posición en el tablero</param>
        /// <param name="numero">El número de la carta que corresponde a esa posición en el tablero</param>
        public void SetPosicion(char palo, int numero)
        {
            this.posicion = palo + numero.ToString();
        }


        /// <summary>
        /// Devuelve el dato de la posición del botón en el tablero
        /// </summary>
        /// <returns>Un string con el dato de posición del botón en el tablero</returns>
        public string GetPosicion()
        {
            return this.posicion;
        }

        
        /// <summary>
        /// Permite establecer el atributo Carta de este botón
        /// </summary>
        /// <param name="carta">La Carta que este botón representa</param>
        public void SetCarta(Carta carta)
        {
            this.carta = carta;
        }


        /// <summary>
        /// Permite obtener la Carta que este botón representa
        /// </summary>
        /// <returns>Un objeto de tipo Carta que representa la carta representada por el botón</returns>
        public Carta GetCarta()
        {
            return this.carta;
        }
    }
}
