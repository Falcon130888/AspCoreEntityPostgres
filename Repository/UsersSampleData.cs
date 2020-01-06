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

            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role
                    {
                        NameRole = "Администратор"
                    },
                    new Role
                    {
                        NameRole = "ГДО"
                    },
                    new Role
                    {
                        NameRole = "Бухгалтерия"
                    },
                    new Role
                    {
                        NameRole = "Читатель"
                    }
                );
                context.SaveChanges();
            }

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
                        UserFIO = "Нейфельд С.В.",
                        UserAdLogin = "NeyfeldSV",
                        UserPassword = "",
                        UserLogin = "Нейфельд",
                        UserConf = 5,
                        IdDolzh =1,
                        IdOtdel =1,
                        IdRole = 1,
                    },
                    new User
                    {
                        UserFIO = "Иванов С.В.",
                        UserAdLogin = "Ivanov",
                        UserPassword = "",
                        UserLogin = "Иванов",
                        UserConf = 5,
                        IdDolzh = 1,
                        IdOtdel = 1,
                        IdRole = 1,
                    },
                    new User
                    {
                        UserFIO = "Петров С.В.",
                        UserAdLogin = "Petrov",
                        UserPassword = "",
                        UserLogin = "Петров",
                        UserConf = 5,
                        IdDolzh = 1,
                        IdOtdel = 1,
                        IdRole = 1,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
