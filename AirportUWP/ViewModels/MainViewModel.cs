using GalaSoft.MvvmLight.Views;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace AirportUWP.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Airport";
            MenuText = "Main";
        }       

        public ICommand HamburegerCommand { get; set; }

        private void hamburger()
        {
           
        }
    }
}
