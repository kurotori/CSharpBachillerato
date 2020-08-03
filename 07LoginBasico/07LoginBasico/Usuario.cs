using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07LoginBasico
{
    public class Usuario
    {
        private string ciUsuario = "";
        private string nombre = "";
        private string sal = "";
        private string hashContrasenia = "";
        private string fecha_registro = "";

        private Herramientas herramientas = new Herramientas();

        private Consultas consultas = new Consultas();

        /// <summary>
        /// Crea una instancia del usuario para iniciar el proceso de login
        /// </summary>
        /// <param name="ciUsuario"></param>
        public Usuario(string ciUsuario)
        {
            this.CiUsuario = ciUsuario;
        }


        /// <summary>
        /// Crea una instancia del usuario para su registro en la base de datos
        /// </summary>
        /// <param name="ciUsuario">La CI del usuario</param>
        /// <param name="nombre">El nombre del usuario</param>
        /// <param name="contrasenia">La contraseña del usuario</param>
        public Usuario(string ciUsuario, string nombre, string contrasenia)
        {
            this.CiUsuario = ciUsuario;
            this.Nombre = nombre;
            this.Sal = herramientas.CrearSal();
            this.HashContrasenia = herramientas.HashearContrasenia(contrasenia, Sal);
            
        }

        /// <summary>
        /// Establece u Obtiene el valor de la CI del usuario
        /// </summary>
        public string CiUsuario {
            get => ciUsuario;
            set => ciUsuario = value;
        }

        /// <summary>
        /// Establece u Obtiene el valor del nombre del usuario
        /// </summary>
        public string Nombre {
            get => nombre;
            set => nombre = value;
        }

        /// <summary>
        /// Establece u Obtiene el valor de la sal asignada al usuario
        /// </summary>
        public string Sal {
            get => sal;
            set => sal = value;
        }

        /// <summary>
        /// Establece u Obtiene el valor del hash de la contraseña del usuario
        /// </summary>
        public string HashContrasenia {
            get => hashContrasenia;
            set => hashContrasenia = value;
        }

        /// <summary>
        /// Establece u Obtiene el valor de la fecha de registro del usuario
        /// </summary>
        public string Fecha_registro {
            get => fecha_registro;
            set => fecha_registro = value;
        }
        



        /// <summary>
        /// Obtiene los datos necesarios para efectuar el login
        /// </summary>
        public void ObtenerDatosLogin()
        {
            string[] datos = consultas.ObtenerDatosLogin(ciUsuario);

            this.sal = datos[0];
            this.HashContrasenia = datos[1];

        }

        /// <summary>
        /// Obtiene los datos completos del usuario de la base de datos
        /// </summary>
        public void ObtenerDatosDeUsuario()
        {
            string[] datos = consultas.ObtenerDatosDeUsuario(ciUsuario);

            if (datos[0].StartsWith("Error"))
            {
                Console.WriteLine(datos[0] + datos[1]);
            }
            else
            {
                this.Nombre = datos[0];
                this.Sal = datos[1];
                this.HashContrasenia = datos[2];
                this.Fecha_registro = datos[3];
            }

        }

        /// <summary>
        /// Establece el valor del hash de la contraseña del usuario usando la sal asignada
        /// al mismo
        /// </summary>
        /// <param name="contrasenia">La contraseña del usuario</param>
        public void SetHashContrasenia(string contrasenia)
        {
            this.HashContrasenia = herramientas.HashearContrasenia(contrasenia, sal);
        }

        /// <summary>
        /// Registra los datos del usuario en la base de datos
        /// </summary>
        /// <returns>El éxito de la operación o un error</returns>
        public string Registrarse()
        {
            string resultado = "";

            resultado = consultas.RegistrarUsuario(CiUsuario, Nombre, HashContrasenia, Sal);

            return resultado;
        }



        /// <summary>
        /// Ejcuta el proceso de inicio de sesión de un usuario, comprobando sus 
        /// credenciales contra las provistas por la base de datos. Si el login
        /// es exitoso, se retorna un array con la ID de sesión y un hash identificatorio
        /// de la misma. De lo contrario se devuelve un error.
        /// </summary>
        /// <param name="contrasenia">La contraseña</param>
        /// <returns>Una sesión iniciada o un error</returns>
        public Sesion IniciarSesion(string contrasenia)
        {
            Sesion nuevaSesion = null;
            //Objeto para la nueva sesión

            string[] datosLogin = consultas.ObtenerDatosLogin(CiUsuario);
            /*Declaramos un array para los datos de login del usuario 
             * y los obtenemos de la base de datos 
             */

            if (datosLogin[0].StartsWith("Error"))
            //Comprobamos si hubo o no un error al obtener los datos del usuario
            {
                nuevaSesion = new Sesion(0);
                nuevaSesion.Estado = datosLogin[0] + datosLogin[1];
                /*Si hubo un error, la sesión se crea con identificador 0
                 * y los detalles del error se guardan en su atributo de estado
                 */ 
            }
            else
            {
                string sal = datosLogin[0];
                string hashContraseniaOriginal = datosLogin[1];
                //Si no hay error, pasamos los datos de login a variables

                string hashContraseniaIngresada = 
                    herramientas.HashearContrasenia(contrasenia, sal);
                //Hasheamos la contrseña ingresada con la sal que obtuvimos de la base de datos

                if (hashContraseniaIngresada.Equals(hashContraseniaOriginal))
                //Chequeamos que el hash de la contraseña ingresada y el hash original coincidan
                {
                    nuevaSesion = consultas.CrearSesion(ciUsuario, hashContraseniaIngresada);
                    ObtenerDatosDeUsuario();
                    /*Si coinciden, creamos una nueva sesión con esos datos
                     * y obtenemos el resto de los datos del usuario
                     */ 

                }
                else
                {
                    nuevaSesion = new Sesion(0);
                    nuevaSesion.Estado = "Error: Contraseña Incorrecta";
                    /*Si los hasheos no coinciden, la sesión se crea con identificador 0
                    * y los detalles del error se guardan en su atributo de estado
                    */
                }
            }

            return nuevaSesion;
            //Devolvemos el objeto con los datos de la sesión
        }



        public string CerrarSesion(Sesion sesion)
        {
            string resultado = "";

            int sesionId = sesion.ID;

            resultado = consultas.CerrarSesion(this.CiUsuario, sesionId);

            return resultado;
        }
    }
}



