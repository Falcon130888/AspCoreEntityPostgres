using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspCoreEntityPostgres.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public int IdOtdel { get; set; }
        public int IdDolzh { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
