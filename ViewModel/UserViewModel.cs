using AspCoreEntityPostgres.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AspCoreEntityPostgres.ViewModel
{
    public class UserViewModel
    {
        public SelectList Otdels { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}