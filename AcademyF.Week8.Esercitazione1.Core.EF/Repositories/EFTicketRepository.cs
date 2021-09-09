using AcademyF.Week8.Esercitazione1.Core.Entities;
using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.EF.Repositories
{
    public class EFTicketRepository : EFRepositoryBase<Ticket>, ITicketRepository
    {
        public EFTicketRepository(TicketDbContext context) : base(context)
        {
        }

        public IEnumerable<Ticket> FetchAllTicketsWithNotes(Func<Ticket, bool> filter = null)
        {
            if(filter!=null)
            return GetDbSet()
                .Include(t => t.Notes)
                .Where(filter);

            return GetDbSet()
                .Include(t => t.Notes);
        }

        public override DbSet<Ticket> GetDbSet()
        {
            return Context.Tickets; 
        }

        public Ticket GetTicketWithNotesById(int id)
        {
            if (id <= 0)
                return null;

            return GetDbSet()
                .Include(t => t.Notes)
                .SingleOrDefault(t => t.Id == id);
        }
    }
}
