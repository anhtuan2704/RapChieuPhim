namespace QLRCP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumNameToIdentity1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShowDays", "Name", c => c.String());
            AddColumn("dbo.ShowDays", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShowDays", "Image");
            DropColumn("dbo.ShowDays", "Name");
        }
    }
}
