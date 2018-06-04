namespace sklad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manyToMany : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Things", name: "ParentThingId", newName: "Thing_Id");
            RenameIndex(table: "dbo.Things", name: "IX_ParentThingId", newName: "IX_Thing_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Things", name: "IX_Thing_Id", newName: "IX_ParentThingId");
            RenameColumn(table: "dbo.Things", name: "Thing_Id", newName: "ParentThingId");
        }
    }
}
