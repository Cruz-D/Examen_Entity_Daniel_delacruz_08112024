namespace Examen_Entity_08112024.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRolePersona : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "Rol", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "Rol");
        }
    }
}
