using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyF.Week8.Esercitazione1.MVC.Models
{
    public class TicketListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
        public string Applicant { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string State { get; set; }
        public int Note { get; set; }

    }
}
