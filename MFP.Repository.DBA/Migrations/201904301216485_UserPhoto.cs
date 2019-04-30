namespace MFP.Repository.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Photo", c => c.String(maxLength: 256, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Photo");
        }
    }
}
