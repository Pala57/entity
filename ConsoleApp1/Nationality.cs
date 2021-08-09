using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ConsoleApp1
{
    [Table("nationality")]
    public class Nationality
    {
        public Nationality()
        {
            this.People = new HashSet<People>();
        }
        public int id { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public float Quantity { get; set; }

        public virtual ICollection<People> People { get; set; }

    }
}
