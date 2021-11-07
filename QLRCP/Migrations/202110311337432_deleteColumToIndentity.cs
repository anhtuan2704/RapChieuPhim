namespace QLRCP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteColumToIndentity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ShowDays", "Name");
            DropColumn("dbo.ShowDays", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShowDays", "Image", c => c.String());
            AddColumn("dbo.ShowDays", "Name", c => c.String());
        }
    }
}
