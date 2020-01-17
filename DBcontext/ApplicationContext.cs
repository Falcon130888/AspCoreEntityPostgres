using AspCoreEntityPostgres.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreEntityPostgres.DBcontext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Otdel> Otdels { get; set; }
        public DbSet<Dolzh> Dolzhs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Memo> Memos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ZIK_ECM;Username=postgres;Password=2030");
        }
    }
}