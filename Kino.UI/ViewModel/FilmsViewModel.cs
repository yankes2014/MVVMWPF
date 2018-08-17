using Kino.Services.Interfaces;
using Kino.UI.Event;
using Kino.UI.ViewModel.Interfaces;
using Prism.Events;

namespace Kino.UI.ViewModel
{
    /// <summary>
    /// Shows informations about repertuar
    /// </summary>
    public class FilmsViewModel : BaseViewModel, IFilmsViewModel
    {
        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private IFilmService _filmService;
        private IEventAggregator _eventAggregator;
        public FilmsViewModel(IFilmService filmService, IEventAggregator eventAggregator)
        {
            _filmService = filmService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<RefreshDataEvent>().Subscribe(refreshView);

        }

        private async void refreshView(string obj)
        {
            var x = await _filmService.GetFilm(obj);
            Description = x.Description;
            Title = x.Tytul;
            OnPropertyChanged();
        }
    }
}
