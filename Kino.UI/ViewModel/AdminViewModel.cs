using Kino.Model;
using Kino.Services.Interfaces;
using Kino.UI.Command;
using Kino.UI.Event;
using Kino.UI.ViewModel.Interfaces;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Kino.UI.ViewModel
{
    /// <summary>
    /// Shows all slots for repertuar
    /// </summary>
    public class AdminViewModel : BaseViewModel, IAdminViewModel
    {
        private string tytul;
        private string _choosenFilm;

        public string ChoosenFilm
        {
            get { return _choosenFilm; }
            set
            {
                _choosenFilm = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Slot> allSlotList { get; set; }
        public RelayCommand ClearReservation { get; set; }

        CollectionView view;
        private ISlotService _slotService;
        private IEventAggregator _eventAggregator;
        public AdminViewModel(IEventAggregator eventAggregator, ISlotService slotService)
        {
            _eventAggregator = eventAggregator;
            _slotService = slotService;
            _eventAggregator.GetEvent<RefreshDataEvent>().Subscribe(refreshView);

            allSlotList = new ObservableCollection<Slot>();
            view = (CollectionView)CollectionViewSource.GetDefaultView(allSlotList);
            ClearReservation = new RelayCommand(OnClearReservationClick, CanClick);

        }

        private bool CanClick(object obj)
        {
            return true;
        }

        private async void OnClearReservationClick(object obj)
        {
            foreach (var item in allSlotList)
            {
                item.IsFree = true;
                item.Username = null;
                await _slotService.UpdateSLot(item);

            }
            _eventAggregator.GetEvent<RefreshDataEvent>()
                   .Publish(tytul);
        }

        private async void refreshView(string obj)
        {
            tytul = obj;
            ChoosenFilm = obj;
            var x = await _slotService.GetSlotsAsync(obj);
            allSlotList.Clear();

            foreach (var item in x)
            {
                allSlotList.Add(item);
            }
        }
    }
}
