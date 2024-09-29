namespace CitasMicroservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cita",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPaciente = c.Int(nullable: false),
                        Paciente = c.String(),
                        IdMedico = c.Int(nullable: false),
                        Medico = c.String(),
                        Fecha_Hora = c.DateTime(nullable: false),
                        Motivo = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cita");
        }
    }
}
