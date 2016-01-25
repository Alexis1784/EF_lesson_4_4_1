using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_4_3
{
    class MyContextInitializer : DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext db)
        {
            Country cn1 = new Country { Name = "US" };
            Country cn2 = new Country { Name = "South Corea" };
            db.Countries.Add(cn1);
            db.Countries.Add(cn2);

            Company c1 = new Company { Name = "Samsung", Country = cn2 };
            Company c2 = new Company { Name = "Apple", Country = cn1 };
            db.Companies.Add(c1);
            db.Companies.Add(c2);

            db.SaveChanges();

            Phone p1 = new Phone { Name = "Samsung Galaxy S5", Price = 20000, Company = c1 };
            Phone p2 = new Phone { Name = "Samsung Galaxy S4", Price = 15000, Company = c1 };
            Phone p3 = new Phone { Name = "iPhone5", Price = 28000, Company = c2 };
            Phone p4 = new Phone { Name = "iPhone 4S", Price = 23000, Company = c2 };

            db.Phones.AddRange(new List<Phone>() { p1, p2, p3, p4 });
            db.SaveChanges();
        }
    }
}
