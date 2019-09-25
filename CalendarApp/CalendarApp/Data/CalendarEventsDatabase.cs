using System;
using System.Threading.Tasks;
using MarcTron.Plugin;
using SQLite;
using System.Collections.Generic;
using Syncfusion.SfCalendar.XForms;

namespace CalendarApp.Data
{
    public class CalendarEventsDatabase
    {
        public SQLiteAsyncConnection Calendar_Events_database { get; private set; }
        public CalendarEventsDatabase()
        {
            Calendar_Events_database = MtSql.Current.GetConnectionAsync("calEventsDb");

            Calendar_Events_database.CreateTableAsync<CalendarInlineEvent>().Wait();
        }

        public async Task<List<CalendarInlineEvent>> GetAllCalEventsAsync()
        {
            return await Calendar_Events_database.Table<CalendarInlineEvent>().ToListAsync();
        }

        public async Task AddCalEventsAsync(CalendarInlineEvent newEvent)
        {
            await Calendar_Events_database.InsertAsync(newEvent);
        }
    }
}
