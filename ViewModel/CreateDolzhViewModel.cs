using AspCoreEntityPostgres.DBcontext;
using AspCoreEntityPostgres.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEntityPostgres.ViewModel
{
    public class CreateDolzhViewModel
    {

        public List<Otdel> OtdelList { get; set; } 
        public SelectList Otdels { get; set; }

        public Dolzh dolzh { get; set; }
    }
}
