using Microsoft.EntityFrameworkCore;

namespace SyncServer
{
    public class SyncDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dict>().HasKey(d => new { d.DBID, d.Modification_Time });
            modelBuilder.Entity<Topic>().HasKey(d => new { d.DBID, d.Modification_Time });

        }
        public SyncDBContext(DbContextOptions<SyncDBContext> options) : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Dict> Dicts { get; set; }
    }
}
