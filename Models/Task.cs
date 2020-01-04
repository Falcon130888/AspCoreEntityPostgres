using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspCoreEntityPostgres.Models
{
    public class Task
    {
        [Key]
        public int IdTask { get; set; }
        public int IdUser { get; set; }
      public  string NameTask { get; set; }
      public DateTime DateBegin { get; set; }
      public DateTime DateEnd { get; set; }
      public string TypeTask { get; set; }
    }
}
