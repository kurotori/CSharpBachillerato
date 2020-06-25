using System;

namespace JuegoDeCartas
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Baraja baraja = new Baraja();
            //baraja.Barajar();
            baraja.MostrarBaraja();
            baraja.Barajar();
            baraja.MostrarBaraja();
            Console.ReadKey();
        }
    }
}
