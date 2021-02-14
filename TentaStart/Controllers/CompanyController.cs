using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TentaStart.Data;
using TentaStart.ViewModels;

namespace TentaStart.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var model = new CompanyIndexViewModel();
            model.Items = _dbContext.Companies.Select(r => new CompanyIndexViewModel.Item
            {
                Typ = r.CompanyTyp,
                City = r.Stad,
                Name = r.Namn,
                Id = r.Id
            }).ToList();


            return View(model);
        }
    }
}