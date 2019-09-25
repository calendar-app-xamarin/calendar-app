using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MarcTron.Plugin;
using SQLite;
using CalendarApp.Model;
using CalendarApp.Data;
using Syncfusion.SfCalendar.XForms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CalendarApp.View
{
    public partial class Calendar : ContentPage
    {
        public ObservableCollection<EventsModel> EventsList;
        EventsDatabase eventsDatabase = new EventsDatabase();
        public Calendar()
        {
            InitializeComponent();
            FetchDataAsync();
            FillEvents();
        }

        public async Task FetchDataAsync()
        {

            var list = await eventsDatabase.GetAllEventsAsync();
            EventsList = new ObservableCollection<EventsModel>(list);
        }

        public void FillEvents()
        {
            foreach (var Event in EventsList)
            {

            }
        }
    }
}
