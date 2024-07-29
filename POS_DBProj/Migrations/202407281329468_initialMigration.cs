namespace POS_DBProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.POS_Categories",
                c => new
                    {
                        CategoryID = c.Long(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdateDate = c.DateTime(storeType: "smalldatetime"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.POS_Leads",
                c => new
                    {
                        LeadID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        Passcode = c.String(maxLength: 50),
                        UpdatedDate = c.DateTime(storeType: "smalldatetime"),
                    })
                .PrimaryKey(t => t.LeadID);
            
            CreateTable(
                "dbo.POS_ModuleRoles",
                c => new
                    {
                        ModuleRoleID = c.Long(nullable: false, identity: true),
                        RoleID = c.Long(nullable: false),
                        ModuleID = c.Long(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleRoleID);
            
            CreateTable(
                "dbo.POS_Modules",
                c => new
                    {
                        ModuleId = c.Long(nullable: false, identity: true),
                        ModuleName = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedDate = c.DateTime(storeType: "smalldatetime"),
                        Controller = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.POS_Pricing",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ProductID = c.Long(nullable: false),
                        ProductSize = c.String(maxLength: 50),
                        ProductPrice = c.Decimal(nullable: false, precision: 18, scale: 0),
                        CreatedDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedDate = c.DateTime(storeType: "smalldatetime"),
                        IsDeleted = c.Boolean(nullable: false),
                        CategoryID = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.POS_Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.POS_Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.POS_Products",
                c => new
                    {
                        ProductID = c.Long(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 50),
                        CategoryID = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedDate = c.DateTime(storeType: "smalldatetime"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.POS_Pricing", "ProductID", "dbo.POS_Products");
            DropForeignKey("dbo.POS_Pricing", "CategoryID", "dbo.POS_Categories");
            DropIndex("dbo.POS_Pricing", new[] { "CategoryID" });
            DropIndex("dbo.POS_Pricing", new[] { "ProductID" });
            DropTable("dbo.POS_Products");
            DropTable("dbo.POS_Pricing");
            DropTable("dbo.POS_Modules");
            DropTable("dbo.POS_ModuleRoles");
            DropTable("dbo.POS_Leads");
            DropTable("dbo.POS_Categories");
        }
    }
}
