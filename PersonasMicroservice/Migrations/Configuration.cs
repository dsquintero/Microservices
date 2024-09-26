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
                tp => tp.Desc,
                new TipoPersona { Desc = "Médico" },
                new TipoPersona { Desc = "Paciente" }
                );

            context.SaveChanges();
        }
    }
}
