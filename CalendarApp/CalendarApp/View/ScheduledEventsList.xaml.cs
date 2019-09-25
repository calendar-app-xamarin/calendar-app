using System;
using System.Collections.Generic;
using CalendarApp.ViewModel;
using MarcTron.Plugin;
using SQLite;
using Xamarin.Forms;
using CalendarApp.Model;

namespace CalendarApp.View
{
    public partial class ScheduledEventsList : ContentPage
    {
        public SQLiteAsyncConnection Events_database { get; private set; }
        public ScheduledEventsList()
        {
            InitializeComponent();
            BindingContext = new EventsListViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            EventslistView.SelectedItem = null;
            BindingContext = new EventsListViewModel(Navigation);
        }

        async void NewEvent(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewEvent());
        }

        async void OnDelete(object sender, EventArgs e)
        {
            Events_database = MtSql.Current.GetConnectionAsync("eventsDb");

            var mi = ((MenuItem)sender);
            EventsModel eventToDelete = (CalendarApp.Model.EventsModel)mi.CommandParameter;
            await Events_database.DeleteAsync(eventToDelete);
            BindingContext = new EventsListViewModel(Navigation);
        }
    }
}
