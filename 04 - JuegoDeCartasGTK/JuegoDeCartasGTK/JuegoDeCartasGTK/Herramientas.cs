using System;
namespace JuegoDeCartasGTK
{
    public class Herramientas
    {
        public Herramientas()
        {
        }

        private readonly Random azar = new Random();

        public int AlAzarEntre(int min, int max)
        {
            int num = azar.Next(min, max);
            return num;
        }
    }
}
