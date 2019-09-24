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
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public TimeSpan EventStartTime { get; set; }
        public TimeSpan EventEndTime { get; set; }
        public EventsModel(string title, string desc, DateTime startDate, DateTime endDate, TimeSpan startTime, TimeSpan endTime)
        {
            EventTitle = title;
            EventDescription = desc;
            EventStartDate = startDate;
            EventStartTime = startTime;
            EventEndDate = endDate;
            EventEndTime = endTime;
        }
        public EventsModel()
        {
        }
    }
}
