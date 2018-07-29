using AirportUWP.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace AirportUWP.ViewModels
{
    public class PilotDetailViewModel : BaseViewModel
    {
        private Pilot _model;
        private INavigationService _navigationService;

        public PilotDetailViewModel(INavigationService navigationService)
        {
            _model = new Pilot();
            _navigationService = navigationService;

            Title = "Student Details";

            GoBackCommand = new RelayCommand(goBack);

            MessengerInstance.Register<Pilot>(this, student =>
            {
                _model = student;
                RaisePropertyChanged(() => Id);
                RaisePropertyChanged(() => FirstName);
                RaisePropertyChanged(() => LastName);
                RaisePropertyChanged(() => BirthDate);
                RaisePropertyChanged(() => Experiance);
                RaisePropertyChanged(() => BirthDate);
                RaisePropertyChanged(() => Experiance);
            });
        }

        public int Id => _model.Id;
        public string FirstName => _model.FirstName;

        public string LastName => _model.SecondName;
      
        public string BirthDate => _model.Birthday;

        public int Experiance => _model.Experience;
        public int CrewModelId => _model.CrewModelId;

        public ICommand GoBackCommand { get; set; }

        private void goBack()
        {
            _navigationService.GoBack();
        }
    }
}
