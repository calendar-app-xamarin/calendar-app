using System;
using System.Collections.Generic;
using System.Diagnostics;
using CalendarApp.ViewModel;
using CalendarApp.Model;
using Xamarin.Forms;
using SQLite;
using MarcTron.Plugin;

namespace CalendarApp.View
{
    public partial class Notes : ContentPage
    {
        public SQLiteAsyncConnection Notes_database { get; private set; }
        public Notes()
        {
            InitializeComponent();
            BindingContext = new NotesListViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            NoteslistView.SelectedItem = null;
            BindingContext = new NotesListViewModel(Navigation);
        }

        async void NewNote(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewNote());
        }

        async void OnDelete(object sender, EventArgs e)
        {
            Notes_database = MtSql.Current.GetConnectionAsync("notesDb");

            var mi = ((MenuItem)sender);
            NotesModel noteToDelete = (CalendarApp.Model.NotesModel)mi.CommandParameter;
            await Notes_database.DeleteAsync(noteToDelete);
            BindingContext = new NotesListViewModel(Navigation);
        }
    }
}
