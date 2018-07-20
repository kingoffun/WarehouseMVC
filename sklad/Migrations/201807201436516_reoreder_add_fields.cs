namespace sklad.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reoreder_add_fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Things", "Account", c => c.Int(nullable: false));
            AddColumn("dbo.Things", "PassportNumber", c => c.String());
            AddColumn("dbo.Things", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Things", "Form");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Things", "Form", c => c.String());
            DropColumn("dbo.Things", "Price");
            DropColumn("dbo.Things", "PassportNumber");
            DropColumn("dbo.Things", "Account");
        }
    }
}
