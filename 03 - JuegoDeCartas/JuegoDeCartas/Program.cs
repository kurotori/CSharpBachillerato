using System;

namespace JuegoDeCartas
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Baraja baraja = new Baraja();
            baraja.MostrarBaraja();
            Console.ReadKey();
        }
    }
}
