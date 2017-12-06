namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGuiderAndTraveller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guiders", "ImageFullPath", c => c.String(maxLength: 256));
            AddColumn("dbo.Travellers", "ImageFullPath", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Travellers", "ImageFullPath");
            DropColumn("dbo.Guiders", "ImageFullPath");
        }
    }
}
