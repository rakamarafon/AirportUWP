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
    public class CrewsViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private ICrew service;

        private async Task Load()
        {
            this.Crews = new ObservableCollection<Crew>(await service.Get());

            RaisePropertyChanged(nameof(Crews));
        }
        public CrewsViewModel(INavigationService navigationService, ICrew service)
        {
            _navigationService = navigationService;
            this.service = service;
            CreateCommand = new RelayCommand(create);
            Crews = new ObservableCollection<Crew>();
            Load().GetAwaiter();
            MessengerInstance.Register<Crew>(this, m => 
            {
                Load().GetAwaiter();
            });
        }

        public ObservableCollection<Crew> Crews { get; private set; }

        private Crew _selectedCrew;
        public Crew SelectedCrew
        {
            get { return _selectedCrew; }
            set
            {
                _selectedCrew = value;
                if (_selectedCrew != null)
                {
                    MessengerInstance.Send(_selectedCrew);
                    _navigationService.NavigateTo(nameof(CrewDetailViewModel));
                }
                RaisePropertyChanged(() => SelectedCrew);
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
            Crews.Clear();
            if (string.IsNullOrWhiteSpace(SearchFilter))
            {
                foreach (var pilot in await service.Get())
                {
                    Crews.Add(pilot);
                }
            }
        }

        public ICommand CreateCommand { get; set; }

        private async void create()
        {
           await service.Create(new Crew());
            await Load();
        }
    }
}
