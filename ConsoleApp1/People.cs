using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ConsoleApp1
{
    [Table("people")]
   public class People
    {
        public int id { get; set; }

        public float quantity { get; set; }

        public int? CountryId { get; set; }

        public Country country { get; set; }
        public int? NationalityId { get; set; }
        public Nationality nationality { get; set; }
    }
}
