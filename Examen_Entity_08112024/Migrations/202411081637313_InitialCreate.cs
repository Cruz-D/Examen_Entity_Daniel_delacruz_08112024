namespace Examen_Entity_08112024.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accidentes",
                c => new
                    {
                        AccidenteId = c.Int(nullable: false, identity: true),
                        FechaHora = c.DateTime(nullable: false),
                        Lugar = c.String(),
                    })
                .PrimaryKey(t => t.AccidenteId);
            
            CreateTable(
                "dbo.PersonasAccidentes",
                c => new
                    {
                        PersonasAccidenteId = c.Int(nullable: false, identity: true),
                        PersonaId = c.Int(nullable: false),
                        AccidenteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonasAccidenteId)
                .ForeignKey("dbo.Accidentes", t => t.AccidenteId, cascadeDelete: true)
                .ForeignKey("dbo.Personas", t => t.PersonaId, cascadeDelete: true)
                .Index(t => t.PersonaId)
                .Index(t => t.AccidenteId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Direccion = c.String(),
                        Poblacion = c.String(),
                        Telefono = c.String(),
                        DNI = c.String(),
                    })
                .PrimaryKey(t => t.PersonaId);
            
            CreateTable(
                "dbo.Multas",
                c => new
                    {
                        MultaId = c.Int(nullable: false),
                        FechaHora = c.DateTime(nullable: false),
                        Lugar = c.String(),
                        Importe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PersonaId = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MultaId)
                .ForeignKey("dbo.Vehiculoes", t => t.MultaId)
                .ForeignKey("dbo.Personas", t => t.MultaId)
                .Index(t => t.MultaId);
            
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        VehiculoId = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        PersonaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehiculoId)
                .ForeignKey("dbo.Personas", t => t.PersonaId, cascadeDelete: true)
                .Index(t => t.PersonaId);
            
            CreateTable(
                "dbo.VehiculoAccidentes",
                c => new
                    {
                        VehiculoAccidenteId = c.Int(nullable: false, identity: true),
                        VehiculoId = c.Int(nullable: false),
                        AccidenteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehiculoAccidenteId)
                .ForeignKey("dbo.Accidentes", t => t.AccidenteId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId)
                .Index(t => t.AccidenteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonasAccidentes", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Multas", "MultaId", "dbo.Personas");
            DropForeignKey("dbo.VehiculoAccidentes", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.VehiculoAccidentes", "AccidenteId", "dbo.Accidentes");
            DropForeignKey("dbo.Vehiculoes", "PersonaId", "dbo.Personas");
            DropForeignKey("dbo.Multas", "MultaId", "dbo.Vehiculoes");
            DropForeignKey("dbo.PersonasAccidentes", "AccidenteId", "dbo.Accidentes");
            DropIndex("dbo.VehiculoAccidentes", new[] { "AccidenteId" });
            DropIndex("dbo.VehiculoAccidentes", new[] { "VehiculoId" });
            DropIndex("dbo.Vehiculoes", new[] { "PersonaId" });
            DropIndex("dbo.Multas", new[] { "MultaId" });
            DropIndex("dbo.PersonasAccidentes", new[] { "AccidenteId" });
            DropIndex("dbo.PersonasAccidentes", new[] { "PersonaId" });
            DropTable("dbo.VehiculoAccidentes");
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.Multas");
            DropTable("dbo.Personas");
            DropTable("dbo.PersonasAccidentes");
            DropTable("dbo.Accidentes");
        }
    }
}
