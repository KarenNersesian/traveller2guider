namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationDateStart", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "ReservationDateStart");
        }
    }
}
