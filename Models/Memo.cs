using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreEntityPostgres.Models
{
    public class Memo
    {
        [Key]
        public int IdMemo { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime DateCreate { get; set; }

        [Display(Name = "Дата дата завершения")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Активна")]
        public bool IsActive { get; set; }

        [Display(Name = "Тема")]
        public string Thema { get; set; }

        [Display(Name = "Содержание")]
        [DataType(DataType.MultilineText)]
        [UIHint("DisplayForContent")]
        public string Content { get; set; }

        public int IdStatus { get; set; }
        [Display(Name = "Статус")]
        [ForeignKey("IdStatus ")]
        public Status Status { get; set; }

        public int IdUserTo { get; set; }
        [Display(Name = "Кому")]
        [ForeignKey("IdUserTo ")]
        public User UserTO { get; set; }

        public int? IdUserExecutor { get; set; }
        [Display(Name = "Исполнитель")]
        [ForeignKey("IdUserExecutor")]
        public User UserExecutor { get; set; }

        public List<MemoCopy> MemoCopies { get; }
        public List<MemoFile> MemoFiles { get; }
    }

    public class MemoCopy
    {
        [Key]
        public int IdMemoCopy { get; set; }

        public int IdMemo { get; set; }
        [ForeignKey("IdMemo")]
        public Memo Memo { get; set; }

        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }

    public class MemoFile
    {
        [Key]
        public int IdMemoFile { get; set; }

        public int IdMemo { get; set; }
        [ForeignKey("IdMemo")]
        public Memo Memo { get; set; }

        public string Format { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}