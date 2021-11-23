namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_ExpanceData", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 3));
            AlterColumn("dbo.tbl_ExpanceData", "CashBack", c => c.Decimal(nullable: false, precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_ExpanceData", "CashBack", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.tbl_ExpanceData", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
