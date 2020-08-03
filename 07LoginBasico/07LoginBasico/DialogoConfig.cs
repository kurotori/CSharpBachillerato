using System;
using System.Windows.Forms;

namespace _07LoginBasico
{
    /// <summary>
    /// Esta clase es un formulario para mostrar y modificar los datos de acceso a la base de datos
    /// También sirve de ejemplo para desarrollar ventanas con datos de configuración.
    /// </summary>
    public partial class DialogoConfig : Form
    {
        private UtilesXML utilesXML = new UtilesXML();
        //Objeto para leer los datos de configuración

        private readonly string archivoConfig = "configuracion.xml";
        //Archivo con los datos de configuración

        public DialogoConfig()
        {
            InitializeComponent();
            //Generado automáticamente. NO TOCAR

            utilesXML.CrearXML(archivoConfig);
            //Chequeamos la existencia del archivo de configuración

            txtbx_servidor.Text = LeerConfiguracion("IPServidor");
            txtbx_bdd.Text = LeerConfiguracion("BDD");
            txtbx_usuario.Text = LeerConfiguracion("UsuarioBD");
            txtbx_contrasenia.Text = LeerConfiguracion("ContraseniaBD");
            //Obtenemos los datos de configuración

        }

        /// <summary>
        /// Método para el botón 'Cancelar'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            //Cerramos la ventana y liberamos sus recursos de la memoria
        }


        /// <summary>
        /// Método para el botón 'Aceptar'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            string[] datos = {
                "IPServidor:" + txtbx_servidor.Text,
                "BDD:" + txtbx_bdd.Text,
                "UsuarioBD:" + txtbx_usuario.Text,
                "ContraseniaBD:" + txtbx_contrasenia.Text
            };
            //Creamos una lista compilando los datos de los campos de texto

            string resultado = utilesXML.AgregarConfig(archivoConfig, datos);
            //Escribimos los datos en el archivo de configuración

            MessageBox.Show(resultado);
            //Mostramos en pantalla el resultado de la operación

            this.Close();
            this.Dispose();
            //Cerramos la ventana y liberamos sus recursos de la memoria
        }


        /// <summary>
        /// Método para leer datos de la configuración o devolver un error.
        /// Permite notificar al usuario de errores y evita que aparezcan 
        /// esos errores en los campos del formulario.
        /// </summary>
        /// <param name="configuracion">La configuración cuyo dato se quiere obtener</param>
        /// <returns>El dato almacenado para la configuración solicitada</returns>
        private string LeerConfiguracion(string configuracion)
        {
            string dato = utilesXML.LeerConfig(archivoConfig,configuracion);
            if (dato.StartsWith("Error:"))
            {
                MessageBox.Show(dato);
                dato = "";
            }
            return dato;
        }
    }
}
