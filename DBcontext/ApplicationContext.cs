using AspCoreEntityPostgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspCoreEntityPostgres.DBcontext
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Otdel> Otdels { get; set; }
        public DbSet<Dolzh> Dolzhs { get; set; }
        public DbSet<Role> Roles { get; set; }


        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

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
            optionsBuilder.UseLoggerFactory(MyLoggerFactory).UseNpgsql("Host=localhost;Port=5432;Database=ZIK_ECM;Username=postgres;Password=2030");
        }
    }
}