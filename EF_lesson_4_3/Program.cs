using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_lesson_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PhoneContext db = new PhoneContext())
            {
                var phones = db.Phones.Where(p => p.Company.Name == "Samsung");
                foreach (Phone p in phones)
                    Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);
                var result = from phone in db.Phones
                             join company in db.Companies on phone.CompanyId equals company.Id
                             join country in db.Countries on company.CountryId equals country.Id
                             select new
                             {
                                 Name = phone.Name,
                                 Company = company.Name,
                                 Price = phone.Price,
                                 Country = country.Name
                             };
                foreach (var p in result)
                    Console.WriteLine("Name - {0}, Company - {1}, Price - {2}, Country- {3}", p.Name, p.Company, p.Price, p.Country);
            }
            Console.ReadLine();
        }
    }
}
