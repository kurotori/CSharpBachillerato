using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _07LoginBasico
{
    class Herramientas
    {

        private readonly Random azar = new Random();

        public int AlAzarEntre(int min, int max)
        {
            int num = azar.Next(min, max);
            return num;
        }


        /// <summary>
        /// Crea una secuencia pseudo-aleatoria de caracteres para el hasheo de la contraseña
        /// </summary>
        /// <returns>String de 100 caracteres seleccionados al azar.</returns>
        public string CrearSal()
        {
            string sal = "";
            //Variable para almacenar la sal resultante

            string baseSal = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+=][}{<>";
            //Variable con la base para la sal: el alfabeto, los números y caracteres varios

            for (int i = 0; i < 100; i++)
            //Generaremos una sal de 100 caracteres
            {
                int caracter = AlAzarEntre(0, baseSal.Length);
                //Generamos un número al azar del número de caracteres de la baseSal

                sal += baseSal[caracter];
                //Agregamos a la sal el caracter correspondiente al número seleccionado
            }

            return sal;
            //Devolvemos la secuencia de caracteres obtenida
        }



        /// <summary>
        /// Crea un hash (una secuencia encriptada) de una contrasenia usando una sal 
        /// para su almacenamiento en la base de datos.
        /// </summary>
        /// <param name="contrasenia">La contrasenia a ser hasheada</param>
        /// <param name="sal">Secuencia aleatoria para la encriptación</param>
        /// <returns>El hash encriptado de la contraseña usando la sal proporcionada</returns>
        public string HashearContrasenia(string contrasenia, string sal)
        {
            string hash = "";

            Byte[] datos = Encoding.UTF8.GetBytes(contrasenia + sal);
            //Convertimos la contrasenia y la sal en una secuencia de bytes

            HashAlgorithm tipoDeHash = new SHA512Managed();
            //Inicializamos el objeto de encriptación

            Byte[] datosEncriptados = tipoDeHash.ComputeHash(datos);
            //Encriptamos los datos

            hash = Convert.ToBase64String(datosEncriptados);
            //Volvemos a pasar los datos encriptados a una secuencia de caracteres

            return hash;
            //Devolvemos el hash obtenido
        }
    }
}
