namespace QLRCP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyShowTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Reservations", "ShowID", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "ShowID");
            AddForeignKey("dbo.Reservations", "ShowID", "dbo.Shows", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ShowID", "dbo.Shows");
            DropIndex("dbo.Reservations", new[] { "ShowID" });
            DropColumn("dbo.Reservations", "ShowID");
            DropTable("dbo.Shows");
        }
    }
}
