namespace SCCBakery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDBContext : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Orders", "OrderTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderTime");
        }
    }
}
