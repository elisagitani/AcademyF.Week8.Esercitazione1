using AcademyF.Week8.Esercitazione1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.Interfaces
{
    public interface ITicketRepository: IRepository<Ticket>
    {
        public IEnumerable<Ticket> FetchAllTicketsWithNotes(Func<Ticket, bool> filter=null);
        public Ticket GetTicketWithNotesById(int id);
    }
}
