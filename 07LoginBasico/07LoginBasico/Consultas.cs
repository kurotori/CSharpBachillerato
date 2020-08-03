using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _07LoginBasico
{
    /// <summary>
    /// Esta clase contiene los métodos para trabajar con la base de datos.
    /// </summary>
    class Consultas
    {

        private BaseDedatos utilesBdd = new BaseDedatos();
        //Objeto con los métodos para acceder a la base de datos

        private UtilesXML utilesXML = new UtilesXML();
        //Objeto para leer los datos de configuración

        private readonly string archivoConfig = "configuracion.xml";
        //Archivo con los datos de configuración
        
        private string iPservidor = "";
        private string bdd = "";
        private string usuarioBD = "";
        private string contraseniaBD = "";
        //Variables para almacenar los datos de conexión con la base de datos

        /// <summary>
        /// Método constructor. En este caso lo usaremos para acceder a los datos almacenados
        /// en el archivo de configuración y pasarlo a los atributos correspondientes
        /// </summary>
        public Consultas()
        {
           

            this.iPservidor = utilesXML.LeerConfig(archivoConfig, "IPServidor");
            this.bdd = utilesXML.LeerConfig(archivoConfig, "BDD");
            this.usuarioBD = utilesXML.LeerConfig(archivoConfig, "UsuarioBD");
            this.contraseniaBD = utilesXML.LeerConfig(archivoConfig, "ContraseniaBD");
            //Leemos los datos de configuración para acceder a la base de datos
        }

        /// <summary>
        /// Registra los datos de un usuario en la base de datos y devuelve un string con
        /// el éxito o el error de la operación.
        /// </summary>
        /// <param name="usuarioCi">La CI del usuario</param>
        /// <param name="usuario">El nombre del usuario</param>
        /// <param name="hash">El hash de la contraseña del usuario</param>
        /// <returns>El resultado de la operación, ya sea éxito o un error</returns>
        public string RegistrarUsuario
            (string usuarioCi,string usuario,string hash, string sal)
        {
            string resultado = "";
            //En esta variable almacenaremos el resultado de la operación, ya sea éxito o error

            string consulta = "INSERT INTO "+bdd+".usuario(CI,nombre,sal,hash) " +
                              "VALUES(@usuarioCi, @usuario, @sal, @hash)";
            // Variable para almacenar la consulta que realizaremos
            
                    /* NOTA: Los datos que comienzan con '@', como '@usuarioCi', 
                     * son PARÁMETROS que completaremos luego de forma dinámica
                     */
            
            MySqlConnection conexion = utilesBdd.CrearConexion(iPservidor, bdd, usuarioBD, contraseniaBD);
            //Creamos una conexión para realizar la consulta

            try
            {
                conexion.Open();
                //Abrimos la conexión
                
                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //Creamos un comando con la consulta y la conexión.
                // Este objeto es el que EJECUTA la consulta

                comando.Parameters.AddWithValue("@usuarioCi", usuarioCi);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@sal", sal);
                comando.Parameters.AddWithValue("@hash", hash);
                //Agregamos de a uno los datos a los parámetros de la consulta 

                comando.ExecuteNonQuery();
                //Ejecutamos la consulta. Esta consulta no recupera datos (es un INSERT)
                // por lo tanto no hace falta un objeto lector, por lo que lo ejecutamos
                // como un 'NonQuery', o sea 'No es consulta con recuperación de datos'

                resultado = "Usuario " + usuario + " registrado con éxito";
                // Si todo sale bien, el resultado nos mostrará un mensaje de éxito
            }
            catch (Exception ex)
            {
                resultado = "Error: " + ex.Message;
                // Si algo salió mal, pasamos el mensaje de la excepción al resultado para
                // poder verlo en la ejecución
            }

            conexion.Close();
            //Cerramos la conexión

            return resultado;
            //Devolvemos el resultado con el éxito o el error
        }



        /// <summary>
        /// Permite recuperar los datos necesarios para realizar el login
        /// </summary>
        /// <param name="usuarioCi">La CI del usuario en cuestión</param>
        /// <returns>Un array de dos elementos: 
        /// 0 - La sal asignada al usuario durante la creación de su cuenta
        /// 1 - El hash de su contraseña</returns>
        public string[] ObtenerDatosLogin(string usuarioCi)
        {
            string[] resultado = new string[2];
            //Un array para almacenar el resultado

            string consulta = "SELECT sal, hash FROM " + bdd + ".usuario " +
                              "WHERE CI = @usuarioCi";
            //La consulta que ejecutaremos en la base de datos

            MySqlConnection conexion = utilesBdd.CrearConexion(iPservidor, bdd, usuarioBD, contraseniaBD);
            //Creamos una conexión para realizar la consulta

            try
            {
                conexion.Open();
                //Abrimos la conexión

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //Creamos un comando con la consulta y la conexión.
                // Este objeto es el que EJECUTA la consulta

                comando.Parameters.AddWithValue("@usuarioCi", usuarioCi);
                //Agregamos el dato al parámetro de la consulta

                MySqlDataReader lector = comando.ExecuteReader();
                //Creamos un objeto lector, para recibir los datos de la consulta

                if (lector.HasRows)
                //Chequeamos que el lector contenga algún registro
                {
                    while (lector.Read())
                    //Recorremos los registros del lector con un bucle WHILE y el método '.Read()'
                    //NOTA: En este caso, si el usuario existe, sólo deberíamos obtener UN REGISTRO
                    {
                        resultado[0] = lector.GetString(0);
                        resultado[1] = lector.GetString(1);
                        //Asignamos los datos de las columnas(0 y 1) del lector a nuestro array resultado
                    }
                }
                else
                //Si el lector NO TIENE registros entonces no existe un usuario registrado con esa CI ...
                {
                    resultado[0] = "Error: ";
                    resultado[1] = "Ese usuario no existe";
                    //... así que completamos el array resultado con el error correspondiente
                }
            }
            catch (Exception ex)
            {
                resultado[0] = "Error: ";
                resultado[1] = ex.Message;
                //Si hay una falla en la conexión, recuperamos la Excepción y 
                //completamos el array resultado con el error y su descripción
            }

            conexion.Close();
            //Cerramos la conexión

            return resultado;
            //Devolvemos el array resultado con los datos o el error que corresponda
        }

        /// <summary>
        /// Obtiene todos los datos del usuario
        /// </summary>
        /// <param name="usuarioCi"></param>
        /// <returns>Un array con los datos del usuario en el siguiente orden
        /// 0 - nombre
        /// 1 - sal
        /// 2 - hash
        /// 3 - fecha de registro
        /// </returns>
        public string[] ObtenerDatosDeUsuario(string usuarioCi)
        {
            string[] resultado = new string[4];
            //Un array para almacenar el resultado

            string consulta = "SELECT nombre, sal, hash, fecha_registro " +
                              "FROM " + bdd + ".usuario " +
                              "WHERE CI = @usuarioCi";
            //La consulta que ejecutaremos en la base de datos

            MySqlConnection conexion = utilesBdd.CrearConexion(iPservidor, bdd, usuarioBD, contraseniaBD);
            //Creamos una conexión para realizar la consulta

            try
            {
                conexion.Open();
                //Abrimos la conexión

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //Creamos un comando con la consulta y la conexión.
                // Este objeto es el que EJECUTA la consulta

                comando.Parameters.AddWithValue("@usuarioCi", usuarioCi);
                //Agregamos el dato al parámetro de la consulta

                MySqlDataReader lector = comando.ExecuteReader();
                //Creamos un objeto lector, para recibir los datos de la consulta

                if (lector.HasRows)
                //Chequeamos que el lector contenga algún registro
                {
                    while (lector.Read())
                    //Recorremos los registros del lector con un bucle WHILE y el método '.Read()'
                    //NOTA: En este caso, si el usuario existe, sólo deberíamos obtener UN REGISTRO
                    {
                        resultado[0] = lector.GetString(0);
                        resultado[1] = lector.GetString(1);
                        resultado[2] = lector.GetString(2);
                        resultado[3] = lector.GetString(3);
                        //Asignamos los datos de las columnas del lector a nuestro array resultado
                    }
                }
                else
                //Si el lector NO TIENE registros entonces no existe un usuario registrado con esa CI ...
                {
                    resultado[0] = "Error: ";
                    resultado[1] = "Ese usuario no existe";
                    resultado[2] = "";
                    resultado[3] = "";
                    //... así que completamos el array resultado con el error correspondiente
                }
            }
            catch (Exception ex)
            {
                resultado[0] = "Error: ";
                resultado[1] = ex.Message;
                resultado[2] = "";
                resultado[3] = "";
                //Si hay una falla en la conexión, recuperamos la Excepción y 
                //completamos el array resultado con el error y su descripción
            }

            conexion.Close();
            //Cerramos la conexión

            return resultado;
            //Devolvemos el array resultado con los datos o el error que corresponda
        }



        public Sesion CrearSesion(string usuarioCi, string hash)
        {
            Sesion nuevaSesion = null;

            string consulta = "CALL iniciar_sesion(@usuarioCi, @hash)";

            MySqlConnection conexion = utilesBdd.CrearConexion(iPservidor, bdd, usuarioBD, contraseniaBD);

            try
            {
                conexion.Open();
                //Abrimos la conexión

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //Creamos un comando con la consulta y la conexión.
                // Este objeto es el que EJECUTA la consulta

                comando.Parameters.AddWithValue("@usuarioCi", usuarioCi);
                comando.Parameters.AddWithValue("@hash", hash);
                //Agregamos los datos a los parámetros de la consulta

                MySqlDataReader lector = comando.ExecuteReader();
                //Creamos un objeto lector, para recibir los datos de la consulta

                if (lector.HasRows)
                //Chequeamos que el lector contenga algún registro
                {
                    while (lector.Read())
                    //Recorremos los registros del lector con un bucle WHILE y el método '.Read()'
                    {
                        int idSesion = lector.GetInt16(0);
                        nuevaSesion = new Sesion(idSesion);
                        //Asignamos los datos de las columnas del lector para crear la sesión
                    }
                }
                else
                {
                    nuevaSesion = new Sesion(0);
                    nuevaSesion.Estado = "Error: No se pudo crear una sesión en el servidor";
                }
            }
            catch (Exception ex)
            {
                nuevaSesion = new Sesion(0);
                nuevaSesion.Estado = "Error: "+ex.Message;

            }

            conexion.Close();

            return nuevaSesion;
        }


        public string CerrarSesion(string usuarioCi, int sesionId)
        {
            string resultado = "";

            string consulta = "UPDATE " + bdd + ".sesion INNER JOIN " +bdd+ ".inicia "+
                              "SET sesion.estado = 'cerrada' WHERE " +
                              "sesion.ID = inicia.sesion_ID AND " +
                              "inicia.usuario_CI = @usuarioCi AND " +
                              "sesion.ID = @sesionId";

            MySqlConnection conexion = 
                utilesBdd.CrearConexion(iPservidor, bdd, usuarioBD, contraseniaBD);

            try
            {
                conexion.Open();
                //Abrimos la conexión

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                //Creamos un comando con la consulta y la conexión.
                // Este objeto es el que EJECUTA la consulta

                comando.Parameters.AddWithValue("@usuarioCi", usuarioCi);
                comando.Parameters.AddWithValue("@sesionId", sesionId);
                //Agregamos los datos a los parámetros de la consulta

                comando.ExecuteNonQuery();

                resultado = "La sesión " + sesionId + " se cerró correctamente";

            }
            catch (Exception ex)
            {
                resultado = "Error: " + ex.Message;
            }

            conexion.Close();

            return resultado;
        }

    }
}
