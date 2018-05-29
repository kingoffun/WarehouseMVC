namespace sklad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFirstThingModel : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Things");
        }
    }
}
