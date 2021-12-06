using HtmlAgilityPack;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Web;

namespace cryptowebscraper
{
    public class Scraper
    {

        private ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();

        public ObservableCollection<EntryModel> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }

        public void ScrapeData(string page)
        {
            // takes web page info 
            var web = new HtmlWeb();
            var doc = web.Load(page);

            // uses classes from assets 
            var articles = doc.DocumentNode.SelectNodes("//*[@class = '_2mHoLKk1EmQ90Hj2VxwVKC _2cEwIPLxNCKyZSBxk7MyUQ Q0Cxwokka8qzW-qAyjdq6 pointer']");

            foreach (var article in articles)
            {
                // header is the name of the coins being recorded
                var header = HttpUtility.HtmlDecode(article.SelectSingleNode(".//div[@class = 'text-left truncate _1hazOxgsUXq0rb-UgDZwNp _1GdBC6rgsSADLryaaGeEuX w8u1-Ks6zzfWwPQ23ywUj _36FIyjphKz71izCg1N-Uks']").InnerText);

                // price is the price of each cion being recorded
                var price = HttpUtility.HtmlDecode(article.SelectSingleNode(".//div[@class = 'text-right _1hazOxgsUXq0rb-UgDZwNp LNc8C7U5Q_4hVq8G7HQHa _36FIyjphKz71izCg1N-Uks overflow-visible']").InnerText);

                // this is used to show in console
                Debug.Print(header);
                Debug.Print(price);

                // only takes the names here to record instead of evertyhing 
                if (header == "Bitcoin" || header == "Ethereum" || header == "Solana" || header == "Litecoin" || header == "ChainLink") 
                {
                    // adds each coin name and price to EntryModel
                    _entries.Add(new EntryModel { Title = header, Price = price });
                }
                else // if not one of the names
                {
                    continue;
                }
                
            }
        }
    }
}
