using System;
using System.Collections.Generic;
using CalendarApp.Model;
using MarcTron.Plugin;
using SQLite;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace CalendarApp.View
{
    public partial class NewEvent : ContentPage
    {
        public SQLiteAsyncConnection Events_database { get; private set; }
        public NewEvent()
        {
            InitializeComponent();
        }

        async void AddEvent(object sender, EventArgs args)
        {
            Events_database = MtSql.Current.GetConnectionAsync("eventsDb");

            await Events_database.InsertAsync(new EventsModel { EventTitle = TitleEntry.Text, EventDescription = DetailsEntry.Text, EventStartDate = StartDatePicker.Date, EventEndDate = EndDatePicker.Date, EventStartTime = StartTimePicker.Time, EventEndTime = EndTimePicker.Time });

            await Navigation.PopAsync();
        }

        async void CancelAction(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}
