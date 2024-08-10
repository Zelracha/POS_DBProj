namespace POS_DBProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangedDecimalandFolder : DbMigration
    {
        public override void Up()
        {
            //  drop the primary key constraint to alter the identity column
            DropPrimaryKey("dbo.POS_TransactionDetails");

    
            DropColumn("dbo.POS_TransactionDetails", "pID");

            // Add the new identity column "Id"
            AddColumn("dbo.POS_TransactionDetails", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.POS_TransactionDetails", "Id");

           
            AlterColumn("dbo.POS_Pricing", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.POS_TransactionDetails", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.POS_TransactionHeader", "PriceBeforeTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.POS_TransactionHeader", "AmountTendered", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.POS_TransactionHeader", "VatAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.POS_TransactionHeader", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }

        public override void Down()
        {
          
            DropPrimaryKey("dbo.POS_TransactionDetails");
            DropColumn("dbo.POS_TransactionDetails", "Id");

          
            AddColumn("dbo.POS_TransactionDetails", "pID", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.POS_TransactionDetails", "pID");

  
            AlterColumn("dbo.POS_TransactionHeader", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.POS_TransactionHeader", "VatAmount", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.POS_TransactionHeader", "AmountTendered", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.POS_TransactionHeader", "PriceBeforeTax", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.POS_TransactionDetails", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.POS_Pricing", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 0));
        }
    }
}
