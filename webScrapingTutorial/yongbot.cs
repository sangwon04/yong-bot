using System;
using System.Linq;
using System.Collections.Generic;

namespace webScrapingTutorial
{

    /* TODO
     * - [Jacob] Search by keyword across all pages (e.g. box logo across tshirt, 
     *   sweaters, etc.
     * - Add to cart func with delay
     * - Checkout func with delay
     * - Payment func
     * - Retry func with delay
     * - Security (encrypting CCs, PII)
     * - Job scheduling func
     */

    class yongbot
    {
        /* List to hold categories. These values will be a drop-down list in the
         * GUI.
        */
        private static List<string> urlCat = new List<string>
        {
            "all", "new", "all/jackets", "all/shirts", "all/tops/sweaters",
            "all/sweatshirts", "all/pants", "all/hats", "all/bags",
            "all/accessories", "all/skate"
        };

        // Final URL to search in
        private static String url = "https://www.supremenewyork.com/shop/";

       static void Main(string[] args){
            craftUrl();
        }

        static void craftUrl(){
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

            /* Hardcoded for now but will be replaced by user-input via
             * drop-down menu in the GUI
            */
            url += "all/sweatshirts";
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);
            getItems(doc, getKeyword());
        }

        static string getKeyword(){
            Console.Write("Keyword: ");
            return Console.ReadLine().ToLower();
        }

        static void getItems(HtmlAgilityPack.HtmlDocument doc, string keyword){

            Console.WriteLine("Searching in: " + url);
            Console.WriteLine("Searching for: " + keyword + "\n");

            // '//a' - search for the anchor tag
            // '@class' - define what class you're looking for
            var items = doc.DocumentNode.SelectNodes("//a[@class='name-link']")
                           .ToList();

            // Iterate through the list above and output it
            foreach (var item in items)
            {
                if (item.InnerText.ToLower().Contains(keyword)){
                    //Console.WriteLine(item.InnerText.ToLower());
                    Console.WriteLine(doc.DocumentNode
                           .SelectNodes("//a[@class='name-link']")
                           .Descendants("a")
                           .Select(node => node.GetAttributeValue("href", ""))
                           .ToString());
                }

            }
        }
    }
}
