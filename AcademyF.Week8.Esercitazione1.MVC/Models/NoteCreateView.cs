using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyF.Week8.Esercitazione1.MVC.Models
{
    public class NoteCreateView
    {
        [DisplayName("Ticket ID")]
        public int TicketId { get; set; }
        public string Text { get; set; }
    }
}
