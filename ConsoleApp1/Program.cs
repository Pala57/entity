using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            NewDB db = new NewDB();
            DbSet<Country> t = db.Countrys;
            DbSet<Nationality> s = db.Nationalitys;
            DbSet<People> b = db.Peoples;
            Nationality nac = new Nationality();


             Country str = new Country();


              People nas = new People();
            Nationality nac1 = new Nationality();
            nac.id = 1;
            nac.quantity = 124;
            nac.Language = "sgasdg";
            nac.Name = "sdgas";
            nac.People.Add(nas);


            db.SaveChanges();

            nac1.id = 2;
            nac1.quantity = 23523532263462;
            nac1.Language = "sgasdg";
            nac1.Name = "'светлый эльф'";
            nac1.People.Add(nas);

            db.SaveChanges();

            str.id = 1;
            str.Name = "Country1";
                str.People.Add(nas);
          
                str.Region = "Region1";
            str.Capital = Capital1";

            db.SaveChanges();
            nas.id = 1;
            nas.quantity = 1241245;
            nas.nationality = nac;
            nas.CountryId = str.id;
            nas.NationalityId = nac.id;

            db.SaveChanges();
            // t.Add(rec);
            //  db.SaveChanges();

            Console.WriteLine("done");



          

            Console.WriteLine($"id: {nas.nationality}");

           // var mostUsedTags = db.Tags.OrderByDescending(t => t.Videos.Count).Take(10)
 
            var result = from Nationality in db.Nationalitys
                         join People in db.Peoples on nas.NationalityId equals nac.id
                         join Country in db.Countrys on str.id equals nas.NationalityId
                         where str.Name == "ОЗ" && nac.quantity > (nas.quantity * 20 / 100)
                         select new
                         {
                             name = str.Name,
                             list = nac.Language
                         };

            var result1 = from Country in db.Countrys
                         join People in db.Peoples on nas.CountryId equals str.id
                       
                         select new
                         {
                             name = str.Name,
                             quantity = nas.quantity
                         };
            foreach (var r in result1)
            {
                Console.WriteLine($"name: {r.name}, quantity {r.quantity}");
            }






            var result2 = from Country in db.Countrys
                          join People in db.Peoples on nas.CountryId equals str.id
                          join Nationality in db.Nationalitys on nac.id equals nas.NationalityId
                               
                          where nac.Name == "светлый эльф"
                          orderby nac.quantity
                          select new
                          {
                              
                              stolica = str.Capital.Take(1),
                             
                              quantity=nac.quantity
                          };



            foreach (var r in result2)
            {
                Console.WriteLine($"name: {r.stolica}, quantity {r.quantity}");
            }



            var result3 = from Nationality in db.Nationalitys
                              join People in db.Peoples on nas.PeopleId equals nac.id
                              join Country in db.Countrys on str.id equals nas.NationalityId
                              where str.Region == "Драконовы горы"
                              select new
                              {
                                  name = str.Region,
                                  list = nac.Name
                              };
          //  Console.ReadLine();
        }
    }
}
