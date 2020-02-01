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

        //Listas:
        // acceso tipo[] nombreDeLista = new tipo[x];  -->'x' es un entero que indica
        //                                                 la longitud de la lista
        string[] nombres = new string[5];

        //Método alternativo para declarar listas:
        //
        string[] apellidos; // 1 - Se declara la lista, pero NO se la inicializa

        public void alternativo()
        {                   //NOTA: La asignación de valores o características
                            // de forma POSTERIOR a la declaración
                            // DEBE realizarse dentro de una función.

            apellidos = new string[5]; // 2 - Inicializo la lista mediante el
                                       // operador 'new'
        }




        //Declaración de métodos ó funciones
        //
        // acceso tipoDelResultado nombre(tipo datoEntrada1, tipo datoEntrada2)
        //  {   ... 
        //      return variableResultado;
        //  }
        //
        // Si el tipo de la función/método es 'void', se trata de un método
        // que no devuelve un objeto resultado.
        // Más información: https://drive.google.com/open?id=1RYrzYY_tVnKDAjKd5oCr_qfs8GOn-_zOUNrUlovGztc

        public void ejemplo(int algo)
        {
            if (algo == 0)
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
