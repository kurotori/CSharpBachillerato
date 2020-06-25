using System;
namespace JuegoDeCartas
{
    public class Baraja
    {
        private Herramientas herramientas = new Herramientas();

        public Carta[] baraja = new Carta[50];
        private string[] palos = { "Oro", "Espada", "Copa", "Basto" };

        public Baraja()
        {
           int posicion = 0;

           while(posicion < 50) {
               Carta nuevaCarta = null;

               if(posicion < 48)
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

        public void MostrarBaraja(){
            Console.WriteLine("Cartas:");
            foreach (var carta in baraja)
            {
                string dato = carta.GetNumero().ToString()+" - "+carta.GetPalo();
                Console.WriteLine(dato);
            }
        }

        public void Barajar(){

            Carta temp = null;

            int pase = 0;

            Console.WriteLine("Barajando...");
            while (pase < 150)
            {
                int carta1 = herramientas.AlAzarEntre(0, 49);
                int carta2 = herramientas.AlAzarEntre(0, 49);
                temp = baraja[carta1];
                baraja[carta1] = baraja[carta2];
                baraja[carta2] = temp;
                pase++;
            }

            Console.WriteLine("Listo");
        }
    }
}
