using System;

namespace BMSTableManager.TableInfo
{
    //Contains metadata about the given table
    public struct TableHeader
    {
        public string data_url;
        public string name;
        public string symbol;
        public string[] level_order;
    }
}
