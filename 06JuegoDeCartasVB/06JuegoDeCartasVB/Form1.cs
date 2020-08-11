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

        List<Carta> cartasVidas = new List<Carta>();
        Carta vida = null;

        Carta enMano = null;
        ButtonCarta btn_cartaEnMano = null;

        Juego juego = new Juego();
        

        public Form1()
        {
            InitializeComponent();
            //Generado automáticamente, NO TOCAR


            PrepararVentana();

            
        }


        /// <summary>
        /// Inicializa y prepara la ventana para el juego
        /// </summary>
        protected void PrepararVentana()
        {
            char[] letrasPalo = { 'o', 'e', 'c', 'b' };
            //Array con las letras iniciales de los palos para identificar 
            // las posiciones de las cartas en el tablero
             

            int idCarta = 0;
            //Identificador de la carta actual para el reparto de cartas
            
            baraja.Barajar_nuevo();
            //1 - Se entrevera la baraja
            
            for (int fila = 0; fila < tbl_tablero.RowCount; fila++)
            //2 - Comenzamos a recorrer el tablero. Primero las filas...
            {
                for (int columna = 0; columna < tbl_tablero.ColumnCount; columna++)
                //... y luego las columnas. De esta manera ubicamos cada carta de 
                // cada fila antes de pasar a la siguiente fila.
                {
                    Carta carta = baraja.baraja[idCarta];
                    //Tomamos una carta de la baraja

                    string posicion = letrasPalo[fila] + (columna + 1).ToString();
                    //Guardamos el código de su posición en el tablero

                    ButtonCarta bt = new ButtonCarta(carta,posicion);
                    //Creamos un botón para representar la carta en el tablero

                    bt.Size = new Size(104, 159);
                    //Definimos su tamaño

                    bt.Click += Carta_Click;
                    //Le agregamos un método a su evento 'Click'

                    bt.Enabled = false;
                    //Lo desabilitamos para evitar que se lo use antes de tiempo

                    tbl_tablero.Controls.Add(bt, columna, fila);
                    //Lo añadimos al tablero en la posición que establecimos

                    idCarta++;
                    //Avanzamos el identificador a la siguiente carta
                }
            }

            
            for (int vida = 0; vida < 4; vida++)
            //3 - Las cartas restantes las añadimos a la lista de vidas
            {
                Carta carta = baraja.baraja[idCarta];
                //Ubicamos la carta en la baraja

                cartasVidas.Add(carta);
                //La añadimos a la lista de vidas

                idCarta++;
                //Avanzamos el identificador a la siguiente carta
            }


            vida = cartasVidas[0];

            
            ButtonCarta btn_Vidas = new ButtonCarta(vida,"");
            btn_Vidas.Size = new Size(104, 159);
            //4 - Creamos el botón para las cartas de las vidas...

            btn_Vidas.Click += Vida_Click;
            //... le agregamos el evento correspondiente...

            btn_Vidas.Text = cartasVidas.Count.ToString();
            btn_Vidas.Font = new Font("Arial Black", 28, FontStyle.Regular);
            btn_Vidas.ForeColor = Color.White;
            //... y establecemos el texto del botón y su apariencia con las vidas


            btn_cartaEnMano = new ButtonCarta();
            btn_cartaEnMano.Size = new Size(104, 159);
            //5 - Establecemos el botón para la carta en la mano

            tbl_control.Controls.Add(btn_Vidas, 0, 3);
            tbl_control.Controls.Add(btn_cartaEnMano, 0, 1);
            //6 - Añadimos los botones al tablero de control
        }



        private void Carta_Click(object sender, EventArgs e)
        {
            ButtonCarta boton = (ButtonCarta)sender;
            Console.WriteLine(boton.GetPosicion());

            Carta cartaTablero = boton.Carta;
            boton.Carta = btn_cartaEnMano.Carta;
            btn_cartaEnMano.Carta = cartaTablero;

            Image img = Image.FromFile(boton.GetCarta().GetInfoImagen());
            boton.DefinirImagen(img);
            


        }


        private void Vida_Click(object sender, EventArgs e)
        {
            ButtonCarta btn_Vidas = (ButtonCarta)sender;

            int numVidas = cartasVidas.Count;
            Console.WriteLine("----" + numVidas);

            btn_cartaEnMano.Carta = btn_Vidas.Carta;
            Image im = Image.FromFile(btn_cartaEnMano.Carta.GetInfoImagen());
            btn_cartaEnMano.DefinirImagen(im);
            // ubicar la carta en el tablero
            if (juego.ChequearCarta(btn_cartaEnMano.Carta))
            {
                //MessageBox.Show("sirve");
                juego.UbicarCarta(btn_cartaEnMano.Carta,tbl_tablero);
            }
            else
            {
                MessageBox.Show("Perdiste una vida");
            }


            if (numVidas > 1)
            {
                cartasVidas.RemoveAt(0);
                btn_Vidas.Carta = cartasVidas[0];
            }
            else 
            {
                btn_Vidas.Carta = cartasVidas[0];
                cartasVidas.Clear();

                Image imv = Image.FromFile("imagen\\baraja\\vacia.png");
                btn_Vidas.DefinirImagen(imv);
            }


            btn_Vidas.Text = cartasVidas.Count.ToString();

        }


        
    }
}
