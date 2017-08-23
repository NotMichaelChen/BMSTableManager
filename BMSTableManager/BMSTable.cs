using System;
using System.Net;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace BMSTableManager
{
    //Stores an instance of a BMS difficulty table
    public class BMSTable
    {
        private string tableurl;
        private string headerurl;
        private string jsonurl;

        private TableHeader metadata;
        private string json;

        //Given a valid BMS table link, download the json of the table
        public BMSTable(string url)
        {
            tableurl = url;

            //Main table contains a reference meta tag pointing to a header json
            HtmlWeb htmlclient = new HtmlWeb();
            HtmlDocument table = htmlclient.Load(tableurl);

            string jsonheader = "";
            foreach (HtmlNode node in table.DocumentNode.SelectNodes("//meta"))
            {
                if(node.Attributes["name"] != null && node.Attributes["name"].Value == "bmstable")
                    jsonheader = node.Attributes["content"].Value;
            }

            if(jsonheader == "")
                throw new Exception("Error: table url is invalid");
            
            headerurl = constructURL(tableurl, jsonheader);

            WebClient client = new WebClient();
            string jsonheaderdata = client.DownloadString(headerurl);

            metadata = JsonConvert.DeserializeObject<TableHeader>(jsonheaderdata);

            //Header json contains an entry pointing to the main json
            jsonurl = constructURL(tableurl, metadata.data_url);

            json = client.DownloadString(jsonurl);
        }

        //Updates the table by redownloading all of the info
        public void UpdateTable()
        {
            //Redownload metadata
            WebClient client = new WebClient();
            string jsonheaderdata = client.DownloadString(headerurl);
            metadata = JsonConvert.DeserializeObject<TableHeader>(jsonheaderdata);

            //Redownload table
            jsonurl = constructURL(tableurl, metadata.data_url);
            json = client.DownloadString(jsonurl);
        }

        //Some sites may only link the name of the json header/table json, so we must construct the url ourselves
        private string constructURL(string url, string newsection)
        {
            if(!newsection.Contains("/"))
            {
                //the +1 allows us to include the slash
                return url.Substring(0, url.LastIndexOf('/')+1) + newsection;
            }
            return newsection;
        }
    }
}