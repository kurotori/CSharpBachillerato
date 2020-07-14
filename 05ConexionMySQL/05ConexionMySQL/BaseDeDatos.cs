using System;
using MySql.Data.MySqlClient;

namespace ConexionMySQL
{
    public class BaseDeDatos
    {
        public BaseDeDatos()
        {
        }

        /***
         * Crea una nueva conexión a una base de datos     
         */      
        public MySqlConnection CrearConexion(string servidor,
                                             string bdd,
                                             string usuario,
                                             string passwd)
        {
            MySqlConnection conexion;
            string datosConexion = "server=" + servidor + ";"+
                                   "database=" + bdd + ";"+
                                   "uid=" + usuario + ";"+
                                   "pwd=" + passwd + ";";

            conexion = new MySqlConnection(datosConexion);
            return conexion;
        }



        public void ProbarConexion(MySqlConnection conexion)
        {
            try
            {
                conexion.Open();
                Console.WriteLine("Conexión Exitosa");
                conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }

    }
}
