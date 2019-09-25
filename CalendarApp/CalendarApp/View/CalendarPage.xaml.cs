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
        public CalendarEventCollection CalendarInlineEvents { get; set; }
        public CalendarPage()
        {
            InitializeComponent();
            BindingContext = new EventsListViewModel(Navigation);
            CalendarInlineEvents = new CalendarEventCollection();
            FillEvents();
        }

        protected override void OnAppearing()
        {
            //TODO
            //Refresh the Calendar

            calendar.Refresh();
            BindingContext = new EventsListViewModel(Navigation);
            CalendarInlineEvents = new CalendarEventCollection();
            FillEvents();
            calendar.DataSource = CalendarInlineEvents;
            calendar.Refresh();
        }

        public async Task FetchDataAsync()
        {
            var list = await eventsDatabase.GetAllEventsAsync();
            EventsList = new ObservableCollection<EventsModel>(list);
        }

        public async Task FillEvents()
        {
            await FetchDataAsync();
            EventsList = eventsListViewModel.EventsList;
            foreach (var Event in EventsList)
            {
                DateTime StartDate = Event.EventStartDate;
                TimeSpan EventStartTime = Event.EventStartTime;
                DateTime CalendarEventStartDate = new DateTime();
                CalendarEventStartDate = CalendarEventStartDate.AddDays(StartDate.Day - 1);
                CalendarEventStartDate = CalendarEventStartDate.AddMonths(StartDate.Month - 1);
                CalendarEventStartDate = CalendarEventStartDate.AddYears(StartDate.Year - 1);
                CalendarEventStartDate = CalendarEventStartDate.AddHours(EventStartTime.Hours);
                CalendarEventStartDate = CalendarEventStartDate.AddMinutes(EventStartTime.Minutes);
                CalendarEventStartDate = CalendarEventStartDate.AddSeconds(EventStartTime.Seconds);

                DateTime EndDate = Event.EventStartDate;
                TimeSpan EventEndTime = Event.EventStartTime;
                DateTime CalendarEventEndDate = new DateTime();
                CalendarEventEndDate = CalendarEventEndDate.AddDays(EndDate.Day - 1);
                CalendarEventEndDate = CalendarEventEndDate.AddMonths(EndDate.Month - 1);
                CalendarEventEndDate = CalendarEventEndDate.AddYears(EndDate.Year - 1);
                CalendarEventEndDate = CalendarEventEndDate.AddHours(EventEndTime.Hours);
                CalendarEventEndDate = CalendarEventEndDate.AddMinutes(EventEndTime.Minutes);
                CalendarEventEndDate = CalendarEventEndDate.AddSeconds(EventEndTime.Seconds);

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
