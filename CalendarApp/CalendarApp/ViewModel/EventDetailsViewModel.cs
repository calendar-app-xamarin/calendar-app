using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CalendarApp.Model;

namespace CalendarApp.ViewModel
{
    public class EventDetailsViewModel : INotifyPropertyChanged

    {
        public EventDetailsViewModel()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private EventsModel _event;
        public EventsModel Event
        {
            set { SetProperty(ref _event, value); }
            get { return _event; }
        }

        public void SetData(EventsModel finalEvent)
        {
            Event = finalEvent;
        }
    }
}
