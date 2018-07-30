using AirportUWP.Models;
using AirportUWP.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace AirportUWP.ViewModels
{
    public class StewDetailViewModel : BaseViewModel
    {
        private Stewardesses _model;
        private INavigationService _navigationService;
        private IStewardesses service;

        public StewDetailViewModel(INavigationService navigationService, IStewardesses service)
        {
            _model = new Stewardesses();
            _navigationService = navigationService;
            this.service = service;
            Title = "Student Details";

            GoBackCommand = new RelayCommand(goBack);
            DeleteCommand = new RelayCommand(del);
            SaveCommand = new RelayCommand(save);

            MessengerInstance.Register<Stewardesses>(this, m =>
            {
                _model = m;
                RaisePropertyChanged(() => Model.Id);
                RaisePropertyChanged(() => Model.FirstName);
                RaisePropertyChanged(() => Model.SecondName);
                RaisePropertyChanged(() => Model.BirthDay);
                RaisePropertyChanged(() => Model.CrewModelId);
            });
        }

        public Stewardesses Model
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
