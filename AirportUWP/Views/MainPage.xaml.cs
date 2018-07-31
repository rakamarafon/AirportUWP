using AirportUWP.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace AirportUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            myFrame.Navigate(typeof(PilotsView));
            TitleTextBlock.Text = "Pilots";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pilots.IsSelected)
            {
                myFrame.Navigate(typeof(PilotsView));
                TitleTextBlock.Text = "Pilots";
            }
            else if (steward.IsSelected)
            {
                myFrame.Navigate(typeof(StewardessesView));
                TitleTextBlock.Text = "Stewardesses";
            }
            else if (crews.IsSelected)
            {
                myFrame.Navigate(typeof(CrewsView));
                TitleTextBlock.Text = "Crews";
            }
            else if (airtypes.IsSelected)
            {
                myFrame.Navigate(typeof(AirTypesView));
                TitleTextBlock.Text = "Air types";
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
    }
}
