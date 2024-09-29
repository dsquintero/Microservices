using RecetasMicroservice.Infrastructure.DbContexts;
using System.Data.Entity.Migrations;

namespace RecetasMicroservice.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RecetasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RecetasContext context)
        {


        }
    }
}
