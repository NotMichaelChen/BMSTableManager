using System;
using System.Windows.Forms;

namespace BMSTableManager
{
    public partial class SelectLR2Folder : Gtk.Dialog
    {
        private string path;

        public SelectLR2Folder(string storedpath)
        {
            this.Build();
            path = storedpath;
            FolderPathEntry.Text = storedpath;
        }

        public string FolderPath
        {
            get { return path; }
        }

        protected void OnGetFilePathClicked(object sender, EventArgs e)
        {
            FolderBrowserDialog fileselector = new FolderBrowserDialog();

            if(fileselector.ShowDialog() == DialogResult.OK)
            {
                path = fileselector.SelectedPath;
                FolderPathEntry.Text = fileselector.SelectedPath;
            }
        }
    }
}
