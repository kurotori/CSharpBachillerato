using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06JuegoDeCartasVB.Cartas

{
    class Carta
    {
        private int numero = 0;
        private string palo = "";

        public Carta(int numero, string palo)
        {
            this.numero = numero;
            this.palo = palo;
        }

        public int GetNumero()
        {
            return numero;
        }

        public string GetPalo()
        {
            return palo;
        }

        public string GetInfoImagen()
        {
            return "imagen\\baraja\\" + palo + numero + ".png";
        }
    }
}
