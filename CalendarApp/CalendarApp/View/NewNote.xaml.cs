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
            
        //new NotesModel { NoteTitle = "Note 1", NoteContent = "Description 1" }
        //    await AddNotesAsync;
        }
    }
}
