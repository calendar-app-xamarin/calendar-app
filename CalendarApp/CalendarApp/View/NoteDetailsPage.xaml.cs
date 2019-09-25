using System;
using System.Collections.Generic;
using CalendarApp.ViewModel;
using CalendarApp.Model;
using Xamarin.Forms;

namespace CalendarApp.View
{
    public partial class NoteDetailsPage : ContentPage
    {
        public NoteDetailsViewModel ViewModel { get; }

        public NoteDetailsPage(NotesModel note)
        {
            InitializeComponent();
            BindingContext = ViewModel = new NoteDetailsViewModel();
            ViewModel.SetData(note);
        }

        public NoteDetailsPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new NoteDetailsViewModel();
            ViewModel.SetData(new NotesModel());
        }
    }
}
