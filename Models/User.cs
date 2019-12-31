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
        public int Id_User { get; set; }
        public int Id_Otdel { get; set; }
        public int Id_Dolzh { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
