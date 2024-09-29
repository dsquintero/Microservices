namespace RecetasMicroservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdReceta = c.Int(nullable: false),
                        Nombre = c.String(),
                        Dosis = c.String(),
                        Frecuencia = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Receta", t => t.IdReceta, cascadeDelete: true)
                .Index(t => t.IdReceta);
            
            CreateTable(
                "dbo.Receta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCita = c.Int(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        Paciente = c.String(),
                        IdMedico = c.Int(nullable: false),
                        Medico = c.String(),
                        Fecha_Emision = c.DateTime(nullable: false),
                        Desc = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicamento", "IdReceta", "dbo.Receta");
            DropIndex("dbo.Medicamento", new[] { "IdReceta" });
            DropTable("dbo.Receta");
            DropTable("dbo.Medicamento");
        }
    }
}
