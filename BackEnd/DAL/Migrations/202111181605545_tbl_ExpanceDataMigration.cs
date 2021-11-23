namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tbl_ExpanceDataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_ExpanceData",
                c => new
                    {
                        ExpnceID = c.Int(nullable: false, identity: true),
                        ExpanceItem = c.String(),
                        ExpanceDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceBreakUp = c.String(),
                        PaymentMethod = c.String(),
                        CashBack = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpnceID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_ExpanceData");
        }
    }
}
