using AirportUWP.Interfaces;
using AirportUWP.Models;
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
    public class AircraftDetailViewModel : BaseViewModel
    {
        private Aircraft _model;
        private INavigationService _navigationService;
        private IAircraft service;

        public AircraftDetailViewModel(INavigationService navigationService, IAircraft service)
        {
            _model = new Aircraft();
            _navigationService = navigationService;
            this.service = service;
            Title = "Aircraft Details";

            GoBackCommand = new RelayCommand(goBack);
            DeleteCommand = new RelayCommand(del);
            SaveCommand = new RelayCommand(save);

            MessengerInstance.Register<Aircraft>(this, m =>
            {
                _model = m;
                RaisePropertyChanged(() => Model.Id);
                RaisePropertyChanged(() => Model.Name);
                RaisePropertyChanged(() => Model.AirTypeModelId);
                RaisePropertyChanged(() => Model.ReleaseDate);
                RaisePropertyChanged(() => Model.LifeTime);
            });
        }

        public Aircraft Model
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
