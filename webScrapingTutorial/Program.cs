using System;
using System.Linq;

namespace webScrapingTutorial
{
    class Program
    {
        private const String url = "https://www.supremenewyork.com/shop/all/sweatshirts";

        static void Main(string[] args)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            getTitles(doc);
        }

        static void getTitles(HtmlAgilityPack.HtmlDocument doc){

            // '/a' - search for the anchor tag
            // '@class' - define what class you're looking for
            var items = doc.DocumentNode.SelectNodes("//a[@class='name-link']").ToList();

            // Iterate through the list above and output it
            foreach (var item in items)
            {
                Console.WriteLine(item.InnerText);
            }
        }
    }
}
