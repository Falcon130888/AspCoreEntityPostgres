using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEntityPostgres.Models
{
    public class Otdel
    {
        [Key]
        public int Id_Otdel { get; set; }
        public string NameOtdel { get; set; }
        public string LeadOtdel { get; set; }
    }
}