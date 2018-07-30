using AirportUWP.Models;
using AirportUWP.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirportUWP.ViewModels
{
    public class CrewDetailViewModel : BaseViewModel
    {
        private Crew _model;
        private INavigationService _navigationService;
        private ICrew service;

        public CrewDetailViewModel(INavigationService navigationService, ICrew service)
        {
            _model = new Crew();
            _navigationService = navigationService;
            this.service = service;
            Title = "Crew Details";

            GoBackCommand = new RelayCommand(goBack);
            DeleteCommand = new RelayCommand(del);

            MessengerInstance.Register<Crew>(this, m =>
            {
                _model = m;
                RaisePropertyChanged(() => Id);
            });
        }

        public int Id => _model.Id;

        public ICommand GoBackCommand { get; set; }

        private void goBack()
        {
            _navigationService.GoBack();
        }

        public ICommand DeleteCommand { get; set; }

        private async void del()
        {
            await service.Delete(_model.Id);
            MessengerInstance.Send(_model);
            goBack();
        }
    }
}
