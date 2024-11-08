namespace Examen_Entity_08112024.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumeroRegistroToMultaAndAccidente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accidentes", "NumeroRegistro", c => c.Int(nullable: false));
            AddColumn("dbo.Multas", "NumeroRegistro", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Multas", "NumeroRegistro");
            DropColumn("dbo.Accidentes", "NumeroRegistro");
        }
    }
}
