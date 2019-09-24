using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MarcTron.Plugin;
using SQLite;
using CalendarApp.Model;
using CalendarApp.Data;
using CalendarApp.ViewModel;
using Syncfusion.SfCalendar.XForms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Globalization;

namespace CalendarApp.View
{
    public partial class CalendarPage : ContentPage
    {
        EventsListViewModel eventsListViewModel = new EventsListViewModel();
        public ObservableCollection<EventsModel> EventsList;
        EventsDatabase eventsDatabase = new EventsDatabase();
        public CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();
        public CalendarPage()
        {
            InitializeComponent();
            FillEvents();
        }

        public async Task FetchDataAsync()
        {

            var list = await eventsDatabase.GetAllEventsAsync();
            EventsList = new ObservableCollection<EventsModel>(list);
        }

        public void FillEvents()
        {
            EventsList = eventsListViewModel.EventsList;
            foreach (var Event in EventsList)
            {
                DateTime StartDate = Event.EventStartDate;
                TimeSpan EventStartTime = Event.EventStartTime;
                DateTime CalendarEventStartDate = new DateTime(StartDate.Day,
                    StartDate.Month, StartDate.Year, EventStartTime.Hours, EventStartTime.Minutes, EventStartTime.Seconds);
                DateTime EndDate = Event.EventStartDate;
                TimeSpan EventEndTime = Event.EventStartTime;
                DateTime CalendarEventEndDate = new DateTime(EndDate.Day,
                    EndDate.Month, EndDate.Year, EventEndTime.Hours, EventEndTime.Minutes, EventEndTime.Seconds);
                CalendarInlineEvent event1 = new CalendarInlineEvent()
                {
                    StartTime = CalendarEventStartDate,
                    EndTime = CalendarEventEndDate,
                    Subject = Event.EventTitle + "\n" + Event.EventDescription,
                    Color = Color.Green
                };
                CalendarInlineEvents.Add(event1);
            }

            calendar.DataSource = CalendarInlineEvents;
        }
    }
}
