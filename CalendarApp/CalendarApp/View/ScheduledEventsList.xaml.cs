using System;
using System.Collections.Generic;
using CalendarApp.ViewModel;
using Xamarin.Forms;

namespace CalendarApp.View
{
    public partial class ScheduledEventsList : ContentPage
    {
        public ScheduledEventsList()
        {
            InitializeComponent();
            BindingContext = new EventsListViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            EventslistView.SelectedItem = null;
            //BindingContext = null;
            BindingContext = new EventsListViewModel(Navigation);
        }

        async void NewEvent(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewEvent());
        }
    }
}
