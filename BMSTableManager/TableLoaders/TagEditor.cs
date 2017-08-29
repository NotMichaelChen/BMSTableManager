using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Linq;

using BMSTableManager.TableInfo;

namespace BMSTableManager.TableLoaders
{
    //Some notes about tagging
    //Each level in a table is associated with an "id", which is simply the index in which the level appears
    //For the TagEditor, only the "id" is important, since entries in the database are tagged with the id, not the level
    //For the CustomFolderGenerator, the "level" should be displayed (both in the lr2folder file and in the folder name),
    //  and the "id" should be used in the search function
    //All "ids" should be padded according to the padding constant
    //**IMPORTANT: to maintain compatibility with GlAsssist, "ids" are 1-indexed (they start from 1)
    public class TagEditor
    {
        private string path;
        //Gets which level is associated with each id
        private Dictionary<string, int> leveldecoder;
        private BMSTable table;
        private SQLiteConnection dbconnection;

        public TagEditor(string p, BMSTable t)
        {
            path = p;
            table = t;

            leveldecoder = Enumerable.Range(0, table.LevelOrder.Length).ToDictionary(x => table.LevelOrder[x]);

            string dbpath = path + "\\LR2files\\Database\\song.db";
            if(!File.Exists(dbpath))
                throw new Exception("Error: song database not found");
            
            dbconnection = new SQLiteConnection("Data Source=" + dbpath + ";Version=3;");
        }

        //Assigns tags to relevant entries in the song database
        //Always removes old tags before adding new ones
        public void AssignTags()
        {
            RemoveTags();

            dbconnection.Open();

            foreach(TableEntry entry in table.GetCharts())
            {
                string tag = ",t" + table.Symbol + (leveldecoder[entry.level]+1).ToString().PadLeft(Constants.PADDING, '0');

                //Skip entries without a hash
                if(String.IsNullOrEmpty(entry.md5))
                    continue;

                //Check that the song isn't already tagged
                string rawcommand = "UPDATE song SET tag = IFNULL(tag, '') || '" + tag + "' WHERE IFNULL(hash, '')='" + entry.md5 + "' AND NOT IFNULL(tag, '') LIKE '%" + tag + "%'";
                SQLiteCommand command = new SQLiteCommand(rawcommand, dbconnection);
                command.ExecuteNonQuery();
                command.Dispose();
            }

            dbconnection.Close();
            SQLiteConnection.ClearAllPools();
        }

        //Removes all tags associated with the stored table
        //Needed in both removing the table and updating the table (in case some songs are removed/incorrectly tagged)
        public void RemoveTags()
        {
            dbconnection.Open();

            string[] levelorder = table.LevelOrder;

            for(int i = 0; i < table.LevelOrder.Length; ++i)
            {
                string tag = ",t" + table.Symbol + (i+1).ToString().PadLeft(Constants.PADDING, '0');

                string rawcommand = "UPDATE song SET tag = REPLACE(tag, '" + tag + "', '') WHERE IFNULL(tag, '') LIKE '%" + tag + "%'";
                SQLiteCommand command = new SQLiteCommand(rawcommand, dbconnection);
                command.ExecuteNonQuery();
                command.Dispose();
            }

            dbconnection.Close();
        }
    }
}
