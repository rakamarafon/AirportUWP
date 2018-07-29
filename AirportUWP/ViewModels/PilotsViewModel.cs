using AirportUWP.Models;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using AirportUWP.Services;

namespace AirportUWP.ViewModels
{
    public class PilotsViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IPilot service;

        public PilotsViewModel(INavigationService navigationService, IPilot service)
        {
            _navigationService = navigationService;
            this.service = service;
            Pilots = new ObservableCollection<Pilot>();

            Pilots =  (ObservableCollection<Pilot>)service.Get().Result;
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
    }
}
