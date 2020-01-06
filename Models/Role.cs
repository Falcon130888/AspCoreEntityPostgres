using System.ComponentModel.DataAnnotations;

namespace AspCoreEntityPostgres.Models
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        public string NameRole { get; set; }
    }
}