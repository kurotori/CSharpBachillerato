using System;
using MySql.Data.MySqlClient;

namespace ConexionMySQL
{
    public class BaseDeDatos
    {
        
        public BaseDeDatos()
        {
        }

        // El texto a continuación es un comentario descriptivo, por eso esta precedido
        // con tres barras '///'. Al colocarlas, la IDE agrega el resto automáticamente
        /// <summary>
        /// Permite crear una conexión al servidor para usarla en una consulta
        /// </summary>
        /// <param name="servidor">El IP o URL del servidor</param>
        /// <param name="bdd">La base de datos que se quiere utilizar</param>
        /// <param name="usuario">El nombre de usuario necesario para la conexión</param>
        /// <param name="passwd">La contraseña necesaria para la conexión</param>
        /// <returns></returns>
        public MySqlConnection CrearConexion(string servidor,
                                             string bdd,
                                             string usuario,
                                             string passwd)
        {
            MySqlConnection conexion;
            string datosConexion = "server=" + servidor + ";" +
                                   "database=" + bdd + ";" +
                                   "uid=" + usuario + ";" +
                                   "pwd=" + passwd + ";";

            conexion = new MySqlConnection(datosConexion);
            return conexion;
        }


        /// <summary>
        /// Realiza una prueba sencilla de la conexión, mostrando el resultado en la consola,
        /// ya sea éxito o error.
        /// </summary>
        /// <param name="conexion">Un objeto MySqlConnection de conexión proporcionado por 
        /// el método CrearConexión</param>
        public void ProbarConexion(MySqlConnection conexion)
        {
            try
            {
                conexion.Open();
                Console.WriteLine("Conexión Exitosa");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            conexion.Close();
            //Cerramos la conexión
        }



        /// <summary>
        /// Realiza una consulta SELECT o SHOW y devuelve su resultado, o un error, en
        /// un string
        /// </summary>
        /// <param name="consulta">La consulta SELECT o SHOW que se quiere realizar</param>
        /// <param name="conexion">Un objeto MySqlConnection de conexión proporcionado por 
        /// el método CrearConexión</param>
        /// <returns>El resultado de la consulta o un error</returns>
        public string ConsultaGenerica1Columna(string consulta, MySqlConnection conexion)
        {
            string resultado = "";
            // Inicializamos el string resultado

            try
            {
                conexion.Open();
                //1 - Se abre la conexión

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //2 - Se genera un objeto comando, que contendrá nuestra consulta a la BdD
                //  este objeto requiere la consulta y la conexión abierta.

                MySqlDataReader lectorResultado = comando.ExecuteReader();
                //3 - Se crea un objeto lector mediante el método ExecuteReader del comando
                //  este lector solo es necesario para consultas que devuelven información
                //  como ser SELECT o SHOW. Para otras consultas como INSERT, DELETE o UPDATE
                //  usaremos el método ExecuteNonQuery

                if (lectorResultado.HasRows) //4 - Chequeamos si el lector tiene algún registro
                {
                    while (lectorResultado.Read()) //5 - Avanzamos por los registros del lector de a uno con un bucle WHILE
                    {
                        resultado = resultado + lectorResultado.GetString(0);
                        //6 - Agregamos la primera columna de cada registro al resultado con el método GetString
                        //  el número 0 indica que queremos la primera columna, si fuera 1 sería la segunda, y así sucesivamente.

                        resultado = resultado + "\n";
                        //7 - Agregamos un '\n', un salto de línea, para que los registros se muestren
                        // cada uno en una línea diferente
                    }
                }
                else //8 - Si no hay ningún registro en el lector, agregamos un mensaje de error al resultado
                {
                    resultado = "No hay resultados para mostrar";
                }

            }
            catch (Exception ex) //9 - Si hay un error en la conexión, lo recuperamos y lo mostramos
            {
                resultado = "ERROR: " + ex.Message;
            }

            conexion.Close();
            //10 - Cerramos la conexión

            return resultado;
            //11 - Entregamos la variable resultado
        }

    }
}
