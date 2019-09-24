using System;
using SQLite;

namespace CalendarApp.Model
{
    public class EventsModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan EventTime { get; set; }
        public EventsModel(string title, string desc, DateTime date, TimeSpan time)
        {
            EventTitle = title;
            EventDescription = desc;
            EventDate = date;
            EventTime = time;
        }
        public EventsModel()
        {
        }
    }
}
