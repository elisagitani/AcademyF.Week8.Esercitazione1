using AcademyF.Week8.Esercitazione1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        #region TICKET
        IEnumerable<Ticket> FetchAllTickets(Func<Ticket, bool> filter = null);
        Ticket GetTicketbyId(int id);
        BLResult CreateNewTicket(Ticket newTicket);
        BLResult UpdateTicket(Ticket updatedTicket);
        BLResult DeleteTicket(int id);
        #endregion

        #region NOTE
        BLResult AddNewNote(Note newNote);
        IEnumerable<Note> FetchAllNotes(Func<Note,bool>filter=null);
        #endregion

        IEnumerable<Ticket> FetchAllTicketsWithNotes(Func<Ticket, bool> filter = null);

        #region CATEGORY
        IEnumerable<Category> FetchAllCategories(Func<Category, bool> filter = null);
        Category GetCategorybyId(int id);
        BLResult CreateNewCategory(Category newCategory);
        BLResult UpdateCategory(Category updatedCategory);
        BLResult DeleteCategory(int id);
        #endregion
    }
}
