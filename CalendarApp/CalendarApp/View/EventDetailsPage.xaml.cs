using System;
using System.Collections.Generic;
using CalendarApp.Model;
using CalendarApp.ViewModel;
using Xamarin.Forms;

namespace CalendarApp.View
{
    public partial class EventDetailsPage : ContentPage
    {
        public EventDetailsViewModel ViewModel { get; }

        public EventDetailsPage(EventsModel note)
        {
            InitializeComponent();
            BindingContext = ViewModel = new EventDetailsViewModel();
            ViewModel.SetData(note);
        }

        public EventDetailsPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new EventDetailsViewModel();
            ViewModel.SetData(new EventsModel());
        }
    }
}
