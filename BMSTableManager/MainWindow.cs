using System;
using System.Collections.Generic;
using Gtk;

using BMSTableManager;
using BMSTableManager.TableInfo;
using BMSTableManager.TableLoaders;

public partial class MainWindow : Gtk.Window
{
    //Path of the LR2 executable
    private string path;
    //Set of urls already added, to avoid duplicates
    private HashSet<string> usedurls;
    //Each table is associated with its name to make name lookups from the combobox fast
    private Dictionary<string, BMSTable> tables;

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        path = "";
        usedurls = new HashSet<string>();
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

        if(usedurls.Contains(url))
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
                BMSTable downloadedtable = new BMSTable(url);

                usedurls.Add(url);
                tables.Add(downloadedtable.TableName, downloadedtable);
                TableSelectorComboBox.AppendText(downloadedtable.TableName);
                TableURLEntry.Text = "";

                MessageDialog dialog = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Info, 
                                                                                            ButtonsType.Close, "Table added successfully");
                dialog.Run();
                dialog.Destroy();
            }
            catch(Exception ex)
            {
                //TODO: Make more descriptive errors
                MessageDialog dialog = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Error, 
                                                         ButtonsType.Close, ex.ToString());
                dialog.Run();
                dialog.Destroy();
            }
        }
    }

    protected void OnLoadTableButtonClicked(object sender, EventArgs e)
    {
        CustomFolderGenerator gen = new CustomFolderGenerator(tables[TableSelectorComboBox.ActiveText]);
        gen.GenerateTable();

        MessageDialog dialog = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Info, 
                                                 ButtonsType.Close, "Table loaded successfully\n\nYou can use the difficulty tables by adding \"CustomFolder\" to LR2");
        dialog.Run();
        dialog.Destroy();
    }
}