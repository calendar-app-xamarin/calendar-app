using System;
using SQLite;
namespace CalendarApp.Model
{
    public class NotesModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string NoteContent { get; set; }
        public string NoteTitle { get; set; }
        public NotesModel(string title, string content)
        {
            NoteTitle = title;
            NoteContent = content;
        }
        public NotesModel()
        {

        }
    }
}
