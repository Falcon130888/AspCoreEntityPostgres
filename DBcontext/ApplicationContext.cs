using AspCoreEntityPostgres.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreEntityPostgres.DBcontext
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Otdel> Otdels { get; set; }
        public DbSet<Dolzh> Dolzhs { get; set; }


     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dolzh>().HasOne(d => d.Otdel);
       }


     public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=STAS;initial catalog=ZIK_ECM; Integrated Security=True");
        }
    }
}
