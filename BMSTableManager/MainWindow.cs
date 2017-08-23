using System;
using Gtk;

using BMSTableManager;

public partial class MainWindow : Gtk.Window
{
    //Path of the LR2 file
    private string path;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        path = "";
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void OnSelectLR2FolderActionActivated(object sender, EventArgs e)
    {
        SelectLR2Folder window = new SelectLR2Folder(path);

        window.Response += delegate(object o, ResponseArgs resp) {
            if(resp.ResponseId == ResponseType.Ok)
                path = window.FolderPath;
        };

        window.Run();
        window.Destroy();
    }
}