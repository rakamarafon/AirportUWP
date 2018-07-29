using GalaSoft.MvvmLight;

namespace AirportUWP.ViewModels
{
    public class BaseViewModel: ViewModelBase
    {
        private string _title;
        private string _manu_text;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }        

        public string MenuText
        {
            get { return _manu_text; }
            set
            {
                _manu_text = value;
                RaisePropertyChanged(() => Title);
            }
        }
    }
}
