namespace PersonasMicroservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTipoPersona = c.Int(nullable: false),
                        Identificacion = c.String(maxLength: 20),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Fecha_Nacimiento = c.DateTime(nullable: false, storeType: "date"),
                        Genero = c.String(maxLength: 1),
                        Telefono = c.String(),
                        Email = c.String(),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoPersona", t => t.IdTipoPersona, cascadeDelete: true)
                .Index(t => t.IdTipoPersona)
                .Index(t => t.Identificacion, unique: true);
            
            CreateTable(
                "dbo.TipoPersona",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Desc = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persona", "IdTipoPersona", "dbo.TipoPersona");
            DropIndex("dbo.Persona", new[] { "Identificacion" });
            DropIndex("dbo.Persona", new[] { "IdTipoPersona" });
            DropTable("dbo.TipoPersona");
            DropTable("dbo.Persona");
        }
    }
}
