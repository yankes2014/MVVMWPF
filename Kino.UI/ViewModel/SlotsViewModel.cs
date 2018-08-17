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
    /// Shows free slots for repertuar and enable reserve slot
    /// </summary>
    public class SlotsViewModel : BaseViewModel, ISlotsViewModel
    {
        private ISlotService _slotService;
        private IEventAggregator _eventAggregator;
        private string tytul;

        private Slot selectedSlot;

        public Slot SelectedSlot
        {
            get { return selectedSlot; }
            set
            {
                selectedSlot = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SendReservation { get; set; }
        public ObservableCollection<Slot> slotList { get; set; }

        CollectionView view;


        public SlotsViewModel(ISlotService slotService, IEventAggregator eventAggregator)
        {
            _slotService = slotService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<RefreshDataEvent>().Subscribe(refreshView);
            slotList = new ObservableCollection<Slot>();
            view = (CollectionView)CollectionViewSource.GetDefaultView(slotList);
            SendReservation = new RelayCommand(OnSendReservationClick, CanClick);

        }

        private bool CanClick(object obj)
        {
            return selectedSlot != null;
        }

        private async void OnSendReservationClick(object obj)
        {
            selectedSlot.IsFree = false;
            await _slotService.UpdateSLot(selectedSlot);
            _eventAggregator.GetEvent<RefreshDataEvent>()
                   .Publish(tytul);

        }


        private async void refreshView(string obj)
        {
            tytul = obj;
            slotList.Clear();
            var x = await _slotService.GetFreeSlotsAsync(obj);

            foreach (var item in x)
            {
                slotList.Add(item);
            }
        }
    }
}
