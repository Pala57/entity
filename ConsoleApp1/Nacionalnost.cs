using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ConsoleApp1
{
    [Table("nacionalnost")]
    public class Nacionalnost
    {
        public Nacionalnost()
        {
            this.Naselenies = new HashSet<Naselenie>();
        }
        public int id { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public float Kolichesvo { get; set; }

        public virtual ICollection<Naselenie> Naselenies { get; set; }

    }
}
