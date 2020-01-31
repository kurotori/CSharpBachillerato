using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Funciones
    {
        public int AlAzar(int minimo, int maximo)
        {
            //var resultado = 0; --> alternativa
            int resultado = 0;
            Random azar = new Random();
            resultado = azar.Next(minimo, maximo);
            return resultado;
        }
    }
}
