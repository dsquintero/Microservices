using RecetasMicroservice.Domain.Entities;
using System.Data.Entity;

namespace RecetasMicroservice.Infrastructure.DbContexts
{
    public class RecetasContext : DbContext
    {
        public RecetasContext() : base("name=RecetasContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receta>().
                ToTable("Receta");
            modelBuilder.Entity<Medicamento>()
                .ToTable("Medicamento");
            base.OnModelCreating(modelBuilder);
        }
    }
}