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
    public partial class Form1 : Form
    {
        private string ipServidor = "";
        private string bdd = "";
        private string usuarioBdd = "";
        private string contraseñaBdd = "";

        private UtilesXML utiles = new UtilesXML();
        public Form1()
        {
            InitializeComponent();

            //utiles.CrearXML("algo.xml");
            //utiles.agregarConfig("algo.xml", "prueba", "blabla");

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogoConfig dc = new DialogoConfig();
            dc.ShowDialog();
        }
    }
}
