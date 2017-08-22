using System;
using System.Net;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace BMSTableManager
{
    //Given a valid BMS table link, download the json of the table
    public class TableDownloader
    {
        public TableDownloader(string url)
        {
            //Main table contains a reference meta tag pointing to a header json
            HtmlWeb htmlclient = new HtmlWeb();
            HtmlDocument table = htmlclient.Load(url);

            string jsonheader = "";
            foreach (HtmlNode node in table.DocumentNode.SelectNodes("//meta"))
            {
                if(node.Attributes["name"] != null && node.Attributes["name"].Value == "bmstable")
                    jsonheader = node.Attributes["content"].Value;
            }

            if(jsonheader == "")
                throw new Exception("Error: table url is invalid");

            //Some sites may only link the name of the json header, so we must construct the url ourselves
            if(!jsonheader.Contains("/"))
            {
                //the +1 allows us to include the slash
                jsonheader = url.Substring(0, url.LastIndexOf('/')+1) + jsonheader;
            }

            WebClient client = new WebClient();
            string jsonheaderdata = client.DownloadString(jsonheader);

            TableHeader header = JsonConvert.DeserializeObject<TableHeader>(jsonheaderdata);

            //Some sites may only link the name of the json, so we must construct the url ourselves
            if(!header.data_url.Contains("/"))
            {
                //the +1 allows us to include the slash
                header.data_url = url.Substring(0, url.LastIndexOf('/')+1) + header.data_url;
            }

            string jsonstring = client.DownloadString(header.data_url);
        }
    }
}