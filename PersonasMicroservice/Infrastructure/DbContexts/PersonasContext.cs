using PersonasMicroservice.Domain.Entities;
using System.Data.Entity;

namespace PersonasMicroservice.Infrastructure.DbContexts
{
    public class PersonasContext : DbContext
    {
        public PersonasContext() : base("name=PersonasContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<TipoPersona> TipoPersonas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().
                ToTable("Persona");
            modelBuilder.Entity<TipoPersona>()
                .ToTable("TipoPersona");
            base.OnModelCreating(modelBuilder);
        }
    }
}