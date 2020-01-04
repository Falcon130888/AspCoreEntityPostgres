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

            if (!context.Otdels.Any())
            {
                context.Otdels.AddRange(
                    new Otdel
                    {
                        NameOtdel = "Канцелярия",
                        LeadOtdel = "Иванов",
                    }
                );
                context.SaveChanges();
            }

            if (!context.Dolzhs.Any())
            {
                context.Dolzhs.AddRange(
                    new Dolzh
                    {
                        IdOtdel = 1,
                        NameDolzh = "Секретарь",
                    }
                );
                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(
                    new Task
                    {
                        IdUser = 2,
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
                        IdDolzh =1,
                        IdOtdel =1,
                    },
                    new User
                    {
                        Name = "Anton",
                        Age = 30,
                        IdDolzh = 1,
                        IdOtdel = 1,
                    },
                    new User
                    {
                        Name = "Vasya",
                        Age = 35,
                        IdDolzh = 1,
                        IdOtdel = 1,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
