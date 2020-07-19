using System;
using Gtk;

namespace JuegoDeCartasGTK
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            //JuegoDeCartasGTK.Baraja.Baraja b = new Baraja.Baraja();
            //Console.WriteLine(b.baraja.Count);
            //b.MostrarBaraja();
            MainWindow win = new MainWindow();

            //Prueba win = new Prueba();
            win.Show();
            Application.Run();
        }



    }
}
