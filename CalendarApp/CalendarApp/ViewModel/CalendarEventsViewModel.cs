using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CalendarApp.Data;
using CalendarApp.View;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace CalendarApp.ViewModel
{
    public class CalendarEventsViewModel
    {
        CalendarEventsDatabase _calendarEventsDatabase = new CalendarEventsDatabase();
        private INavigation _navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CalendarInlineEvent> _calendarEventsList;

        public ObservableCollection<CalendarInlineEvent> CalendarEventsList
        {
            get { return _calendarEventsList; }
            set
            {
                _calendarEventsList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CalendarEventsList"));
            }
        }

        public async Task FetchDataAsync()
        {

            var list = await _calendarEventsDatabase.GetAllCalEventsAsync();
            CalendarEventsList = new ObservableCollection<CalendarInlineEvent>(list);
        }

        public CalendarEventsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            FetchDataAsync();
        }

        public CalendarEventsViewModel()
        {
            FetchDataAsync();
        }
    }
}
