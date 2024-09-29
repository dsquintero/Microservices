using CitasMicroservice.Infrastructure.DbContexts;
using System.Data.Entity.Migrations;

namespace CitasMicroservice.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CitasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CitasContext context)
        {

        }
    }
}
