using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int puntaje = 1000;
        int valorSorteo = 0;
        int valorApuesta = 0;

        Funciones funciones = new Funciones();

        public Form1()
        {
            InitializeComponent();
            lbl_puntaje.Text = puntaje.ToString();
        }

        //Eventos
        //Botón Rojo
        private void button1_Click(object sender, EventArgs e)
        {
            button5.BackColor = button1.BackColor;
            valorApuesta = 1;
        }

        //Botón Azul
        private void button2_Click(object sender, EventArgs e)
        {
            button5.BackColor = button2.BackColor;
            valorApuesta = 2;
        }

        //Botón Verde
        private void button3_Click(object sender, EventArgs e)
        {
            button5.BackColor = button3.BackColor;
            valorApuesta = 3;
        }

        //Botón Amarillo
        private void button4_Click(object sender, EventArgs e)
        {
            button5.BackColor = button4.BackColor;
            valorApuesta = 4;
        }

        //Botón Muestra de Apuesta
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(button5.BackColor.ToString());
        }

        //Botón Apostar
        private void button7_Click(object sender, EventArgs e)
        {   
            if (puntaje >= 100)
            {

                if (valorApuesta == 0)
                {
                    MessageBox.Show("Por favor elija un color");
                }
                else
                {
                    valorSorteo = funciones.AlAzar(1, 4);

                    //Aplicar color al botón del resultado del sorteo
                    switch (valorSorteo)
                    {
                        case 1:
                            button6.BackColor = Color.Red;
                            break;
                        case 2:
                            button6.BackColor = Color.Blue;
                            break;
                        case 3:
                            button6.BackColor = Color.Lime;
                            break;
                        case 4:
                            button6.BackColor = Color.Yellow;
                            break;
                        default:
                            break;
                    }

                    //Comprobar apuesta
                    if(valorApuesta == valorSorteo)
                    {
                        MessageBox.Show("¡¡Acertaste!!");
                        puntaje = puntaje + 100;
                    }
                    else
                    {
                        MessageBox.Show("¡¡Mala Suerte!!");
                        puntaje = puntaje - 100;
                    }

                    //Preparar para siguiente apuesta
                    lbl_puntaje.Text = puntaje.ToString();
                    valorApuesta = 0;
                    valorSorteo = 0;
                    button5.BackColor = Color.White;
                    button6.BackColor = Color.White;
                }
            }
            else
            {
                MessageBox.Show("¡¡No puedes jugar!!");
            }
        }
    }
}
