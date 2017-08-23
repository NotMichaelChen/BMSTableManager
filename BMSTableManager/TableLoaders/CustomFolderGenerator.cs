using System;
using System.IO;

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
            Directory.SetCurrentDirectory(exepath);

            CheckCustomFolderExists();
            Directory.SetCurrentDirectory("CustomFolder");

            if(Directory.Exists(table.TableName))
                Directory.Delete(table.TableName, true);

            //Directory may still exist after deleting since Delete is not synchronous
            while (Directory.Exists(table.TableName))
                System.Threading.Thread.Sleep(10);

            Directory.CreateDirectory(table.TableName);
            Directory.SetCurrentDirectory(table.TableName);

            StreamWriter lrfolder;
            foreach(string level in table.LevelOrder)
            {
                lrfolder = File.CreateText(table.Symbol + level + ".lr2folder");
                lrfolder.WriteLine("#COMMAND tag LIKE '%t" + table.Symbol + level + "%'");
                lrfolder.WriteLine("#MAXTRACKS 0");
                lrfolder.WriteLine("#CATEGORY " + table.TableName);
                lrfolder.WriteLine("#TITLE LEVEL " + table.Symbol + level);
                lrfolder.WriteLine("#INFORMATION_A");
                lrfolder.WriteLine("#INFORMATION_B");
                lrfolder.Close();
            }

            Directory.SetCurrentDirectory(exepath);
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
