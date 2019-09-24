using System;
using CalendarApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CalendarApp.Data;
using CalendarApp.View;
using Xamarin.Forms;

namespace CalendarApp.ViewModel
{
    public class EventsListViewModel : INotifyPropertyChanged
    {
        EventsDatabase _eventsDatabase = new EventsDatabase();

        private INavigation _navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<EventsModel> _eventsList;

        public ObservableCollection<EventsModel> EventsList
        {
            get { return _eventsList; }
            set
            {
                _eventsList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EventsList"));
            }
        }

        private EventsModel _eventSelected;

        public EventsModel EventSelected
        {
            get { return _eventSelected; }
            set
            {
                if (_eventSelected != value)
                {
                    _eventSelected = value;
                    if (_eventSelected != null)
                    {
                        _navigation.PushAsync(new EventDetailsPage(_eventSelected));
                    }
                }
            }
        }

        public async Task FetchDataAsync()
        {

            var list = await _eventsDatabase.GetAllEventsAsync();
            EventsList = new ObservableCollection<EventsModel>(list);
        }

        public EventsListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            FetchDataAsync();
        }
        public EventsListViewModel()
        {
            FetchDataAsync();
        }
    }
}
