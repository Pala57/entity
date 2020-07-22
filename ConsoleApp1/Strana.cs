using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    [Table("strana")]
    public class Strana
    {
        public Strana()
        {
            this.Naselenies = new HashSet<Naselenie>();
        }
        public int id { get; set; }
        public string Name { get; set; }
        public string Stolica { get; set; }

        public string Region { get; set; }

        public virtual ICollection<Naselenie> Naselenies { get; set; }
    

    }
}
