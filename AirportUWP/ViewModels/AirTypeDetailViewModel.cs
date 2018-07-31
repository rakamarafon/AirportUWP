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
    public class AirTypeDetailViewModel : BaseViewModel
    {
        private AirType _model;
        private INavigationService _navigationService;
        private IAirType service;

        public AirTypeDetailViewModel(INavigationService navigationService, IAirType service)
        {
            _model = new AirType();
            _navigationService = navigationService;
            this.service = service;
            Title = "AirType Details";

            GoBackCommand = new RelayCommand(goBack);
            DeleteCommand = new RelayCommand(del);
            SaveCommand = new RelayCommand(save);

            MessengerInstance.Register<AirType>(this, m =>
            {
                _model = m;
                RaisePropertyChanged(() => Model.Id);
                RaisePropertyChanged(() => Model.Model);
                RaisePropertyChanged(() => Model.SeatsNumber);
                RaisePropertyChanged(() => Model.FlightDataModelId);
            });
        }

        public AirType Model
        {
            get => _model;
            set => _model = value;
        }

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

        public ICommand SaveCommand { get; set; }

        private async void save()
        {
            if (_model.Id == 0)
            {
                await service.Create(_model);
                MessengerInstance.Send(_model);
                goBack();
            }
            else
            {
                await service.Update(_model);
                MessengerInstance.Send(_model);
                goBack();
            }
        }
    }
}
