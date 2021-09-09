using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.Entities
{
    public class Note : IEntity
    {
        public int Id { get ; set ; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
