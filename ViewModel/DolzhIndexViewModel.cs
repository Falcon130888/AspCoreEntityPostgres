using AspCoreEntityPostgres.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreEntityPostgres.ViewModel
{
    public class DolzhIndexViewModel
    {
        public SelectList Otdels { get; set; }
        public IEnumerable<Dolzh> Dolzhs { get; set; }
    }
}
