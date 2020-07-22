using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ConsoleApp1
{
    [Table("naselenie")]
   public class Naselenie
    {
        public int id { get; set; }

        public float chislenost { get; set; }

        public int? StranaId { get; set; }

        public Strana strana { get; set; }
        public int? NacionalnostId { get; set; }
        public Nacionalnost nacionalnost { get; set; }
    }
}
