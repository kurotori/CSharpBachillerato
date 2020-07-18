using System;
using Gtk;

namespace JuegoDeCartasGTK
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            //MainWindow win = new MainWindow();
            //Prueba win = new Prueba();
            win.Show();
            Application.Run();
        }



    }
}
