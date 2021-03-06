﻿using AspCoreEntityPostgres.Models;
using System.Collections.Generic;

namespace AspCoreEntityPostgres.ViewModel
{
    public class ViewModelMemos
    {
        public Memo Memo { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<MemoCopy> MemoCopies { get; set; }
        public IEnumerable<MemoFile> MemoFiles { get; set; }
    }
}
