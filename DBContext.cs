using Microsoft.EntityFrameworkCore;

namespace SyncServer
{
    public class SyncDBContext : DbContext
    {
        public SyncDBContext(DbContextOptions<SyncDBContext> options) : base(options)
        {
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Dict> Dicts { get; set; }
    }
}
