using System;
using System.Windows.Forms;

namespace _07LoginBasico
{
    public partial class CrearUsuario : Form
    {
        Consultas consultas = new Consultas();
        //Objeto para acceder a las consultas

        public CrearUsuario()
        {
            InitializeComponent();
            //Código generado de forma automática. NO TOCAR
        }


        /// <summary>
        /// Método para el botón Cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


        /// <summary>
        /// Método para el botón Crear Usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CrearUsuario_Click(object sender, EventArgs e)
        {
            //Al dar click en el botón 'Crear Usuario' se inicia el chequeo de los datos en el formulario

            if (txt_ci.Text.Length == 8)// 1 - ¿La CI tiene 8 dígitos?
                                        //NOTA: NO CHEQUEA si los datos introducidos son LETRAS o NÚMEROS
            
            {
                if (txt_nomUsuario.Text.Length >= 8)      // 2 - ¿El nombre de usuario tiene al menos 8 caracteres..
                
                {
                    if (txt_nomUsuario.Text.Length <= 12)  // ... y no más de 12 caracteres?
                                                          /* NOTA: El TextBox NO PERMITE textos más largos que 12 caracteres
                                                           * ya que se modificó su propiedad MaxLength
                                                           */
                    
                    {
                        if (txt_contrasenia.Text.Length >= 8)  //3 - ¿La contraseña tiene al menos 8 caracteres...
                                                               /* NOTA: NO CHEQUEA la complejidad de la contraseña **/
                        {
                            if (txt_contrasenia.Text.Length <= 15)  //...y no más de 15 caracteres?
                                                                    // NOTA: ver NOTA anterior
                            {
                                if (txt_contrasenia.Text.Equals(txt_repContrasenia.Text))  //4 - ¿La contraseña y su repetición coinciden?
                                {

                                    //Si se cumplen todas las condiciones...

                                    Cursor.Current = Cursors.WaitCursor;
                                    this.Enabled = false;
                                    //Cambiamos el cursor al 'reloj de espera'
                                    // y deshabilitamos la ventana

                                    string ci = txt_ci.Text;
                                    string usuario = txt_nomUsuario.Text;
                                    string contrasenia = txt_contrasenia.Text;
                                    // 1 - Almacenamos los datos de los TextBox que nos interesan en variables

                                    Usuario nuevoUsuario = new Usuario(ci, usuario, contrasenia);

                                    string resultado = nuevoUsuario.Registrarse();
                                    // 2 - Ejecutamos el método Registrarse del nuevoUsuario y guardamos el 
                                    //resultado de la ejcución en una variable

                                    MessageBox.Show(resultado);
                                    Cursor.Current = Cursors.Default;
                                    // 3 - Mostramos ese resultado en un MessageBox (puede avisarnos de errores en la BdD)
                                    // y restauramos el cursor.

                                    this.Close();
                                    this.Dispose();
                                    // 4 - Cerramos y limpiamos de la memoria a la ventana
                                }

                                /* Todo el resto son mensajes de error de validación de los datos del formulario
                                 * es MUY RECOMENDABLE: 
                                 *  - Crear cada ELSE al declarar el IF, para evitar confusiones luego
                                 *  - Tener bien detallados los mensajes de error en los CASOS DE USO para facilitarle
                                 *      la tarea a los programadores
                                 */

                                else
                                {
                                    MessageBox.Show("Las contraseñas no coinciden");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Las contraseñas no pueden tener más de 15 caracteres");
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("La contraseña debe tener al menos 8 caracteres");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El nombre de usuario debe tener entre 8 y 12 caracteres.");
                    }
                    
                }
                else
                {
                    MessageBox.Show("El nombre de usuario debe tener entre 8 y 12 caracteres.");
                }
            }
            else
            {
                MessageBox.Show("La CI no esta escrita de forma correcta");
            }
        }


    }
}
