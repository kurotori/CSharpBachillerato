using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07LoginBasico
{
    public partial class Principal : Form
    {
        private Usuario usuario = null;
        //Objeto para contener los datos del usuario

        private Sesion sesion = null;
        //Objeto para contener la información de la sesión

        private IniciarSesion ventanaAnterior = null;
        //Objeto para contener los datos de la ventana anterior

        public Principal(Sesion sesion, Usuario usuario, IniciarSesion ventana)
        {
            InitializeComponent();

            this.sesion = sesion;
            this.usuario = usuario;
            this.ventanaAnterior = ventana;

            stlbl_numSesion.Text = "Sesión: " + sesion.ID;
            lbl_nomUsuario.Text = usuario.Nombre;
        }


        /// <summary>
        /// Método para el elemento 'Cerrar Sesión' del menú 'Sesión'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mensaje = "Va a cerrar su sesión. ¿Desea hacerlo?";
            string detalle = "Cerrar Sesión";
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            DialogResult respuesta;
            //Preparamos los elementos para un dialogo de confirmación

            respuesta = MessageBox.Show(mensaje,detalle,botones);
            //Mostramos el diálogo de confirmación

            if (respuesta == System.Windows.Forms.DialogResult.Yes)
                //Chequeamos si el usuario dio click en 'Si'
            {
                string resultado = usuario.CerrarSesion(sesion);
                MessageBox.Show(resultado);
                ventanaAnterior.Show();
                this.Close();
                this.Dispose();
            }
            
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login Básico v2.0 \n por Sebastián De los Ángeles");
        }
    }
}
