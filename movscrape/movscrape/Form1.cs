// Mac Armstrong
// Movie Time Scraper
// 12/6/21

using HtmlAgilityPack;
using System;
using System.Diagnostics;
using System.Web;
using System.Windows.Forms;

namespace movscrape
{
    public partial class Form1 : Form
    { 

        public Form1()
        {
            InitializeComponent();
        }


        // any local harkins location you choose from the list on their site will work but i have
        // https://www.harkins.com/locations/scottsdale-101-14 and https://www.harkins.com/locations/shea-14
        // as the default link already set up in the textbox for your convenince :)


        private void button1_Click(object sender, EventArgs e)
        {
            ScrapeData1(TBPN1.Text); // takes link user input and scrapes parts used Scraper functions
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScrapeData2(TBPN2.Text); // takes link user input and scrapes parts used in Scraper functions
        }


        //
        // i moved everything from "Scraper.cs" to the same class in order to put elements onto ListBoxes
        //

        // variables used to show on listbox
        public string[] titles;
        public string time;

        // the function to both gather the info and put it into the listbox
        public void ScrapeData1(string page)
        {
            // takes web page info 
            var web = new HtmlWeb();
            var doc = web.Load(page);

            // uses classes from site 
            var articles = doc.DocumentNode.SelectSingleNode("//*[@class = 'movies']");
            var movielist = articles.SelectNodes("//*[@class = 'col-full movie-wrapper']");

            foreach (var movie in movielist)
            {
                // title of movies 
                string[] title = movie.Element("h2").InnerText.Trim().Split('\n');

                // the time of each movie 
                string time = HttpUtility.HtmlDecode(movie.SelectSingleNode(".//ul[@class = 'showtimes']").InnerText.Replace("\n", String.Empty).Replace(" ", String.Empty));
                LB1.Items.Add(title[0]);
                foreach(String elm in time.Split('M'))
                {
                    if (elm.Equals(""))
                    {
                        LB1.Items.Add("\n");
                        continue;
                    }
                    LB1.Items.Add(elm +'M');
                }
                Console.WriteLine(title[0]);
                Console.WriteLine(time); // they wont look clean in the console but each movie will have the right time to show 
            }
        }

        // literally does the same thing but in the other listbox
        public void ScrapeData2(string page)
        {
            // takes web page info 
            var web = new HtmlWeb();
            var doc = web.Load(page);

            // uses classes from site 
            var articles = doc.DocumentNode.SelectSingleNode("//*[@class = 'movies']");
            var movielist = articles.SelectNodes("//*[@class = 'col-full movie-wrapper']");

            foreach (var movie in movielist)
            {
                // title of movies 
                string[] title = movie.Element("h2").InnerText.Trim().Split('\n');

                // the time of each movie 
                string time = HttpUtility.HtmlDecode(movie.SelectSingleNode(".//ul[@class = 'showtimes']").InnerText.Replace("\n", String.Empty).Replace(" ", String.Empty));
                LB2.Items.Add(title[0]);
                foreach (String elm in time.Split('M'))
                {
                    if (elm.Equals(""))
                    {
                        LB2.Items.Add("\n");
                        continue;
                    }
                    LB2.Items.Add(elm + 'M');
                }
                Console.WriteLine(title[0]);
                Console.WriteLine(time); // they wont look clean in the console but each movie will have the right time to show 
            }
        }
    }
}
