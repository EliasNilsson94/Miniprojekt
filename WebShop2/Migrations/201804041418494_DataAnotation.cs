namespace WebShop2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataAnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adresses", "StreetAdress", c => c.String(nullable: false));
            AlterColumn("dbo.Adresses", "PostalCode", c => c.String(nullable: false));
            AlterColumn("dbo.Adresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            AlterColumn("dbo.Adresses", "City", c => c.String());
            AlterColumn("dbo.Adresses", "PostalCode", c => c.String());
            AlterColumn("dbo.Adresses", "StreetAdress", c => c.String());
        }
    }
}
