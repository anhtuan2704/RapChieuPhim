namespace QLRCP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyASPNETUSER_Reservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "CustomerID", "dbo.AspNetUsers");
            DropIndex("dbo.Reservations", new[] { "CustomerID" });
            DropTable("dbo.Reservations");
        }
    }
}
