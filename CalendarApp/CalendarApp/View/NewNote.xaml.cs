using System;
using System.Collections.Generic;
using CalendarApp.Data;
using CalendarApp.Model;
using MarcTron.Plugin;
using SQLite;
using Xamarin.Forms;

namespace CalendarApp.View
{
    public partial class NewNote : ContentPage
    {
        public SQLiteAsyncConnection Notes_database { get; private set; }
        public NewNote()
        {
            InitializeComponent();
        }

        async void AddNote(object sender, EventArgs args)
        {
            Notes_database = MtSql.Current.GetConnectionAsync("notesDb");
            await Notes_database.InsertAsync(new NotesModel { NoteTitle = TitleEntry.Text, NoteContent = DetailsEntry.Text   });
            await Navigation.PopAsync();
        }

        async void CancelAction(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}
