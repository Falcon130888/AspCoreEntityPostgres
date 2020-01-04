using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEntityPostgres.Models
{
    public class Dolzh
    {
        [Key]
        public int IdDolzh { get; set; }
        public string NameDolzh { get; set; }

        [ForeignKey("Otdel")]
        public int IdOtdel { get; set; }
        public Otdel Otdel { get; set; }
    }
}
