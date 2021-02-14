using System;
using System.ComponentModel.DataAnnotations;

namespace TentaStart.Data
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(50)] public string Namn { get; set; }
        public string Beskrivning { get; set; }
        public int BudgetSEK { get; set; }
        public int MaxAntalStudenter { get; set; }
        [MaxLength(50)] public string Typ { get; set; } //Online eller plats
        public DateTime StartDate { get; set; }
        public int TotalDays { get; set; }

        
    }
}