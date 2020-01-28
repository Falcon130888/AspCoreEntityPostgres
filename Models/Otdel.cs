using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspCoreEntityPostgres.Models
{
    public class Otdel
    {
        [Key]
        public int IdOtdel { get; set; }
        public string NameOtdel { get; set; }
        public string LeadOtdel { get; set; }

        public List<Dolzh> Dolzhs { get; set; }
    }
}