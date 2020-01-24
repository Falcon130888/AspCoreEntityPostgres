using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEntityPostgres.Models
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        public string NameStatus { get; set; }
    }
}
