// Mac Armstrong
// Crypto Webscraping
// 11/15/21

using System.Windows;

namespace cryptowebscraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Scraper scraper;
        public MainWindow()
        {
            InitializeComponent();
            scraper = new Scraper();
            DataContext = scraper;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // can only input https://cryptowat.ch/assets for it to work 
            scraper.ScrapeData(TBPN.Text); // takes link user input and scrapes parts used in Scraper.cs
        }
    }
}
