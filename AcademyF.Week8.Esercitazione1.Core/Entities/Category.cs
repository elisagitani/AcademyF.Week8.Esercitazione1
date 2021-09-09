using AcademyF.Week8.Esercitazione1.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week8.Esercitazione1.Core.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
    }
}
