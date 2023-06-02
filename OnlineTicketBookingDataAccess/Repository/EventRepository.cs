using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineTicketBookingDataAccess.Data;
using OnlineTicketBookingDataAccess.Models;
using OnlineTicketBookingDataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTicketBookingDataAccess.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EventRepository(DatabaseContext databaseContext)
        {
            _databaseContext=databaseContext;
        }

        public void Create(Event Event)
        {
            _databaseContext.Events.Add(Event); 
        }

        public void Delete(int EventId)

        {
           Event Event= _databaseContext.Events.Find(EventId);
            _databaseContext.Events.Remove(Event);
        }

        public IEnumerable<Event> Get()
        {
          return  _databaseContext.Events.ToList();
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public void Update(Event Event)
        {
           

            _databaseContext.Entry(Event).State=EntityState.Modified;
        }
    }
}
