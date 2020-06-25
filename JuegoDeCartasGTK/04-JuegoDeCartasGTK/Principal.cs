using System;
using Gtk;

namespace JuegoDeCartasGTK
{
    public partial class Principal : Window
    {
        public Principal() :
                base(Gtk.WindowType.Toplevel)
        {
            DefinirVentana();
            ShowAll();
        }


        protected void DefinirVentana()
        {
            SetDefaultSize(400, 400);
            DeleteEvent += delegate {
                Application.Quit();
            };
            
            ModifyBg(StateType.Normal, new Gdk.Color(40, 40, 40));
            Fixed espacio = new Fixed();
            Button btn_01 = new Button("Probando");
            espacio.Put(btn_01, 10, 20);

            btn_01.ModifyBg(StateType.Normal, new Gdk.Color(255, 0, 0));

            Gdk.Pixbuf oro_1;
            try
            {
                oro_1 = new Gdk.Pixbuf("imagen/1_oro.png",85,130);
                Image imagen = new Image(oro_1);

                espacio.Put(imagen, 50, 50);

                //imagen.HeightRequest = 130;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Environment.Exit(1);
            }

            Add(espacio);
        }
    }
}
