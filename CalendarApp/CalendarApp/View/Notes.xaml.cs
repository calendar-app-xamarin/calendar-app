using System;
using System.Collections.Generic;
using System.Diagnostics;
using CalendarApp.ViewModel;
using Xamarin.Forms;

namespace CalendarApp.View
{
    public partial class Notes : ContentPage
    {
        public Notes()
        {
            InitializeComponent();
            BindingContext = new NotesListViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            NoteslistView.SelectedItem = null;
        }

        async void NewNote(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewNote());
        }
    }
}
