using System;
using MySql.Data.MySqlClient;

namespace ConexionMySQL
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            BaseDeDatos bdd = new BaseDeDatos();
            MySqlConnection conexion = bdd.CrearConexion("ip_servidor","base_de_datos","usuarioBD","contraseñaBD");
            bdd.ProbarConexion(conexion);

            string datosBD = bdd.ConsultaGenerica1Columna("show schemas",conexion);
            Console.WriteLine(datosBD);
            Console.ReadKey();

            

        }
    }
}
