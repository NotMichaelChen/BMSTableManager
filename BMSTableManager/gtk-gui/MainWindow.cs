
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action FileAction;

	private global::Gtk.Action SelectLR2FolderAction;

	private global::Gtk.Action HelpAction;

	private global::Gtk.Action AboutAction;

	private global::Gtk.VBox vbox3;

	private global::Gtk.MenuBar menubar1;

	private global::Gtk.HBox hbox1;

	private global::Gtk.Entry TableURLEntry;

	private global::Gtk.Button LoadURLButton;

	private global::Gtk.HSeparator hseparator2;

	private global::Gtk.VBox vbox4;

	private global::Gtk.ComboBox TableSelectorComboBox;

	private global::Gtk.HBox hbox2;

	private global::Gtk.Button LoadTableButton;

	private global::Gtk.Button DeleteTableButton;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.FileAction = new global::Gtk.Action("FileAction", global::Mono.Unix.Catalog.GetString("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString("File");
		w1.Add(this.FileAction, null);
		this.SelectLR2FolderAction = new global::Gtk.Action("SelectLR2FolderAction", global::Mono.Unix.Catalog.GetString("Select LR2 Folder"), null, null);
		this.SelectLR2FolderAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Select LR2 Folder");
		w1.Add(this.SelectLR2FolderAction, null);
		this.HelpAction = new global::Gtk.Action("HelpAction", global::Mono.Unix.Catalog.GetString("Help"), null, null);
		this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Help");
		w1.Add(this.HelpAction, null);
		this.AboutAction = new global::Gtk.Action("AboutAction", global::Mono.Unix.Catalog.GetString("About"), null, null);
		this.AboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString("About");
		w1.Add(this.AboutAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("BMS Table Manager");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox3 = new global::Gtk.VBox();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString(@"<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='SelectLR2FolderAction' action='SelectLR2FolderAction'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='AboutAction' action='AboutAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox3.Add(this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.TableURLEntry = new global::Gtk.Entry();
		this.TableURLEntry.CanFocus = true;
		this.TableURLEntry.Name = "TableURLEntry";
		this.TableURLEntry.IsEditable = true;
		this.TableURLEntry.InvisibleChar = '●';
		this.hbox1.Add(this.TableURLEntry);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.TableURLEntry]));
		w3.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.LoadURLButton = new global::Gtk.Button();
		this.LoadURLButton.CanFocus = true;
		this.LoadURLButton.Name = "LoadURLButton";
		this.LoadURLButton.UseUnderline = true;
		this.LoadURLButton.Label = global::Mono.Unix.Catalog.GetString("Load URL");
		this.hbox1.Add(this.LoadURLButton);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.LoadURLButton]));
		w4.Position = 1;
		w4.Expand = false;
		w4.Fill = false;
		this.vbox3.Add(this.hbox1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox1]));
		w5.Position = 1;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hseparator2 = new global::Gtk.HSeparator();
		this.hseparator2.Name = "hseparator2";
		this.vbox3.Add(this.hseparator2);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hseparator2]));
		w6.Position = 2;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.vbox4 = new global::Gtk.VBox();
		this.vbox4.Name = "vbox4";
		this.vbox4.Spacing = 6;
		// Container child vbox4.Gtk.Box+BoxChild
		this.TableSelectorComboBox = global::Gtk.ComboBox.NewText();
		this.TableSelectorComboBox.Name = "TableSelectorComboBox";
		this.vbox4.Add(this.TableSelectorComboBox);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.TableSelectorComboBox]));
		w7.Position = 0;
		w7.Expand = false;
		w7.Fill = false;
		// Container child vbox4.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.LoadTableButton = new global::Gtk.Button();
		this.LoadTableButton.CanFocus = true;
		this.LoadTableButton.Name = "LoadTableButton";
		this.LoadTableButton.UseUnderline = true;
		this.LoadTableButton.Label = global::Mono.Unix.Catalog.GetString("Load Table");
		this.hbox2.Add(this.LoadTableButton);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.LoadTableButton]));
		w8.Position = 0;
		w8.Expand = false;
		w8.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.DeleteTableButton = new global::Gtk.Button();
		this.DeleteTableButton.CanFocus = true;
		this.DeleteTableButton.Name = "DeleteTableButton";
		this.DeleteTableButton.UseUnderline = true;
		this.DeleteTableButton.Label = global::Mono.Unix.Catalog.GetString("Delete Table");
		this.hbox2.Add(this.DeleteTableButton);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.DeleteTableButton]));
		w9.Position = 1;
		w9.Expand = false;
		w9.Fill = false;
		this.vbox4.Add(this.hbox2);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox2]));
		w10.Position = 1;
		w10.Expand = false;
		w10.Fill = false;
		this.vbox3.Add(this.vbox4);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.vbox4]));
		w11.Position = 3;
		this.Add(this.vbox3);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.SelectLR2FolderAction.Activated += new global::System.EventHandler(this.OnSelectLR2FolderActionActivated);
		this.LoadURLButton.Clicked += new global::System.EventHandler(this.OnLoadURLButtonClicked);
		this.LoadTableButton.Clicked += new global::System.EventHandler(this.OnLoadTableButtonClicked);
		this.DeleteTableButton.Clicked += new global::System.EventHandler(this.OnDeleteTableButtonClicked);
	}
}
