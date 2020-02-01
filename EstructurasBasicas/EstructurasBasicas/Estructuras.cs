using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasBasicas
{
    class Estructuras
    {
        // Declaración de variables:
        // acceso tipo nombre = valorInicial;

        // Modificadores de Acceso: 
        // ver detalle en https://drive.google.com/open?id=1VOyTfXt8WOilM8cUi8BOABQXLPdOIAZ3dZxGCKHmnBA
        
        public int variableI1 = 0;
        private int variableI2 = 0;

        //Se pueden declarar variables sin indicar modificador de acceso
        //Quedan con modificador 'internal'
        double variableF = 0.1;
        string variableS = "hola";
        char variableC = 'a';
        bool variableB = false;

        // Tipos:
        //Ver detalle en: https://drive.google.com/open?id=1O09NLZlfubztLA9R3Mg-KwyZRFz_D-YdHTSavUUjaXE

        //Declaración de métodos ó funciones
        // acceso tipoDelResultado nombre(tipo datoEntrada1, tipo datoEntrada2)
        //  {   ... 
        //      return variableResultado;
        //  }
        //
        // Si el tipo de la función/método es 'void', se trata de un método
        // que no devuelve un objeto resultado.

        public void ejemplo(int algo)
        {
            if(algo == 0)
            {
                //...
            }
            else
            {
                //...
            }

            // - - - - - - 

            while(algo == 0)
            {
                //...
            }

            // - - - - - - 

            for (int i = 0; i < 5; i++)
            {
                //...
            }

            // - - - - - -

        }

    }
}
