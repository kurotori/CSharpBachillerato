using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Gtk;
using JuegoDeCartasGTK.Baraja;


public partial class MainWindow : Gtk.Window
{




    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        ShowAll();
        PrepararVentana();
        //Apariencia();
    }

    private List<Image> imgCartas = new List<Image>();
    private Baraja baraja = new Baraja();

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void PrepararVentana()
    {
        Assembly ensamble = Assembly.GetExecutingAssembly();
        //Stream flujo = ensamble.GetManifestResourceStream("JuegoDeCartasGTK.imagen.baraja.basto1.png");
        


        for (uint i = 0; i < 12; i++)
        {
            //Image imagen = new Image();
            //string datoImagen = baraja.baraja[(int)i].GetInfoImagen();

            /*Stream flujo = ensamble.GetManifestResourceStream(datoImagen);
            imagen.Pixbuf = new Gdk.Pixbuf(flujo, 80, 130);
            imgCartas.Add(imagen);
            flujo.Close();

            table1.Attach(imagen, i, i+1, 0, 1);
            imagen.Show();*/
        }

        Console.WriteLine("-----" + imgCartas.Count);
        Console.WriteLine(table1.NRows);
        Console.WriteLine(table1.NColumns);
    }

    protected void Apariencia()
    {
        /*Assembly ensamble = Assembly.GetExecutingAssembly();
        Stream flujo = ensamble.GetManifestResourceStream("JuegoDeCartasGTK.imagen.baraja.basto1.png");
        image1.Pixbuf = new Gdk.Pixbuf(flujo,50,80);*/
    }

}
