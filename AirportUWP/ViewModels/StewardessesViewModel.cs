using AirportUWP.Models;
using AirportUWP.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirportUWP.ViewModels
{
    public class StewardessesViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IStewardesses service;

        private async Task Load()
        {
            this.Stewardesses = new ObservableCollection<Stewardesses>(await service.Get());

            RaisePropertyChanged(nameof(Stewardesses));
        }
        public StewardessesViewModel(INavigationService navigationService, IStewardesses service)
        {
            _navigationService = navigationService;
            this.service = service;
            Stewardesses = new ObservableCollection<Stewardesses>();
            CreateCommand = new RelayCommand(create);
            Load();
            MessengerInstance.Register<Stewardesses>(this, m =>
            {
                Load();
            });
        }

        public ObservableCollection<Stewardesses> Stewardesses { get; private set; }

        private Stewardesses _selectedStewardesses;
        public Stewardesses SelectedStewardesses
        {
            get { return _selectedStewardesses; }
            set
            {
                _selectedStewardesses = value;
                if (_selectedStewardesses != null)
                {
                    MessengerInstance.Send(_selectedStewardesses);
                    _navigationService.NavigateTo(nameof(StewDetailViewModel));
                }
                RaisePropertyChanged(() => SelectedStewardesses);
            }
        }

        private string _searchFilter;
        public string SearchFilter
        {
            get { return _searchFilter; }
            set
            {
                _searchFilter = value;
                RaisePropertyChanged(() => SearchFilter);
            }
        }

        public ICommand SearchCommand { get; set; }

        private async void search()
        {
            Stewardesses.Clear();
            if (string.IsNullOrWhiteSpace(SearchFilter))
            {
                foreach (var stew in await service.Get())
                {
                    Stewardesses.Add(stew);
                }
            }
        }

        public ICommand CreateCommand { get; set; }

        private void create()
        {
            MessengerInstance.Send(new Stewardesses());
            _navigationService.NavigateTo(nameof(StewDetailViewModel));
        }

    }
}
