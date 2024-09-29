namespace PersonasMicroservice.Migrations
{
    using PersonasMicroservice.Domain.Entities;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonasMicroservice.Infrastructure.DbContexts.PersonasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonasMicroservice.Infrastructure.DbContexts.PersonasContext context)
        {
            context.TipoPersonas.AddOrUpdate(
                tp => tp.Id,
                new TipoPersona { Id = 1, Desc = "Médico" },
                new TipoPersona { Id = 2, Desc = "Paciente" }
                );

            context.SaveChanges();
        }
    }
}
