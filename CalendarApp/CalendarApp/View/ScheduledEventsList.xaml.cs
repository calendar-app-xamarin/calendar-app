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
    }
}
