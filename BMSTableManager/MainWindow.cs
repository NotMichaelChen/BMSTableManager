using System;
using System.Collections.Generic;
using Gtk;

using BMSTableManager;
using BMSTableManager.TableInfo;

public partial class MainWindow : Gtk.Window
{
    //Path of the LR2 executable
    private string path;
    //Each table is associated with a url to avoid duplicates
    private Dictionary<string, BMSTable> tables;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        path = "";
        tables = new Dictionary<string, BMSTable>();
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

        ResponseType response = (ResponseType)window.Run();
        if(response == ResponseType.Ok)
            path = window.FolderPath;
        window.Destroy();
    }

    protected void OnLoadURLButtonClicked(object sender, EventArgs e)
    {
        string url = TableURLEntry.Text;

        if(tables.ContainsKey(url))
        {
            MessageDialog dialog = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Error, 
                                                     ButtonsType.Close, "Error: Table already loaded");
            dialog.Run();
            dialog.Destroy();
        }
        else
        {
            try
            {
                tables.Add(url, new BMSTable(url));

                MessageDialog dialog = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Info, 
                                                                                            ButtonsType.Close, "Table added successfully");
                dialog.Run();
                dialog.Destroy();
            }
            catch
            {
                //TODO: Make more descriptive errors
                MessageDialog dialog = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Error, 
                                                         ButtonsType.Close, "Error loading url");
                dialog.Run();
                dialog.Destroy();
            }
        }
    }
}