using System;
using System.Collections.Generic;
using Gtk;

using BMSTableManager;
using BMSTableManager.TableInfo;
using BMSTableManager.TableLoaders;
using BMSTableManager.WindowTools;

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
            MessageDialogHelper.ErrorDialog(this, ButtonsType.Close, "Error: Table already loaded");
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

                MessageDialogHelper.InfoDialog(this, ButtonsType.Close, "Table added successfully");
            }
            catch(Exception ex)
            {
                //TODO: Make more descriptive errors
                MessageDialogHelper.ErrorDialog(this, ButtonsType.Close, ex.ToString());
            }
        }
    }

    protected void OnLoadTableButtonClicked(object sender, EventArgs e)
    {
        try
        {
            TagEditor editor = new TagEditor(path, tables[TableSelectorComboBox.ActiveText]);
            CustomFolderGenerator gen = new CustomFolderGenerator(tables[TableSelectorComboBox.ActiveText]);
            editor.AssignTags();
            gen.GenerateTable();

            MessageDialogHelper.InfoDialog(this, ButtonsType.Close, "Table loaded successfully\n\n" +
                                           "You can use the difficulty tables by adding \"CustomFolder\" to LR2");
        }
        catch(Exception ex)
        {
            //TODO: Make more descriptive errors
            MessageDialogHelper.ErrorDialog(this, ButtonsType.Close, ex.ToString());
        }
    }

    protected void OnDeleteTableButtonClicked(object sender, EventArgs e)
    {
        try
        {
            ResponseType resp = (ResponseType)MessageDialogHelper.QuestionDialog(this, ButtonsType.OkCancel, "Are you sure you want to delete table \"" + TableSelectorComboBox.ActiveText + "\"?");
            if(resp == ResponseType.Ok)
            {
                TagEditor editor = new TagEditor(path, tables[TableSelectorComboBox.ActiveText]);
                editor.RemoveTags();

                MessageDialogHelper.InfoDialog(this, ButtonsType.Close, "Table removed successfully");
            }
        }
        catch(Exception ex)
        {
            //TODO: Make more descriptive errors
            MessageDialogHelper.ErrorDialog(this, ButtonsType.Close, ex.ToString());
        }
    }
}