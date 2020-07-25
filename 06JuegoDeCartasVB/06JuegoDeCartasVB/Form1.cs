using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06JuegoDeCartasVB.Cartas;

namespace _06JuegoDeCartasVB
{
    public partial class Form1 : Form
    {
        Baraja baraja = new Baraja();
        List<Carta> vidas = new List<Carta>();



        public Form1()
        {
            InitializeComponent();
            PrepararVentana();
            
        }

        protected void PrepararVentana()
        {
            baraja.Barajar_nuevo();

            char[] letrasPalo = { 'o', 'e', 'c', 'b' };
            int idCarta = 0;
            for (int fila = 0; fila < tbl_tablero.RowCount; fila++)
            {
                for (int columna = 0; columna < tbl_tablero.ColumnCount; columna++)
                {
                    ButtonCarta bt = new ButtonCarta();
                    bt.SetCarta(baraja.baraja[idCarta]);

                    bt.SetPosicion(letrasPalo[fila],columna+1);

                    bt.Size = new Size(104, 159);
                    bt.Text = bt.GetPosicion();
                    Image im = Image.FromFile(bt.GetCarta().GetInfoImagen());
                    bt.BackgroundImage = im;
                    bt.BackgroundImageLayout = ImageLayout.Stretch;
                    bt.Click += button1_Click;
                    tbl_tablero.Controls.Add(bt, columna, fila);
                    idCarta++;
                }
            }

            for (int vida = 0; vida < 4; vida++)
            {
                vidas.Add(baraja.baraja[idCarta]);
                idCarta++;
            }

            ButtonCarta btv = new ButtonCarta();
            btv.SetCarta(vidas[0]);
            btv.Size = new Size(104, 159);
            Image imv = Image.FromFile(btv.GetCarta().GetInfoImagen());
            btv.BackgroundImage = imv;
            btv.BackgroundImageLayout = ImageLayout.Stretch;
            tbl_control.Controls.Add(btv, 0, 1);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            ButtonCarta boton = (ButtonCarta)sender;
            Console.WriteLine(boton.GetPosicion());
        }
    }
}
