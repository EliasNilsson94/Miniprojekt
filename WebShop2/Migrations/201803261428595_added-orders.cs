namespace WebShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedorders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cart_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Cart_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Orders", new[] { "Cart_Id" });
            DropTable("dbo.Orders");
        }
    }
}
