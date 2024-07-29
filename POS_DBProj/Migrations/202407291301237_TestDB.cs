namespace POS_DBProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.POS_TransactionHeader",
                c => new
                    {
                        TransactionID = c.Long(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        PriceBeforeTax = c.Decimal(nullable: false, precision: 18, scale: 0),
                        AmountTendered = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CustomerName = c.String(nullable: false, maxLength: 50),
                        VatAmount = c.Decimal(nullable: false, precision: 18, scale: 0),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 0),
                        UserID = c.Long(nullable: false),
                        IsVoided = c.Boolean(nullable: false),
                        TicketNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.POS_Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.POS_Users",
                c => new
                    {
                        UserID = c.Long(nullable: false, identity: true),
                        UserPassword = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.POS_TransactionDetails",
                c => new
                    {
                        pID = c.Long(nullable: false, identity: true),
                        TransactionID = c.Long(nullable: false),
                        ItemQuantity = c.Int(nullable: false),
                        ProductID = c.Long(nullable: false),
                        IsDiscounted = c.Boolean(nullable: false),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.pID)
                .ForeignKey("dbo.POS_Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.POS_TransactionHeader", t => t.TransactionID, cascadeDelete: true)
                .Index(t => t.TransactionID)
                .Index(t => t.ProductID);
            
            AlterColumn("dbo.POS_Categories", "CategoryName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.POS_Leads", "Passcode", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.POS_Modules", "ModuleName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.POS_Pricing", "ProductSize", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.POS_Products", "ProductName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.POS_TransactionDetails", "TransactionID", "dbo.POS_TransactionHeader");
            DropForeignKey("dbo.POS_TransactionDetails", "ProductID", "dbo.POS_Products");
            DropForeignKey("dbo.POS_TransactionHeader", "UserID", "dbo.POS_Users");
            DropIndex("dbo.POS_TransactionDetails", new[] { "ProductID" });
            DropIndex("dbo.POS_TransactionDetails", new[] { "TransactionID" });
            DropIndex("dbo.POS_TransactionHeader", new[] { "UserID" });
            AlterColumn("dbo.POS_Products", "ProductName", c => c.String(maxLength: 50));
            AlterColumn("dbo.POS_Pricing", "ProductSize", c => c.String(maxLength: 50));
            AlterColumn("dbo.POS_Modules", "ModuleName", c => c.String(maxLength: 50));
            AlterColumn("dbo.POS_Leads", "Passcode", c => c.String(maxLength: 50));
            AlterColumn("dbo.POS_Categories", "CategoryName", c => c.String(maxLength: 50));
            DropTable("dbo.POS_TransactionDetails");
            DropTable("dbo.POS_Users");
            DropTable("dbo.POS_TransactionHeader");
        }
    }
}
