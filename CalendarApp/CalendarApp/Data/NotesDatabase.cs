using System;
using CalendarApp.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarcTron.Plugin;

namespace CalendarApp.Data
{
    public class NotesDatabase
    {
        public SQLiteAsyncConnection Notes_database { get; private set; }
        public NotesDatabase()
        {
            Notes_database = MtSql.Current.GetConnectionAsync("notesDb");

            Notes_database.CreateTableAsync<NotesModel>().Wait();

            Notes_database.InsertAsync(new NotesModel { NoteTitle = "Note 1", NoteContent = "Description 1" });
            Notes_database.InsertAsync(new NotesModel { NoteTitle = "Note 2", NoteContent = "Description 2" });
            Notes_database.InsertAsync(new NotesModel { NoteTitle = "Note 3", NoteContent = "Description 3" });
        }

        public async Task<List<NotesModel>>GetAllNotesAsync()
        {
            return await Notes_database.Table<NotesModel>().ToListAsync();
        }

        public async Task AddNotesAsync(NotesModel newNote)
        {
            await Notes_database.InsertAsync(newNote);
        }
    }
}
