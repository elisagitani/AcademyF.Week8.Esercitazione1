using AcademyF.Week8.Esercitazione1.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyF.Week8.Esercitazione1.MVC.Models
{
    public class TicketEditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
        public string Applicant { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public State State { get; set; }
        public Category Category { get; set; }
        public string TicketManager { get; set; }
        public DateTime? ClosingDate { get; set; }
        public List<Note> Notes { get; set; }
    }
}


