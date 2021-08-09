using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    [Table("country")]
    public class Country
    {
        public Country()
        {
            this.Peoples = new HashSet<People>();
        }
        public int id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }

        public string Region { get; set; }

        public virtual ICollection<People> Peoples { get; set; }
    

    }
}
