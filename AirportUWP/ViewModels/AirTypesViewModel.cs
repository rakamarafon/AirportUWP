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
    public class AirTypesViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IAirType service;

        private async Task Load()
        {
            this.AirTypes = new ObservableCollection<AirType>(await service.Get());

            RaisePropertyChanged(nameof(Stewardesses));
        }

        public AirTypesViewModel(INavigationService navigationService, IAirType service)
        {
            _navigationService = navigationService;
            this.service = service;
            AirTypes = new ObservableCollection<AirType>();
            CreateCommand = new RelayCommand(create);
            SearchCommand = new RelayCommand(search);
            Load().GetAwaiter();
            MessengerInstance.Register<AirType>(this, m =>
            {
                Load().GetAwaiter();
            });
        }

        public ObservableCollection<AirType> AirTypes { get; private set; }

        private AirType _selectedAirType;
        public AirType SelectedAirType
        {
            get { return _selectedAirType; }
            set
            {
                _selectedAirType = value;
                if (_selectedAirType != null)
                {
                    MessengerInstance.Send(_selectedAirType);
                    _navigationService.NavigateTo(nameof(AirTypeDetailViewModel));
                }
                RaisePropertyChanged(() => SelectedAirType);
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
            AirTypes.Clear();
            if (string.IsNullOrWhiteSpace(SearchFilter))
            {
                foreach (var airT in await service.Get())
                {
                    AirTypes.Add(airT);
                }
            }
            else
            {
                var temp = await service.Get();
                foreach (var airT in temp.Where(s => s.Model.StartsWith(SearchFilter, StringComparison.CurrentCultureIgnoreCase)
                                            || s.SeatsNumber.ToString().StartsWith(SearchFilter, StringComparison.CurrentCultureIgnoreCase)))
                {
                    AirTypes.Add(airT);
                }
                foreach (var airT in temp.Where(x => x.FlightDataModelId.ToString().StartsWith(SearchFilter)))
                {
                    AirTypes.Add(airT);
                }
            }
        }

        public ICommand CreateCommand { get; set; }

        private void create()
        {
            MessengerInstance.Send(new AirType());
            _navigationService.NavigateTo(nameof(AirTypeDetailViewModel));
        }
    }
}
