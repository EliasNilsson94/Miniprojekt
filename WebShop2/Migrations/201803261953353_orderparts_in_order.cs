namespace WebShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderparts_in_order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Orders", new[] { "Cart_Id" });
            AddColumn("dbo.OrderParts", "Order_Id", c => c.Int());
            CreateIndex("dbo.OrderParts", "Order_Id");
            AddForeignKey("dbo.OrderParts", "Order_Id", "dbo.Orders", "Id");
            DropColumn("dbo.Orders", "Cart_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Cart_Id", c => c.Int());
            DropForeignKey("dbo.OrderParts", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderParts", new[] { "Order_Id" });
            DropColumn("dbo.OrderParts", "Order_Id");
            CreateIndex("dbo.Orders", "Cart_Id");
            AddForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
