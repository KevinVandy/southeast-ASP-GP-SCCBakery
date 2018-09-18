namespace SCCBakery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedorder : DbMigration
    {
        public override void Up()
        {
           // AlterColumn("dbo.Orders", "CustomerID", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
        }
    }
}
