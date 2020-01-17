using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreEntityPostgres.Models
{
    public class Memo
    {
        [Key]
        public int IdMemo { get; set; }

        public DateTime DateCreate { get; set; }
        public DateTime DateEnd { get; set; }
        public bool IsActive { get; set; }
        public int Status { get; set; }
        public string Thema { get; set; }
        public string Content { get; set; }

        [ForeignKey("User")]
        public int IdUserTo { get; set; }
        public User UserTO { get; set; }

        [ForeignKey("User")]
        public int IdUserCopy { get; set; }
        public User UserCopy { get; set; }

        [ForeignKey("User")]
        public int IdUserExecutor { get; set; }
        public User UserExecutor { get; set; }
    }
}
