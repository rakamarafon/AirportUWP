using AirportUWP.Interfaces;
using AirportUWP.Services;
using AirportUWP.ViewModels;
using AirportUWP.Views;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace AirportUWP
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
            navigationService.Configure(nameof(MainViewModel), typeof(MainPage));
            navigationService.Configure(nameof(PilotsViewModel), typeof(PilotsView));
            navigationService.Configure(nameof(PilotDetailViewModel), typeof(PilotDetailView));
            navigationService.Configure(nameof(StewardessesViewModel), typeof(StewardessesView));
            navigationService.Configure(nameof(StewDetailViewModel), typeof(StewDetailView));
            navigationService.Configure(nameof(CrewsViewModel), typeof(CrewsView));
            navigationService.Configure(nameof(CrewDetailViewModel), typeof(CrewDetailView));
            navigationService.Configure(nameof(AirTypesViewModel), typeof(AirTypesView));
            navigationService.Configure(nameof(AirTypeDetailViewModel), typeof(AirTypeDetailView));
            navigationService.Configure(nameof(AircraftsViewModel), typeof(AircraftsView));
            navigationService.Configure(nameof(AircraftDetailViewModel), typeof(AircraftsDetailView));


            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PilotDetailViewModel>();
            SimpleIoc.Default.Register<PilotsViewModel>();
            SimpleIoc.Default.Register<StewardessesViewModel>();
            SimpleIoc.Default.Register<StewDetailViewModel>();
            SimpleIoc.Default.Register<CrewsViewModel>();
            SimpleIoc.Default.Register<CrewDetailViewModel>();
            SimpleIoc.Default.Register<AirTypesViewModel>();
            SimpleIoc.Default.Register<AirTypeDetailViewModel>();
            SimpleIoc.Default.Register<AircraftsViewModel>();
            SimpleIoc.Default.Register<AircraftDetailViewModel>();


            SimpleIoc.Default.Register<IPilot, PilotService>();
            SimpleIoc.Default.Register<IStewardesses, StewardessesService>();
            SimpleIoc.Default.Register<ICrew, CrewService>();
            SimpleIoc.Default.Register<IAirType, AirTypeService>();
            SimpleIoc.Default.Register<IAircraft, AircraftService>();


            ServiceLocator.Current.GetInstance<PilotDetailViewModel>();
            ServiceLocator.Current.GetInstance<StewDetailViewModel>();
            ServiceLocator.Current.GetInstance<CrewDetailViewModel>();
            ServiceLocator.Current.GetInstance<AirTypeDetailViewModel>();
            ServiceLocator.Current.GetInstance<AircraftDetailViewModel>();
        }
        public MainViewModel MainVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public PilotsViewModel PilotsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PilotsViewModel>();
            }
        }

        public PilotDetailViewModel PilotDetailVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PilotDetailViewModel>();
            }
        }

        public StewardessesViewModel StewardessesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StewardessesViewModel>();
            }
        }

        public StewDetailViewModel StewDetailVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StewDetailViewModel>();
            }
        }

        public CrewsViewModel CrewsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CrewsViewModel>();
            }
        }

        public CrewDetailViewModel CrewDetailVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CrewDetailViewModel>();
            }
        }

        public AirTypesViewModel AirTypesVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AirTypesViewModel>();
            }
        }

        public AirTypeDetailViewModel AirTypeDetailVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AirTypeDetailViewModel>();
            }
        }

        public AircraftsViewModel AirCraftsVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AircraftsViewModel>();
            }
        }
        public AircraftDetailViewModel AirCraftDetailVMInstance
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AircraftDetailViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
