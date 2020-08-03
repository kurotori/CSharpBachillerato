using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07LoginBasico
{
    public class Sesion
    {
        private int id = 0;
        private string estado = "";

        public Sesion(int id)
        {
            if (id > 0)
            {
                this.ID = id;
                this.Estado = "abierta";
            }
            else
            {
                this.ID = 0;
                this.Estado = "Error: No se pudo iniciar sesión en el servidor";
            }
        }

        /// <summary>
        /// Establece u Obtiene el valor de la ID de la sesión
        /// </summary>
        public int ID {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// Establece u Obtiene el valor del estado de la sesión
        /// </summary>
        public string Estado {
            get => estado;
            set => estado = value;
        }
    }
}
