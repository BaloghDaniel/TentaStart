using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TentaStart.ViewModels
{
    public class NewCompanyViewModel
    {
        [Required]
        public int Id { get; set; }
        [MaxLength(50)]
        public string CompanyName { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; }
        [Required]
        public int Postalcode { get; set; }
        
        [MaxLength(50)]
        public string CompanyType { get; set; }

        public List<SelectListItem> AllTypes = new List<SelectListItem> { new SelectListItem { Value="" , Text="Välj företagstyp"},
                                                                          new SelectListItem { Value = "Universitet", Text = "Universitet" },
                                                                          new SelectListItem { Value ="Högskola", Text = "Högskola" },
                                                                          new SelectListItem { Value="Företag", Text = "Företag" } };

    }
}
