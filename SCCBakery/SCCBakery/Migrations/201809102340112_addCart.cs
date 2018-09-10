namespace SCCBakery.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCart : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Carts",
            //    c => new
            //        {
            //            CartID = c.Int(nullable: false, identity: true),
            //            CustomerID = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CartID)
            //    .ForeignKey("dbo.CustomerInfo", t => t.CustomerID, cascadeDelete: true)
            //    .Index(t => t.CustomerID);
            
            //CreateTable(
            //    "dbo.CartItems",
            //    c => new
            //        {
            //            CartItemID = c.String(nullable: false, maxLength: 128),
            //            CartID = c.Int(nullable: false),
            //            ProductID = c.Int(nullable: false),
            //            Quantity = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.CartItemID)
            //    .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
            //    .ForeignKey("dbo.Carts", t => t.CartID, cascadeDelete: true)
            //    .Index(t => t.CartID)
            //    .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "CustomerID", "dbo.CustomerInfo");
            DropForeignKey("dbo.CartItems", "CartID", "dbo.Carts");
            DropForeignKey("dbo.CartItems", "ProductID", "dbo.Products");
            DropIndex("dbo.CartItems", new[] { "ProductID" });
            DropIndex("dbo.CartItems", new[] { "CartID" });
            DropIndex("dbo.Carts", new[] { "CustomerID" });
            DropTable("dbo.CartItems");
            DropTable("dbo.Carts");
        }
    }
}
