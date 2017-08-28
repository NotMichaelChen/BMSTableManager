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

        //Assigns tags to relevant entries in the song database
        //Always removes old tags before adding new ones
        public void AssignTags()
        {
            dbconnection.Open();

            foreach(TableEntry entry in table.GetCharts())
            {
                string tag = ",t" + table.Symbol + entry.level;

                //Check that the song isn't already tagged
                string rawcommand = "UPDATE song SET tag = ISNULL(tag, '') + '" + tag + "' WHERE md5='" + entry.md5 + "' AND tag LIKE '%" + tag + "%'";
                SQLiteCommand command = new SQLiteCommand(rawcommand, dbconnection);
                command.ExecuteNonQuery();
            }

            dbconnection.Close();
        }

        //Removes all tags associated with the stored table
        //Needed in both removing the table and updating the table (in case some songs are removed/incorrectly tagged)
        public void RemoveTags()
        {
            dbconnection.Open();

            string[] levelorder = table.LevelOrder;

            foreach(string level in levelorder)
            {
                string tag = ",t" + table.Symbol + level;

                string rawcommand = "UPDATE song SET tag = REPLACE(tag, '" + tag + "', '') WHERE tag LIKE '%" + tag + "%'";
                SQLiteCommand command = new SQLiteCommand(rawcommand, dbconnection);
                command.ExecuteNonQuery();
            }

            dbconnection.Close();
        }
    }
}
