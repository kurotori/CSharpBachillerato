using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Gtk;
using JuegoDeCartasGTK.Baraja;
using JuegoDeCartasGTK;


public partial class MainWindow : Gtk.Window
{




    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        //ShowAll();
        PrepararVentana();
        //Apariencia();
    }

    private Baraja baraja = new Baraja();
    private Assembly ensamble = Assembly.GetExecutingAssembly();
    //Creamos un ensamble para acceder a los archivos contenidos en el ejecutable

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void PrepararVentana()
    {
        Console.WriteLine("Barajando...");
        baraja.Barajar_nuevo();

        //Stream flujo = ensamble.GetManifestResourceStream("JuegoDeCartasGTK.imagen.baraja.basto1.png");
        int idCarta = 0;
        //Incializamos un int en 0 para indicar nuestra posición en la baraja

        for (uint fila = 0; fila < 4; fila++)
            //El primer FOR es para recorrer las filas del Gtk.Table
            // debe usarse un 'uint' en vez de 'int' debido a que el método Attach no
            // acepta variable de tipo 'int'
        {
            for (uint columna = 0; columna < 11; columna++)
                //El segundo FOR es para recorrer las columnas del Gtk.Table
            {
                Carta carta = baraja.baraja[idCarta];
                //1 - Obtenemos la carta de la baraja

                Image imagen = new Image();
                //2 - Creamos una imagen

                ButtonCarta b = new ButtonCarta(carta);
                //3 - Creamos el botón para la carta con la clase Button modificada y le
                // asignamos la carta

                //string datoImagen = baraja.baraja[carta].GetInfoImagen();
                //imagen.SetCarta(baraja.baraja[carta]);

                //Console.WriteLine(datoImagen);
                Stream flujo = ensamble.GetManifestResourceStream("JuegoDeCartasGTK.imagen.baraja.reves.png");
                //4 - Creamos un flujo de datos para obtener la imagen del botón 

                imagen.Pixbuf = new Gdk.Pixbuf(flujo, 80, 130);
                //5 - Establecemos el flujo en el objeto imagen declarado antes

                flujo.Close();
                //6 - Cerramos el flujo de datos

                b.Image = imagen;
                //7 - Añadimos la imagen al botón

                b.Clicked += new EventHandler(CartaClick);
                //8 - Añadimos al botón el evento CartaClick que declaramos más abajo

                b.Show();
                //9 - Marcamos el botón para mostrarse

                tblTablero1.Attach(b, columna, columna + 1, fila, fila+1);
                //10 - Añadimos el botón a la posición actual en la tabla.
                // Para más detalles sobre el método Attach ver:              

                idCarta++;
                //11 - Pasamos a la siguiente carta
            }
        }
    }

    protected void Apariencia()
    {
        /*Assembly ensamble = Assembly.GetExecutingAssembly();
        Stream flujo = ensamble.GetManifestResourceStream("JuegoDeCartasGTK.imagen.baraja.basto1.png");
        image1.Pixbuf = new Gdk.Pixbuf(flujo,50,80);*/
    }


    private void CartaClick(object obj, EventArgs args)
    {
        Console.WriteLine("click " + obj.GetType());
        ButtonCarta b = (ButtonCarta)obj;
        Carta c = b.GetCarta();
        Image img = new Image();
        Stream flujo = ensamble.GetManifestResourceStream(c.GetInfoImagen());
        img.Pixbuf = new Gdk.Pixbuf(flujo, 80, 130);
        flujo.Close();
        b.Image = img;
    }
}
