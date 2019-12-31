using AspCoreEntityPostgres.DBcontext;
using System.Linq;
using AspCoreEntityPostgres.Models;
using System;

namespace AspCoreEntityPostgres.Repository
{
    public static class UsersSampleData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Dolzhs.Any())
            {
                context.Dolzhs.AddRange(
                    new Dolzh
                    {
                        Id_Dolzh = 1,
                        Id_Otdel = 1,
                        NameDolzh = "Секретарь",
                    }
                );
                context.SaveChanges();
            }

            if (!context.Otdels.Any())
            {
                context.Otdels.AddRange(
                    new Otdel
                    {
                        Id_Otdel = 1,
                        NameOtdel = "Канцелярия",
                        LeadOtdel = "Иванов",
                    }
                );
                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new Task
                    {
                        Id_User = 2,
                        NameTask = "123",
                        DateBegin = DateTime.Now,
                        DateEnd = DateTime.Now,
                        TypeTask = "123"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Name = "Stas",
                        Age = 25,
                        Id_Dolzh =1,
                        Id_Otdel =1,
                    },
                    new User
                    {
                        Name = "Anton",
                        Age = 30,
                        Id_Dolzh = 1,
                        Id_Otdel = 1,
                    },
                    new User
                    {
                        Name = "Vasya",
                        Age = 35,
                        Id_Dolzh = 1,
                        Id_Otdel = 1,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
