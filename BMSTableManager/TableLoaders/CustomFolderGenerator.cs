using System;
using System.IO;
using System.Text;

using BMSTableManager.TableInfo;

namespace BMSTableManager.TableLoaders
{
    public class CustomFolderGenerator
    {
        private BMSTable table;
        private string exepath;

        public CustomFolderGenerator(BMSTable t)
        {
            table = t;
            exepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //Set working directory to directory of exe
            Directory.SetCurrentDirectory(exepath);
        }

        //Generates the main lr2folder files, one for each level in the difficulty table
        public void GenerateTable()
        {
            //Initial folder check is the same, so use method to avoid code duplication
            DeleteTable();

            //Directory may still exist after deleting since Delete is not synchronous
            while (Directory.Exists(table.TableName))
                System.Threading.Thread.Sleep(10);

            Directory.CreateDirectory(table.TableName);
            Directory.SetCurrentDirectory(table.TableName);

            StreamWriter lrfolder;
            for(int i = 0; i < table.LevelOrder.Length; ++i)
            {
                string level = table.LevelOrder[i];

                //Inserting a left-padded index keeps the table in correct order (LR2 seems to naively sort folders using string comparisons)
                //NOTICE: This index is completely separate from the "id" used by the tag editor (which is simply the index+1)
                //LR2 uses Shift JIS encoding = Code Page 932
                lrfolder = new StreamWriter(i.ToString().PadLeft(Constants.PADDING, '0') + table.Symbol + level + ".lr2folder", false, Encoding.GetEncoding(932));
                lrfolder.WriteLine("#COMMAND tag LIKE '%t" + table.Symbol + (i+1).ToString().PadLeft(Constants.PADDING, '0') + "%'");
                lrfolder.WriteLine("#MAXTRACKS 0");
                lrfolder.WriteLine("#CATEGORY " + table.TableName);
                lrfolder.WriteLine("#TITLE LEVEL " + table.Symbol + level);
                lrfolder.WriteLine("#INFORMATION_A");
                lrfolder.WriteLine("#INFORMATION_B");
                lrfolder.Close();
            }

            Directory.SetCurrentDirectory(exepath);
        }

        //Removes the folder associated with the table
        public void DeleteTable()
        {
            Directory.SetCurrentDirectory(exepath);
            CheckCustomFolderExists();
            Directory.SetCurrentDirectory("CustomFolder");

            if(Directory.Exists(table.TableName))
                Directory.Delete(table.TableName, true);
        }

        //Checks if the folder associated with the table exists
        public bool IsTableExists()
        {
            return Directory.Exists(exepath + "\\CustomFolder\\" + table.TableName);
        }

        //Checks if the custom folder that holds all of the difficulty table folders exists
        //Creates the custom folder if it doesn't exist
        private void CheckCustomFolderExists()
        {
            if(!Directory.Exists("CustomFolder"))
                Directory.CreateDirectory("CustomFolder");
        }
    }
}
