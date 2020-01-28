using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreEntityPostgres.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string UserFIO { get; set; }
        public string UserAdLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserLogin { get; set; }
        public int UserConf { get; set; }

        // Foreign keys
        [ForeignKey("Otdel")]
        public int IdOtdel { get; set; }
        public Otdel Otdel { get; set; }

       [ForeignKey("Dolzh")]
        public int IdDolzh { get; set; }
        public Dolzh Dolzh { get; set; }

        [ForeignKey("Role")]
        public int IdRole { get; set; }
        public Role Role { get; set; }
    }
}