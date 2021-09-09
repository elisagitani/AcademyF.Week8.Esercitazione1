using AcademyF.Week8.Esercitazione1.Core.Entities;
using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.BusinessLayer
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly ITicketRepository ticketRepo;
        private readonly INoteRepository noteRepo;
        private readonly ICategoryRepository categoryRepo;

        public MainBusinessLayer(ITicketRepository ticketRepo, INoteRepository noteRepo, ICategoryRepository categoryRepo)
        {
            this.ticketRepo = ticketRepo;
            this.noteRepo = noteRepo;
            this.categoryRepo = categoryRepo;
        }
        public BLResult AddNewNote(Note newNote)
        {
            if (newNote == null)
                return new BLResult(false, "Invalid Note Data");

            newNote.CreationDate = DateTime.Now;
            var result = this.noteRepo.Create(newNote);


            return new BLResult(result, result ? "" : "Cannot create note");
        }

        public BLResult CreateNewTicket(Ticket newTicket)
        {
            if (newTicket == null)
                return new BLResult(false, "Invalid Ticket Data");

            newTicket.CreationDate = DateTime.Now;
            newTicket.State = State.New;

            var result = this.ticketRepo.Create(newTicket);


            return new BLResult(result, result ? "" : "Cannot create ticket");
        }

        public BLResult DeleteTicket(int id)
        {
            if(id<=0)
                return new BLResult(false, "Invalid Ticket ID");

            var result = this.ticketRepo.Delete(id);

            return new BLResult(result, result ? "" : "Cannot delete ticket");
        }

        public IEnumerable<Ticket> FetchAllTickets(Func<Ticket, bool> filter = null)
        {
            return this.ticketRepo.Fetch(filter);
        }

        public Ticket GetTicketbyId(int id)
        {
            if (id <= 0)
                return null;

            return this.ticketRepo.GetTicketWithNotesById(id);
        }

        public BLResult UpdateTicket(Ticket updatedTicket)
        {
            if (updatedTicket == null)
                return new BLResult(false, "Invalid Ticket Data");

            var result = this.ticketRepo.Update(updatedTicket);

            return new BLResult(result, result ? "" : "Cannot update Ticket");
        }

        public IEnumerable<Note> FetchAllNotes(Func<Note, bool> filter=null)
        {
            return this.noteRepo.Fetch(filter);
        }

        public IEnumerable<Ticket> FetchAllTicketsWithNotes(Func<Ticket, bool> filter = null)
        {
            return this.ticketRepo.FetchAllTicketsWithNotes(filter);
        }

        public IEnumerable<Category> FetchAllCategories(Func<Category, bool> filter = null)
        {
            return this.categoryRepo.Fetch(filter);
        }

        public Category GetCategorybyId(int id)
        {
            if (id <= 0)
                return null;

            return this.categoryRepo.GetById(id);
        }

        public BLResult CreateNewCategory(Category newCategory)
        {
            if(newCategory==null)
               return new BLResult(false, "Invalid Category Data");

            var result = this.categoryRepo.Create(newCategory);

            return new BLResult(result, result ? "" : "Cannot create category");

        }

        public BLResult UpdateCategory(Category updatedCategory)
        {
            if (updatedCategory == null)
                return new BLResult(false, "Invalid Category Data");

            var result = this.categoryRepo.Update(updatedCategory);

            return new BLResult(result, result ? "" : "Cannot create category");
        }

        public BLResult DeleteCategory(int id)
        {
            if(id<=0)
                return new BLResult(false, "Invalid Category ID");

            var result = this.categoryRepo.Delete(id);

            return new BLResult(result, result ? "" : "Cannot delete category");
        }
    }
}
