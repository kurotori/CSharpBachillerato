using System;
using MySql.Data.MySqlClient;

namespace ConexionMySQL
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            BaseDeDatos bdd = new BaseDeDatos();
            MySqlConnection conexion = bdd.CrearConexion("192.168.4.200","mysql","alumno","");
            bdd.ProbarConexion(conexion);
            Console.ReadKey();

        }
    }
}
