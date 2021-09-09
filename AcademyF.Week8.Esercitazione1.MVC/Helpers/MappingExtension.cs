using AcademyF.Week8.Esercitazione1.Core.Entities;
using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using AcademyF.Week8.Esercitazione1.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyF.Week8.Esercitazione1.MVC.Helpers
{
    public static class MappingExtension
    {
        public static IEnumerable<SelectListItem> EnumToSelectList<T>() where T : struct
        {
            return (Enum.GetValues(typeof(T)).Cast<T>().Select(
                e => new SelectListItem() { Text = e.ToString(), Value = e.ToString() })).ToList();
        }
        public static TicketListViewModel ToTicketList(this Ticket ticket)
        {
            TicketListViewModel newTicket = new TicketListViewModel
            {
                Id = ticket.Id,
                CreationDate = ticket.CreationDate,
                Title=ticket.Title,
                Applicant = ticket.Applicant.ToUpper(),
                Priority = ticket.Priority.ToString(),
                State = ticket.State.ToString(),
                Note = ticket.Notes.Count
            };

            return newTicket;
        }

        public static IEnumerable<TicketListViewModel> ToTicketList(this IEnumerable<Ticket> tickets)
        {
            return tickets.Select(t => t.ToTicketList());
        }

        public static Ticket ToTicket(this TicketCreateViewModel ticket)
        {
            Ticket newTicket = new Ticket
            {
                Id = 0,
                Applicant = ticket.Applicant,
                Priority = ticket.Priority,
                ClosingDate = null,
                CategoryId=ticket.Category.Id,
                Description=ticket.Description,
                TicketManager=null,
                Title=ticket.Title

            };

            return newTicket;
        }

        public static TicketDetailsViewModel ToTicketDetails(this Ticket ticket)
        {
            TicketDetailsViewModel newTicket = new TicketDetailsViewModel
            {
                Id = ticket.Id,
                CreationDate = ticket.CreationDate,
                Applicant = ticket.Applicant,
                Priority = ticket.Priority,
                State = ticket.State,
                ClosingDate = ticket.ClosingDate,
                Category = ticket.Category.Name,
                Description = ticket.Description,
                TicketManager = ticket.TicketManager,
                Title = ticket.Title,
                Note = ticket.Notes.Count,
                Notes=ticket.Notes

            };

            return newTicket;
        }

        public static Note ToNote (this NoteCreateView note)
        {
            return new Note
            {
                TicketId = note.TicketId,
                Text = note.Text
            };
        }


        public static TicketAssignViewModel ToTicketAssign(this Ticket ticket)
        {
            return new TicketAssignViewModel
            {
                Id = ticket.Id,
                TicketManager = ticket.TicketManager,
                State=State.Assigned,
                Applicant=ticket.Applicant,
                CategoryId=ticket.CategoryId,
                CreationDate=ticket.CreationDate,
                ClosingDate=ticket.ClosingDate,
                Description=ticket.Description,
                Title=ticket.Title,
                Note=ticket.Notes.Count,
                Priority=ticket.Priority
            };
        }

        public static Ticket ToTicket(this TicketAssignViewModel ticket)
        {
            return new Ticket
            {
                Id = ticket.Id,
                TicketManager = ticket.TicketManager,
                State = ticket.State,
                Applicant = ticket.Applicant,
                CategoryId = ticket.CategoryId,
                CreationDate = ticket.CreationDate,
                ClosingDate = ticket.ClosingDate,
                Description = ticket.Description,
                Title = ticket.Title,
                Priority = ticket.Priority
            };
        }

        public static TicketEditViewModel ToTicketEdit(this Ticket ticket)
        {
            return new TicketEditViewModel
            {
                Id = ticket.Id,
                TicketManager = ticket.TicketManager,
                State = State.Assigned,
                Applicant = ticket.Applicant,
                Category = ticket.Category,
                CreationDate = ticket.CreationDate,
                ClosingDate = ticket.ClosingDate,
                Description = ticket.Description,
                Title = ticket.Title,
                Priority = ticket.Priority,
                Notes=ticket.Notes
            };
        }

        public static Ticket ToTicket(this TicketEditViewModel ticket)
        {
            return new Ticket
            {
                Id = ticket.Id,
                TicketManager = ticket.TicketManager,
                State = ticket.State,
                Applicant = ticket.Applicant,
                CategoryId = ticket.Category.Id,
                CreationDate = ticket.CreationDate,
                ClosingDate = ticket.ClosingDate,
                Description = ticket.Description,
                Title = ticket.Title,
                Priority = ticket.Priority,
                Notes = ticket.Notes
            };
        }

        public static CategoryListViewModel ToListViewModel(this Category category)
        {
            CategoryListViewModel newCategory = new CategoryListViewModel
            {
                Id = category.Id,
                Name=category.Name
            };

            return newCategory;
        }

        public static IEnumerable<CategoryListViewModel> ToListViewModel(this IEnumerable<Category> categories)
        {
            return categories.Select(t => t.ToListViewModel());
        }

        public static Category ToCreateViewModel(this CategoryCreateViewModel category)
        {
            return new Category
            {
                Id = 0,
                Name = category.Name,
                Code = category.Code
            };
        }

        public static Category ToCategory(this CategoryCreateViewModel category)
        {
            return new Category
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code
            };
        }

        public static CategoryCreateViewModel ToCreateViewModel(this Category category)
        {
            return new CategoryCreateViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code
            };
        }

        public static CategoryDetailsViewModel ToDetailsCategory(this Category category)
        {
            return new CategoryDetailsViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Code = category.Code
            };
        }
    }
}
