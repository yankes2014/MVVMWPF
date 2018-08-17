using Kino.UI.Command;
using Kino.UI.Event;
using Kino.UI.ViewModel.Interfaces;
using Kino.UI.Views;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Regions;

namespace Kino.UI.ViewModel
{
    public class MainWindowViewModel : BaseViewModel, IMainWindowViewModel
    {
        private string selectedView;

        public string SelectedView
        {
            get { return selectedView; }
            set { selectedView = value;
                OnPropertyChanged();
            }
        }

        private string _selectedFilm;
        public string SelectedFilm
        {
            get { return _selectedFilm; }
            set
            {
                _eventAggregator.GetEvent<RefreshDataEvent>()
                    .Publish(value.Replace("System.Windows.Controls.ComboBoxItem: ", ""));
                _selectedFilm = value.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            }
        }
        public RelayCommand ShowSlots { get; set; }
        public RelayCommand ShowFreeSlots { get; set; }
        public RelayCommand AboutFilm { get; set; }

        private IUnityContainer _unityContainer;
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;

        public MainWindowViewModel(IUnityContainer unityContainer, IRegionManager regionManager, IEventAggregator eventAggregator)
        {

            _unityContainer = unityContainer;
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;

            ShowSlots = new RelayCommand(OnSlotsClick, CanClick);
            ShowFreeSlots = new RelayCommand(OnFreeSlotsClick, CanClick);
            AboutFilm = new RelayCommand(OnAboutFilmClick, CanClick);

            SelectedView = "Pokaz miejsca";
        }

        private bool CanClick(object obj)
        {
            return true;
        }

        private void OnSlotsClick(object obj)
        {
            SelectedView = "Pokaz miejsca";
            _regionManager.Regions["PanelRegion"].Activate(_unityContainer.Resolve<AdminView>());
        }

        private void OnFreeSlotsClick(object obj)
        {
            SelectedView = "Pokaz wolne";
            _regionManager.Regions["PanelRegion"].Activate(_unityContainer.Resolve<SlotsView>());
        }

        private void OnAboutFilmClick(object obj)
        {
            SelectedView = "Informacje o repertuarze";
            _regionManager.Regions["PanelRegion"].Activate(_unityContainer.Resolve<FilmsView>());
        }

    }
}
