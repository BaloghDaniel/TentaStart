using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Edit(int Id)
        {
            var company = _dbContext.Companies.FirstOrDefault(c => c.Id == Id);
            var viewModel = new EditCompanyVIewModel()
            {
                Id = company.Id,
                CompanyName = company.Namn,
                Email = company.Epost,
                City = company.Stad,
                Adress = company.GatuAdress,
                Postalcode = company.PostalCode,
                CompanyType = company.CompanyTyp,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCompanyVIewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var company = _dbContext.Companies.FirstOrDefault(c => c.Id == viewModel.Id);
                company.Namn = viewModel.CompanyName;
                company.Epost = viewModel.Email;
                company.Stad = viewModel.City;
                company.GatuAdress = viewModel.Adress;
                company.PostalCode = viewModel.Postalcode;
                company.CompanyTyp = viewModel.CompanyType;

                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Company");
            }

            return View(viewModel);
        }

        public IActionResult New()
        {
            var viewModel = new NewCompanyViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(NewCompanyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var company = new Company()
                {
                    Namn = viewModel.CompanyName,
                    Epost = viewModel.Email,
                    Stad = viewModel.City,
                    GatuAdress = viewModel.Adress,
                    PostalCode = viewModel.Postalcode,
                    CompanyTyp = viewModel.CompanyType
                };
                _dbContext.Companies.Add(company);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Company");
            }
            return View(viewModel);
        }
    }
}