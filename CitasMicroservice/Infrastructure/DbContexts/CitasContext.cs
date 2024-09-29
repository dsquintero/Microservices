using CitasMicroservice.Domain.Entities;
using System.Data.Entity;

namespace CitasMicroservice.Infrastructure.DbContexts
{
    public class CitasContext : DbContext
    {
        public CitasContext() : base("name=CitasContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Cita> Citas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>().
                ToTable("Cita");

            base.OnModelCreating(modelBuilder);
        }
    }
}