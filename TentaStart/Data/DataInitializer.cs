using System;
using System.Linq;
using System.Runtime.Loader;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TentaStart.Data
{
    public class DataInitializer
    {
        public void InitializeDatabase(ApplicationDbContext context)
        {
            context.Database.Migrate();
            SeedCompanies(context);
            SeedCourses(context);
        }

        private void SeedCourses(ApplicationDbContext context)
        {
            AddCourseIfNotExists(context, context.Companies.First(r=>r.Namn == "Stockholms universitet"),
                "Cobol programmering","En cool kurs bla bla",100000,30,"online",new DateTime(2021,3,3),30);
            AddCourseIfNotExists(context, context.Companies.First(r => r.Namn == "Stockholms universitet"),
                "C# för pros", "En annan ", 200000, 40, "online", new DateTime(2021, 4, 4), 30);
            AddCourseIfNotExists(context, context.Companies.First(r => r.Namn == "Harrys Utbildningar AB"),
                "C++ och annat", "bla bla bla", 120000, 30, "plats", new DateTime(2021, 4, 4), 40);
            AddCourseIfNotExists(context, context.Companies.First(r => r.Namn == "Mittuniversitetet"),
                "HTML", "dsdasdasdas", 220000, 40, "plats", new DateTime(2021, 4, 2), 30);

            context.SaveChanges();
        }

        private void AddCourseIfNotExists(ApplicationDbContext context, Company comp, string namn, string besk, 
            int budget, int maxStudenter, string plats, DateTime dateTime, int i2)
        {
            if (context.Courses.Any(r => r.Namn == namn))
                return;
            comp.Courses.Add(new Course
            {
                Namn = namn,
                Beskrivning = besk,
                BudgetSEK = budget,MaxAntalStudenter = maxStudenter,
                Typ = plats,StartDate = dateTime,TotalDays = i2
            });
        }

        private void SeedCompanies(ApplicationDbContext context)
        {
            AddCompanyIfNotExists(context,"Stockholms universitet", "courses@su.se","Testgatan 12",11122, "Stockholm", "universitet");
            AddCompanyIfNotExists(context, "Mittuniversitetet", "info@miu.se","Hejvägen 1", 22233, "Sundsvall", "universitet");
            AddCompanyIfNotExists(context, "Harrys Utbildningar AB", "hello@harry.se", "Valhallavägen 99", 11133, "Stockholm", "företag");
            context.SaveChanges();
        }

        private void AddCompanyIfNotExists(ApplicationDbContext context, string namn, string epost, string street, int postalCode, string stad, string type)
        {
            if (context.Companies.Any(r => r.Namn == namn)) return;
            context.Companies.Add(new Company
            {
                Epost = epost,
                GatuAdress = street,
                Namn = namn,
                PostalCode = postalCode,
                Stad = stad,
                CompanyTyp = type
            });
        }
    }
}