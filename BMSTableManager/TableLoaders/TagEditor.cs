using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;

using BMSTableManager.TableInfo;

namespace BMSTableManager.TableLoaders
{
    public class TagEditor
    {
        private string path;
        private BMSTable table;
        private SQLiteConnection dbconnection;

        public TagEditor(string p, BMSTable t)
        {
            path = p;
            table = t;
            string dbpath = path + "\\LR2Files\\Database\\song.db";
            if(!File.Exists(dbpath))
                throw new Exception("Error: song database not found");
            
            dbconnection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
        }

        public void AssignTags()
        {
            dbconnection.Open();

            foreach(TableEntry entry in table.GetCharts())
            {
                string rawcommand = "UPDATE song SET tag = ISNULL(tag, '') + 't" + table.Symbol + entry.level + "' WHERE md5='" + entry.md5 + "'";
                SQLiteCommand command = new SQLiteCommand(rawcommand, dbconnection);
                command.ExecuteNonQuery();
            }

            dbconnection.Close();
        }
    }
}
