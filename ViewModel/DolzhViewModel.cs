using AspCoreEntityPostgres.DBcontext;
using AspCoreEntityPostgres.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreEntityPostgres.ViewModel
{
    public class DolzhViewModel
    {
        public SelectList Otdels { get; set; }
        public Dolzh Dolzh { get; set; }
    }
}