namespace SCCBakery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedproducts : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Products", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImagePath");
        }
    }
}
