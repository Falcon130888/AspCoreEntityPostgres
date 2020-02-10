using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreEntityPostgres.Models
{
    public class Otdel
    {
        [Key]
        public int IdOtdel { get; set; }
        public string NameOtdel { get; set; }

        [ForeignKey("LeadOtdel")]
        public int? IdLeadOtdel { get; set; }
        public virtual User LeadOtdel { get; set; }

        public List<Dolzh> Dolzhs { get;}
    }
}