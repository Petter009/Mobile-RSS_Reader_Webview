using System.Xml;
using System;
using System.Collections.Generic;
using System.Net;

namespace GiveMeAName.Model
{
    public static class NewsService
    {
        public static IList<NewsDetail> list = new List<NewsDetail>();
        public static IList<NewsDetail> LoadData()
        {
            using (var webClient = new WebClient())
            {
                string xmlUrl = "https://www.dr.dk/nyheder/service/feeds/allenyheder";
                string xmlString = webClient.DownloadString(xmlUrl);
                XmlDocument document = new XmlDocument();
                document.LoadXml(xmlString);

                XmlNodeList nodeList = document.SelectNodes("rss/channel/item");

                foreach (XmlNode item in nodeList)
                {
                    NewsDetail news = new NewsDetail();
                    news.Title = item["title"].InnerText;
                    news.PubDate = DateTime.Parse(item["pubDate"].InnerText);
                    news.Link = item["link"].InnerText;
                    list.Add(news);
                }
            }
            return list;
        }
    }
}
