namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstdbmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Email",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        emailSendTo = c.String(),
                        emailSendFrom = c.String(),
                        emailBody = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserID = c.String(),
                        FullName = c.String(),
                        UserEmail = c.String(),
                        UserPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_Users");
            DropTable("dbo.tbl_Email");
        }
    }
}
