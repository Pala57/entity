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
            DbSet<Strana> t = db.Stranas;
            DbSet<Nacionalnost> s = db.Nacionalnosts;
            DbSet<Naselenie> b = db.Naselenies;
            Nacionalnost nac = new Nacionalnost();


             Strana str = new Strana();


              Naselenie nas = new Naselenie();
            Nacionalnost nac1 = new Nacionalnost();
            nac.id = 1;
            nac.Kolichesvo = 124;
            nac.Language = "sgasdg";
            nac.Name = "sdgas";
            nac.Naselenies.Add(nas);


            db.SaveChanges();

            nac1.id = 2;
            nac1.Kolichesvo = 23523532263462;
            nac1.Language = "sgasdg";
            nac1.Name = "'светлый эльф'";
            nac1.Naselenies.Add(nas);

            db.SaveChanges();

            str.id = 1;
            str.Name = "Strana1";
                str.Naselenies.Add(nas);
          
                str.Region = "Region1";
            str.Stolica = "Stolica1";

            db.SaveChanges();
            nas.id = 1;
            nas.chislenost = 1241245;
            nas.nacionalnost = nac;
            nas.StranaId = str.id;
            nas.NacionalnostId = nac.id;

            db.SaveChanges();
            // t.Add(rec);
            //  db.SaveChanges();

            Console.WriteLine("done");



            //Console.WriteLine($"id: {nac.id}, Kolichesvo: {nac.Kolichesvo}");

            Console.WriteLine($"id: {nas.nacionalnost}");

           // var mostUsedTags = db.Tags.OrderByDescending(t => t.Videos.Count).Take(10)
 
            var result = from Nacionalnost in db.Nacionalnosts
                         join Naselenie in db.Naselenies on nas.NacionalnostId equals nac.id
                         join Strana in db.Stranas on str.id equals nas.NacionalnostId
                         where str.Name == "ОЗ" && nac.Kolichesvo > (nas.chislenost * 20 / 100)
                         select new
                         {
                             name = str.Name,
                             list = nac.Language
                         };

            var result1 = from Strana in db.Stranas
                         join Naselenie in db.Naselenies on nas.StranaId equals str.id
                       
                         select new
                         {
                             name = str.Name,
                             kolichestvo = nas.chislenost
                         };
            foreach (var r in result1)
            {
                Console.WriteLine($"name: {r.name}, kolichestvo {r.kolichestvo}");
            }



//            var d = db.Stranas
//.Select(p => new { Name = p.Name, Company = p.Company.Name, Price = p.Price })
//.Join  (c=>)
//.OrderBy(p => p.Price)

//.ThenBy(p => p.Company)

//;


            var result2 = from Strana in db.Stranas
                          join Naselenie in db.Naselenies on nas.StranaId equals str.id
                          join Nacionalnost in db.Nacionalnosts on nac.id equals nas.NacionalnostId
                               
                          where nac.Name == "светлый эльф"
                          orderby nac.Kolichesvo
                          select new
                          {
                              
                              stolica = str.Stolica.Take(1),
                             
                              kolichesvo=nac.Kolichesvo
                          };



            foreach (var r in result2)
            {
                Console.WriteLine($"name: {r.stolica}, kolichestvo {r.kolichesvo}");
            }



            var result3 = from Nacionalnost in db.Nacionalnosts
                              join Naselenie in db.Naselenies on nas.NacionalnostId equals nac.id
                              join Strana in db.Stranas on str.id equals nas.NacionalnostId
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
