using Microsoft.EntityFrameworkCore;
using FutureValue.Domain;
using FutureValue.Persistence.Configurations;

namespace FutureValue.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        { }

        public DbSet<FutureValues> FutureValues { get; set; }
        public DbSet<ExecutionDetails> ExecutionDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FutureValueConfiguration());
            modelBuilder.ApplyConfiguration(new ExecutionDetailsConfiguration());
        }
    }
}
