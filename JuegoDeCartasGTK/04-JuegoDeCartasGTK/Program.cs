using System;
using Gtk;

namespace JuegoDeCartasGTK
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            Principal win = new Principal();
            //MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
