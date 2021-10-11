namespace QLRCP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplySeatTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatNo = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reservations", "SeatID", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "SeatID");
            AddForeignKey("dbo.Reservations", "SeatID", "dbo.Seats", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "SeatID", "dbo.Seats");
            DropIndex("dbo.Reservations", new[] { "SeatID" });
            DropColumn("dbo.Reservations", "SeatID");
            DropTable("dbo.Seats");
        }
    }
}
