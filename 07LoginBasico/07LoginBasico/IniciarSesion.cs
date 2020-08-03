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
    public partial class IniciarSesion : Form
    {
        private string ipServidor = "";
        private string bdd = "";
        private string usuarioBdd = "";
        private string contraseñaBdd = "";

        private UtilesXML utiles = new UtilesXML();
        public IniciarSesion()
        {
            InitializeComponent();
            
        }

        



        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogoConfig dc = new DialogoConfig();
            dc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CrearUsuario crear = new CrearUsuario();
            crear.ShowDialog();
            
        }

        private void btn_Entrar_Click(object sender, EventArgs e)
        {
            string usuarioCi = txt_usuarioCi.Text;
            string contrasenia = txt_contrasenia.Text;
            //Obtenemos los datos de los campos de texto

            txt_contrasenia.Text = "";

            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;
            //Cambiamos el cursor al 'reloj de espera'
            // y deshabilitamos la ventana

            Usuario usuario = new Usuario(usuarioCi);
            Sesion nuevaSesion = usuario.IniciarSesion(contrasenia);
            //Creamos un objeto usuario para iniciar la sesión

            if (nuevaSesion.Estado.StartsWith("Error"))
            {
                MessageBox.Show(nuevaSesion.Estado);
            }
            else
            {
                MessageBox.Show("Hola, " + usuario.Nombre);
                Principal ventanaPrincipal = new Principal(nuevaSesion, usuario, this);
                ventanaPrincipal.Show();
                this.Enabled = true;
                this.Hide();
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login Básico v2.0 \n por Sebastián De los Ángeles");
        }
    }
}
