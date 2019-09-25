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
        public SQLiteAsyncConnection Calendar_Events_database { get; private set; }
        public NewEvent()
        {
            InitializeComponent();
        }

        async void AddEvent(object sender, EventArgs args)
        {
            Events_database = MtSql.Current.GetConnectionAsync("eventsDb");
            //Calendar_Events_database = MtSql.Current.GetConnectionAsync("calEventsDb");

            //DateTime start = new DateTime(StartDatePicker.Date.Day,
            //    StartDatePicker.Date.Month,
            //    StartDatePicker.Date.Year,
            //    StartTimePicker.Time.Hours,
            //    StartTimePicker.Time.Minutes,
            //    StartTimePicker.Time.Seconds);
            //DateTime end = new DateTime(EndDatePicker.Date.Day,
            //    EndDatePicker.Date.Month,
            //    EndDatePicker.Date.Year,
            //    EndTimePicker.Time.Hours,
            //    EndTimePicker.Time.Minutes,
            //    EndTimePicker.Time.Seconds);

            await Events_database.InsertAsync(new EventsModel { EventTitle = TitleEntry.Text, EventDescription = DetailsEntry.Text, EventStartDate = StartDatePicker.Date, EventEndDate = EndDatePicker.Date, EventStartTime = StartTimePicker.Time, EventEndTime = EndTimePicker.Time });

            //await Calendar_Events_database.InsertAsync(new CalendarInlineEvent {
            //    StartTime = start,
            //    EndTime = end,
            //    Subject = TitleEntry.Text + "\n" + DetailsEntry.Text,
            //    Color = Color.Red
            //});

            await Navigation.PopAsync();
        }

        async void CancelAction(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}
