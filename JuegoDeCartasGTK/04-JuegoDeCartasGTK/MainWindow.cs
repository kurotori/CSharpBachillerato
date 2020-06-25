using System;
using Gtk;
using Glade;

public partial class MainWindow : Gtk.Window
{
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Glade.XML gxml = new XML(null, "GUI/prueba.glade", "window1", null);
        gxml.Autoconnect(this);
        ShowAll();
        //Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }
}
