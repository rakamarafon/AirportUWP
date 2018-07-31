using AirportUWP.Interfaces;
using AirportUWP.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirportUWP.ViewModels
{
    public class AircraftsViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IAircraft service;

        private async Task Load()
        {
            this.AirCrafts = new ObservableCollection<Aircraft>(await service.Get());

            RaisePropertyChanged(nameof(AirCrafts));
        }

        public AircraftsViewModel(INavigationService navigationService, IAircraft service)
        {
            _navigationService = navigationService;
            this.service = service;
            AirCrafts = new ObservableCollection<Aircraft>();
            CreateCommand = new RelayCommand(create);
            SearchCommand = new RelayCommand(search);
            Load().GetAwaiter();
            MessengerInstance.Register<Aircraft>(this, m =>
            {
                Load().GetAwaiter();
            });
        }

        public ObservableCollection<Aircraft> AirCrafts { get; private set; }

        private Aircraft _selectedAirCraft;
        public Aircraft SelectedAirCraft
        {
            get { return _selectedAirCraft; }
            set
            {
                _selectedAirCraft = value;
                if (_selectedAirCraft != null)
                {
                    MessengerInstance.Send(_selectedAirCraft);
                    _navigationService.NavigateTo(nameof(AircraftDetailViewModel));
                }
                RaisePropertyChanged(() => SelectedAirCraft);
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
            AirCrafts.Clear();
            if (string.IsNullOrWhiteSpace(SearchFilter))
            {
                foreach (var air in await service.Get())
                {
                    AirCrafts.Add(air);
                }
            }
            else
            {
                var temp = await service.Get();
                foreach (var air in temp.Where(s => s.Name.StartsWith(SearchFilter, StringComparison.CurrentCultureIgnoreCase)
                                            || s.ReleaseDate.StartsWith(SearchFilter, StringComparison.CurrentCultureIgnoreCase)))
                {
                    AirCrafts.Add(air);
                }
                foreach (var air in temp.Where(x => x.LifeTime.StartsWith(SearchFilter)))
                {
                    AirCrafts.Add(air);
                }
            }
        }

        public ICommand CreateCommand { get; set; }

        private void create()
        {
            MessengerInstance.Send(new Aircraft());
            _navigationService.NavigateTo(nameof(AircraftDetailViewModel));
        }
    }
}
