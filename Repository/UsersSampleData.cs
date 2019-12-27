using AspCoreEntityPostgres.DBcontext;
using System.Linq;
using AspCoreEntityPostgres.Models;

namespace AspCoreEntityPostgres.Repository
{
    public static class UsersSampleData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Name = "Stas",
                        Age = 25,
                    },
                    new User
                    {
                        Name = "Anton",
                        Age = 30,
                    },
                    new User
                    {
                        Name = "Vasya",
                        Age = 35,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
