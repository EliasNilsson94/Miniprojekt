namespace WebShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inputvirtualfieldfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Adress_Id", "dbo.Adresses");
            DropForeignKey("dbo.OrderParts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Carts", new[] { "Customer_Id" });
            DropIndex("dbo.Customers", new[] { "Adress_Id" });
            DropIndex("dbo.OrderParts", new[] { "Product_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Carts", name: "Customer_Id", newName: "CustomerID");
            RenameColumn(table: "dbo.Customers", name: "Adress_Id", newName: "AdressID");
            RenameColumn(table: "dbo.OrderParts", name: "Product_Id", newName: "ProductID");
            RenameColumn(table: "dbo.Orders", name: "Customer_Id", newName: "CustomerID");
            AlterColumn("dbo.Carts", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "AdressID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderParts", "ProductID", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Carts", "CustomerID");
            CreateIndex("dbo.Customers", "AdressID");
            CreateIndex("dbo.OrderParts", "ProductID");
            CreateIndex("dbo.Orders", "CustomerID");
            AddForeignKey("dbo.Carts", "CustomerID", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "AdressID", "dbo.Adresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderParts", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderParts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Customers", "AdressID", "dbo.Adresses");
            DropForeignKey("dbo.Carts", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.OrderParts", new[] { "ProductID" });
            DropIndex("dbo.Customers", new[] { "AdressID" });
            DropIndex("dbo.Carts", new[] { "CustomerID" });
            AlterColumn("dbo.Orders", "CustomerID", c => c.Int());
            AlterColumn("dbo.OrderParts", "ProductID", c => c.Int());
            AlterColumn("dbo.Customers", "AdressID", c => c.Int());
            AlterColumn("dbo.Carts", "CustomerID", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "CustomerID", newName: "Customer_Id");
            RenameColumn(table: "dbo.OrderParts", name: "ProductID", newName: "Product_Id");
            RenameColumn(table: "dbo.Customers", name: "AdressID", newName: "Adress_Id");
            RenameColumn(table: "dbo.Carts", name: "CustomerID", newName: "Customer_Id");
            CreateIndex("dbo.Orders", "Customer_Id");
            CreateIndex("dbo.OrderParts", "Product_Id");
            CreateIndex("dbo.Customers", "Adress_Id");
            CreateIndex("dbo.Carts", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.OrderParts", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Customers", "Adress_Id", "dbo.Adresses", "Id");
            AddForeignKey("dbo.Carts", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
