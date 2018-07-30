using AirportUWP.Models;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using AirportUWP.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Linq;
using System;

namespace AirportUWP.ViewModels
{
    public class PilotsViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IPilot service;

        private async Task Load()
        {
            this.Pilots = new ObservableCollection<Pilot>(await service.Get());

            RaisePropertyChanged(nameof(Pilots));
        }
        public PilotsViewModel(INavigationService navigationService, IPilot service)
        {
            _navigationService = navigationService;
            this.service = service;
            SearchCommand = new RelayCommand(search);
            CreateCommand = new RelayCommand(create);
            Pilots = new ObservableCollection<Pilot>();
            MessengerInstance.Register<Pilot>(this, m =>
            {
                Load();
            });
            Load();
        }
    
        public ObservableCollection<Pilot> Pilots { get; private set; }

        private Pilot _selectedPilot;
        public Pilot SelectedPilot
        {
            get { return _selectedPilot; }
            set
            {
                _selectedPilot = value;
                if (_selectedPilot != null)
                {
                    MessengerInstance.Send(_selectedPilot);
                    _navigationService.NavigateTo(nameof(PilotDetailViewModel));
                }
                RaisePropertyChanged(() => SelectedPilot);
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
            Pilots.Clear();
            if (string.IsNullOrWhiteSpace(SearchFilter))
            {
                foreach (var pilot in await service.Get())
                {
                    Pilots.Add(pilot);
                }
            }
            else
            {
                var temp = await service.Get();
                foreach (var pilot in temp.Where(s => s.FirstName.StartsWith(SearchFilter, StringComparison.CurrentCultureIgnoreCase)
                                            || s.SecondName.StartsWith(SearchFilter, StringComparison.CurrentCultureIgnoreCase)))
                {
                    Pilots.Add(pilot);
                }
                foreach (var pilot in temp.Where(x => x.Experience.ToString().StartsWith(SearchFilter)))
                {
                    Pilots.Add(pilot);
                }
            }
        }

        public ICommand CreateCommand { get; set; }

        private void create()
        {
            MessengerInstance.Send(new Pilot());
            _navigationService.NavigateTo(nameof(PilotDetailViewModel));
        }
    }
}
