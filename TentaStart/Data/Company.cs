using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TentaStart.Data
{
    public class Company
    {
        public int Id { get; set; }

        [MaxLength(50)] public string Namn { get; set; }


        [MaxLength(100)] public string Epost { get; set; }
        [MaxLength(100)] public string GatuAdress { get; set; }
        public int PostalCode { get; set; }
        [MaxLength(100)] public string Stad { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();

        [MaxLength(50)] public string CompanyTyp { get; set; } //Universitet, högskola eller företag

    }
}