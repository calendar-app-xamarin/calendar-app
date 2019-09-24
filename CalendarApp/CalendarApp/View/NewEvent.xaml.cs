using System;
using System.Collections.Generic;
using CalendarApp.Model;
using MarcTron.Plugin;
using SQLite;
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
            await Events_database.InsertAsync(new EventsModel { EventTitle = TitleEntry.Text, EventDescription = DetailsEntry.Text, EventDate = DatePickerPicker.Date, EventTime = TimePickerPicker.Time });
            await Navigation.PopAsync();
        }

        async void CancelAction(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}
