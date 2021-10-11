namespace QLRCP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyCinemaShowDayShowTimeMovieSeat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discriptiion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discription = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShowDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShowTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Shows", "CinemaID", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "MovieID", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "ShowDayID", c => c.Int(nullable: false));
            AddColumn("dbo.Shows", "ShowTimeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Shows", "CinemaID");
            CreateIndex("dbo.Shows", "MovieID");
            CreateIndex("dbo.Shows", "ShowDayID");
            CreateIndex("dbo.Shows", "ShowTimeId");
            AddForeignKey("dbo.Shows", "CinemaID", "dbo.Cinemas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Shows", "MovieID", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Shows", "ShowDayID", "dbo.ShowDays", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Shows", "ShowTimeId", "dbo.ShowTimes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "ShowTimeId", "dbo.ShowTimes");
            DropForeignKey("dbo.Shows", "ShowDayID", "dbo.ShowDays");
            DropForeignKey("dbo.Shows", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Shows", "CinemaID", "dbo.Cinemas");
            DropIndex("dbo.Shows", new[] { "ShowTimeId" });
            DropIndex("dbo.Shows", new[] { "ShowDayID" });
            DropIndex("dbo.Shows", new[] { "MovieID" });
            DropIndex("dbo.Shows", new[] { "CinemaID" });
            DropColumn("dbo.Shows", "ShowTimeId");
            DropColumn("dbo.Shows", "ShowDayID");
            DropColumn("dbo.Shows", "MovieID");
            DropColumn("dbo.Shows", "CinemaID");
            DropTable("dbo.ShowTimes");
            DropTable("dbo.ShowDays");
            DropTable("dbo.Movies");
            DropTable("dbo.Cinemas");
        }
    }
}
