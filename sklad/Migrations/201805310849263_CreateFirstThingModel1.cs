namespace sklad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFirstThingModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Things", "InventoryNumb", c => c.Int(nullable: false));
            AddColumn("dbo.Things", "MeasureUnit", c => c.Int(nullable: false));
            AddColumn("dbo.Things", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Things", "FromWhere", c => c.String());
            AddColumn("dbo.Things", "DocNumber", c => c.String());
            AddColumn("dbo.Things", "DocDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Things", "DocType", c => c.Int(nullable: false));
            AddColumn("dbo.Things", "Form", c => c.String());
            AddColumn("dbo.Things", "ProdType", c => c.Int(nullable: false));
            AddColumn("dbo.Things", "WorkName", c => c.String());
            AddColumn("dbo.Things", "ParentThingId", c => c.Int());
            CreateIndex("dbo.Things", "ParentThingId");
            AddForeignKey("dbo.Things", "ParentThingId", "dbo.Things", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Things", "ParentThingId", "dbo.Things");
            DropIndex("dbo.Things", new[] { "ParentThingId" });
            DropColumn("dbo.Things", "ParentThingId");
            DropColumn("dbo.Things", "WorkName");
            DropColumn("dbo.Things", "ProdType");
            DropColumn("dbo.Things", "Form");
            DropColumn("dbo.Things", "DocType");
            DropColumn("dbo.Things", "DocDate");
            DropColumn("dbo.Things", "DocNumber");
            DropColumn("dbo.Things", "FromWhere");
            DropColumn("dbo.Things", "Quantity");
            DropColumn("dbo.Things", "MeasureUnit");
            DropColumn("dbo.Things", "InventoryNumb");
        }
    }
}
