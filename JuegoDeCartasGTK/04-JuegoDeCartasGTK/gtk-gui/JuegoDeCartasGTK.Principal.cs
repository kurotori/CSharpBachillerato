
// This file has been generated by the GUI designer. Do not modify.
namespace JuegoDeCartasGTK
{
	public partial class Principal
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Image image1;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget JuegoDeCartasGTK.Principal
			this.WidthRequest = 800;
			this.HeightRequest = 600;
			this.Name = "JuegoDeCartasGTK.Principal";
			this.Title = global::Mono.Unix.Catalog.GetString("Principal");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child JuegoDeCartasGTK.Principal.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.image1 = new global::Gtk.Image();
			this.image1.Name = "image1";
			this.hbox2.Add(this.image1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.image1]));
			w1.Position = 0;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w2.Position = 2;
			w2.Expand = false;
			w2.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 1064;
			this.DefaultHeight = 779;
			this.Show();
		}
	}
}