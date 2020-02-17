using AspCoreEntityPostgres.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreEntityPostgres.DBcontext
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Dolzh> Dolzhs { get; set; }
        public virtual DbSet<Otdel> Otdels { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<MemoCopy> MemoCopies { get; set; }
        public virtual DbSet<MemoFile> MemoFiles { get; set; }
        public virtual DbSet<Memo> Memos { get; set; }
        public virtual DbSet<MemoSignatory> MemoSignatories { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=192.168.0.9;Port=5432;Database=ZIK_ECM;Username=postgres;Password=(#$Pa$$w0rd$#)");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ZIK_ECM;Username=postgres;Password=2030");
        }
    }
}