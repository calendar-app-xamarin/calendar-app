using System;
using CalendarApp.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarcTron.Plugin;

namespace CalendarApp.Data
{
    public class EventsDatabase
    {
        public SQLiteAsyncConnection Events_database { get; private set; }
        public EventsDatabase()
        {
            Events_database = MtSql.Current.GetConnectionAsync("eventsDb");

            Events_database.CreateTableAsync<EventsModel>().Wait();

            Events_database.InsertAsync(new EventsModel { EventTitle = "Event 1", EventDescription = "Description 1", EventDate = DateTime.Now });
            Events_database.InsertAsync(new EventsModel { EventTitle = "Event 2", EventDescription = "Description 2", EventDate = DateTime.Now });
            Events_database.InsertAsync(new EventsModel { EventTitle = "Event 3", EventDescription = "Description 3", EventDate = DateTime.Now });
        }

        public async Task<List<EventsModel>> GetAllEventsAsync()
        {
            return await Events_database.Table<EventsModel>().ToListAsync();
        }

        public async Task AddEventsAsync(EventsModel newEvent)
        {
            await Events_database.InsertAsync(newEvent);
        }
    }
}
