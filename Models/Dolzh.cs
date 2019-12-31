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
        public int Id_Dolzh { get; set; }
        public string NameDolzh { get; set; }

        [ForeignKey("Otdel")]
        public int Id_Otdel { get; set; }
        public Otdel Otdel { get; set; }
    }
}
