namespace PersonasMicroservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaDeNacimiento = c.DateTime(nullable: false),
                        IdTipoPersona = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoPersona", t => t.IdTipoPersona, cascadeDelete: true)
                .Index(t => t.IdTipoPersona);
            
            CreateTable(
                "dbo.TipoPersona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persona", "IdTipoPersona", "dbo.TipoPersona");
            DropIndex("dbo.Persona", new[] { "IdTipoPersona" });
            DropTable("dbo.TipoPersona");
            DropTable("dbo.Persona");
        }
    }
}
