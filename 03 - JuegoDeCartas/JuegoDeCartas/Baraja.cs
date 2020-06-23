using System;
namespace JuegoDeCartas
{
    public class Baraja
    {
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
            foreach (var carta in baraja)
            {
                string dato = carta.getNumero().ToString()+" - "+carta.getPalo();
                Console.WriteLine(dato);
            }
        }

        public void Barajar(){

        }
    }
}
