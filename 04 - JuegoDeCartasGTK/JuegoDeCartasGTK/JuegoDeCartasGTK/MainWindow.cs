using System;
using System.IO;
using System.Reflection;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        Apariencia();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void Apariencia()
    {
        Assembly ensamble = Assembly.GetExecutingAssembly();
        Stream flujo = ensamble.GetManifestResourceStream("JuegoDeCartasGTK.imagen.baraja.basto1.png");
        image1.Pixbuf = new Gdk.Pixbuf(flujo,50,80);
    }

}
