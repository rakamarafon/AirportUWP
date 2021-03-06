﻿using AirportUWP.Models;
using AirportUWP.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace AirportUWP.ViewModels
{
    public class PilotDetailViewModel : BaseViewModel
    {
        private Pilot _model;
        private INavigationService _navigationService;
        private IPilot service;

        public PilotDetailViewModel(INavigationService navigationService, IPilot service)
        {
            this.service = service;
            _model = new Pilot();
            _navigationService = navigationService;

            Title = "Student Details";

            GoBackCommand = new RelayCommand(goBack);
            DeleteCommand = new RelayCommand(del);
            SaveCommand = new RelayCommand(save);

            MessengerInstance.Register<Pilot>(this, m =>
            {
                _model = m;
                RaisePropertyChanged(() => Model.Id);
                RaisePropertyChanged(() => Model.FirstName);
                RaisePropertyChanged(() => Model.SecondName);
                RaisePropertyChanged(() => Model.Birthday);
                RaisePropertyChanged(() => Model.Experience);
                RaisePropertyChanged(() => Model.CrewModelId);
            });            
        }

        public Pilot Model
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
            if(_model.Id == 0)
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
