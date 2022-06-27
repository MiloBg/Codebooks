using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<LookupMaster> LookupMasters { get; set; }
        public DbSet<LookupValue> LookupValues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<LookupValue>(x => x.HasKey(ac => new { ac.LookupMasterId, ac.Key }));
        }
    }
}