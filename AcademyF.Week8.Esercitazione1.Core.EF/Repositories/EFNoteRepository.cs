using AcademyF.Week8.Esercitazione1.Core.Entities;
using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.EF.Repositories
{
    public class EFNoteRepository : EFRepositoryBase<Note>, INoteRepository
    {
        public EFNoteRepository(TicketDbContext context) : base(context)
        {
        }

        public override DbSet<Note> GetDbSet()
        {
            return Context.Notes;
        }
    }
}
