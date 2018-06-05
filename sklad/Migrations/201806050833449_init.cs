namespace sklad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Things",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SerialNumber = c.String(),
                        ProduceDate = c.DateTime(nullable: false),
                        InventoryNumb = c.Int(nullable: false),
                        MeasureUnit = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        FromWhere = c.String(),
                        DocNumber = c.String(),
                        DocDate = c.DateTime(nullable: false),
                        DocType = c.Int(nullable: false),
                        Form = c.String(),
                        ProdType = c.Int(nullable: false),
                        WorkName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Includes",
                c => new
                    {
                        Thing_Id = c.Int(nullable: false),
                        Thing_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Thing_Id, t.Thing_Id1 })
                .ForeignKey("dbo.Things", t => t.Thing_Id)
                .ForeignKey("dbo.Things", t => t.Thing_Id1)
                .Index(t => t.Thing_Id)
                .Index(t => t.Thing_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Includes", "Thing_Id1", "dbo.Things");
            DropForeignKey("dbo.Includes", "Thing_Id", "dbo.Things");
            DropIndex("dbo.Includes", new[] { "Thing_Id1" });
            DropIndex("dbo.Includes", new[] { "Thing_Id" });
            DropTable("dbo.Includes");
            DropTable("dbo.Things");
        }
    }
}
