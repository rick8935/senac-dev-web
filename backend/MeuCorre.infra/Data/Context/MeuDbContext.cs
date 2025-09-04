using MeuCorre.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuCorre.infra.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<DbContext> opcoes) : base(opcoes)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(MeuDbContext).Assembly);
        }
    }
}
