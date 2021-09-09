using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.Entities
{
    public enum Priority
    {
        High=1,
        Normal=2,
        Low=3
    }

    public enum State
    {
        New=1,
        Assigned,
        InResolution,
        Closed
    }

    public class Ticket: IEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Applicant { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public State State { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string TicketManager { get; set; }
        public DateTime? ClosingDate { get; set; }
        public List<Note> Notes { get; set; }

    }
}
