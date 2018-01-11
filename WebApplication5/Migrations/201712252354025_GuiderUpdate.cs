namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuiderUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guiders", "ChargePerHour", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guiders", "ChargePerHour");
        }
    }
}
