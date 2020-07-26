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
    public partial class DialogoConfig : Form
    {
        UtilesXML utiles = new UtilesXML();
        string archivo = "configuracion.xml";

        public DialogoConfig()
        {
            InitializeComponent();
            utiles.CrearXML(archivo);

            txtbx_servidor.Text = LeerConfiguracion("IPServidor");
            txtbx_bdd.Text = LeerConfiguracion("BDD");
            txtbx_usuario.Text = LeerConfiguracion("UsuarioBD");
            txtbx_contrasenia.Text = LeerConfiguracion("ContraseniaBD");

        }


        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            string[] datos = {
                "IPServidor:" + txtbx_servidor.Text,
                "BDD:" + txtbx_bdd.Text,
                "UsuarioBD:" + txtbx_usuario.Text,
                "ContraseniaBD:" + txtbx_contrasenia.Text
            };
            utiles.AgregarConfig(archivo, datos);
            MessageBox.Show("Datos Guardados");
            this.Close();
        }

        private string LeerConfiguracion(string configuracion)
        {
            string dato = utiles.LeerConfig(archivo,configuracion);
            if (dato.StartsWith("Error:"))
            {
                MessageBox.Show(dato);
                dato = "";
            }
            return dato;
        }
    }
}
