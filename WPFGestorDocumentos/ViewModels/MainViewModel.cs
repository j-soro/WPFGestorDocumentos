using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGestorDocumentos.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand UserCollectionsViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }
        public DiscoveryViewModel DiscoveryVm { get; set; }
        public UserCollectionsViewModel UserCollectionsVm { get; set; }
        
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            DiscoveryVm = new DiscoveryViewModel();
            UserCollectionsVm = new UserCollectionsViewModel();
            CurrentView = UserCollectionsVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVm;
            });

            UserCollectionsViewCommand = new RelayCommand(o =>
            {
                CurrentView = UserCollectionsVm;
            });

        }
    }
}
