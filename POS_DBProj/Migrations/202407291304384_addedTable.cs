namespace POS_DBProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.POS_Roles",
                c => new
                    {
                        RoleID = c.Long(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        UpdatedDate = c.DateTime(storeType: "smalldatetime"),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.POS_UserRoles",
                c => new
                    {
                        UserRoleID = c.Long(nullable: false, identity: true),
                        UserID = c.Long(nullable: false),
                        RoleID = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, storeType: "smalldatetime"),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.POS_UserRoles");
            DropTable("dbo.POS_Roles");
        }
    }
}
