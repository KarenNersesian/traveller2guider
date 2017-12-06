namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityID = c.Int(nullable: false, identity: true),
                        NameOfActivity = c.String(maxLength: 20),
                        ActivityAdress = c.String(maxLength: 50),
                        Activity_Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Activity_Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 2000),
                        Image = c.String(maxLength: 256),
                        GuiderID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ActivityID)
                .ForeignKey("dbo.Guiders", t => t.GuiderID)
                .Index(t => t.GuiderID);
            
            CreateTable(
                "dbo.Guiders",
                c => new
                    {
                        GuiderID = c.String(nullable: false, maxLength: 128),
                        Image = c.String(maxLength: 256),
                        Skype = c.String(maxLength: 256),
                        AboutMe = c.String(maxLength: 2000),
                        AdressOfTaking = c.String(maxLength: 256),
                        Country = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Adress = c.String(maxLength: 100),
                        IBAN = c.String(maxLength: 256),
                        Passport = c.String(maxLength: 256),
                        DocumentPDF = c.String(maxLength: 256),
                        Latitude = c.Double(),
                        Longitude = c.Double(),
                        IsAccepted = c.Boolean(nullable: false),
                        CancellationPolicyID = c.Int(),
                        PremiumID = c.Int(),
                    })
                .PrimaryKey(t => t.GuiderID)
                .ForeignKey("dbo.AspNetUsers", t => t.GuiderID)
                .ForeignKey("dbo.CancellationPolicies", t => t.CancellationPolicyID)
                .ForeignKey("dbo.Premiums", t => t.PremiumID)
                .Index(t => t.GuiderID)
                .Index(t => t.CancellationPolicyID)
                .Index(t => t.PremiumID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Type = c.String(maxLength: 256),
                        Name = c.String(maxLength: 256),
                        Lastname = c.String(maxLength: 256),
                        Birthday = c.DateTime(),
                        Gender = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                        ConversationID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Conversations", t => t.ConversationID, cascadeDelete: true)
                .Index(t => t.ConversationID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false),
                        ConversationCreateDate = c.DateTime(nullable: false),
                        Traveller_TravellerID = c.String(maxLength: 128),
                        Guider_GuiderID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Travellers", t => t.Traveller_TravellerID)
                .ForeignKey("dbo.Reservations", t => t.ReservationID)
                .ForeignKey("dbo.Guiders", t => t.Guider_GuiderID)
                .Index(t => t.ReservationID)
                .Index(t => t.Traveller_TravellerID)
                .Index(t => t.Guider_GuiderID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.Int(nullable: false, identity: true),
                        IsAccepted = c.Boolean(nullable: false),
                        IsBilled = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        CreditCardType = c.Int(),
                        CostOfEuros = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherCostOfEuros = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Country_Bill = c.String(maxLength: 256),
                        FirstName_Bill = c.String(maxLength: 256),
                        LastName_Bill = c.String(maxLength: 256),
                        StreetAdress1_Bill = c.String(maxLength: 256),
                        StreetAdress2_Bill = c.String(maxLength: 256),
                        City_Bill = c.String(maxLength: 256),
                        State_Bill = c.String(maxLength: 256),
                        ZipCode_Bill = c.String(maxLength: 50),
                        PhoneNumber_Bill = c.String(maxLength: 256),
                        GuiderID = c.String(maxLength: 128),
                        TravellerID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReservationID)
                .ForeignKey("dbo.Guiders", t => t.GuiderID)
                .ForeignKey("dbo.Travellers", t => t.TravellerID)
                .Index(t => t.GuiderID)
                .Index(t => t.TravellerID);
            
            CreateTable(
                "dbo.Travellers",
                c => new
                    {
                        TravellerID = c.String(nullable: false, maxLength: 128),
                        Image = c.String(maxLength: 256),
                        Skype = c.String(maxLength: 256),
                        AboutMe = c.String(maxLength: 256),
                        Country = c.String(maxLength: 256),
                        City = c.String(maxLength: 256),
                        Adress = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.TravellerID)
                .ForeignKey("dbo.AspNetUsers", t => t.TravellerID)
                .Index(t => t.TravellerID);
            
            CreateTable(
                "dbo.GuiderToTravellerBans",
                c => new
                    {
                        GuiderID = c.String(nullable: false, maxLength: 128),
                        TravellerID = c.String(nullable: false, maxLength: 128),
                        DateOfBanning = c.DateTime(nullable: false),
                        ReasonForBanning = c.String(maxLength: 256),
                        IsBanned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.GuiderID, t.TravellerID })
                .ForeignKey("dbo.Guiders", t => t.GuiderID, cascadeDelete: true)
                .ForeignKey("dbo.Travellers", t => t.TravellerID, cascadeDelete: true)
                .Index(t => t.GuiderID)
                .Index(t => t.TravellerID);
            
            CreateTable(
                "dbo.TravellerToGuiderFavourites",
                c => new
                    {
                        GuiderID = c.String(nullable: false, maxLength: 128),
                        TravellerID = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        FavouriteEntry = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.GuiderID, t.TravellerID })
                .ForeignKey("dbo.Guiders", t => t.GuiderID, cascadeDelete: true)
                .ForeignKey("dbo.Travellers", t => t.TravellerID, cascadeDelete: true)
                .Index(t => t.GuiderID)
                .Index(t => t.TravellerID);
            
            CreateTable(
                "dbo.TravellerToGuiderRates",
                c => new
                    {
                        GuiderID = c.String(nullable: false, maxLength: 128),
                        TravellerID = c.String(nullable: false, maxLength: 128),
                        Rate = c.Int(nullable: false),
                        Comment = c.String(),
                        Rate_Entry = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.GuiderID, t.TravellerID })
                .ForeignKey("dbo.Guiders", t => t.GuiderID, cascadeDelete: true)
                .ForeignKey("dbo.Travellers", t => t.TravellerID, cascadeDelete: true)
                .Index(t => t.GuiderID)
                .Index(t => t.TravellerID);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CancellationPolicies",
                c => new
                    {
                        CancellationPolicyID = c.Int(nullable: false, identity: true),
                        CancellationType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CancellationPolicyID);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        CertificateID = c.Int(nullable: false, identity: true),
                        GuiderID = c.String(maxLength: 128),
                        Image = c.String(maxLength: 256),
                        Certificate_Entry = c.DateTime(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CertificateID)
                .ForeignKey("dbo.Guiders", t => t.GuiderID)
                .Index(t => t.GuiderID);
            
            CreateTable(
                "dbo.GuiderLanguageSkills",
                c => new
                    {
                        LanguageID = c.Int(nullable: false),
                        GuiderID = c.String(nullable: false, maxLength: 128),
                        DateOfInsertingLanguageSkill = c.DateTime(nullable: false),
                        IsCertified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.LanguageID, t.GuiderID })
                .ForeignKey("dbo.Guiders", t => t.GuiderID, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageID, cascadeDelete: true)
                .Index(t => t.LanguageID)
                .Index(t => t.GuiderID);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageID = c.Int(nullable: false, identity: true),
                        LanguageName = c.String(maxLength: 256),
                        LanguageShortName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.LanguageID);
            
            CreateTable(
                "dbo.Premiums",
                c => new
                    {
                        PremiumID = c.Int(nullable: false, identity: true),
                        CostOfPackageEuros = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PremiumID);
            
            CreateTable(
                "dbo.UnavailableDates",
                c => new
                    {
                        UnavailableID = c.Int(nullable: false, identity: true),
                        UnavailableFrom = c.DateTime(nullable: false),
                        UnavailableTo = c.DateTime(nullable: false),
                        UnavailableDateEntry = c.DateTime(nullable: false),
                        GuiderID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UnavailableID)
                .ForeignKey("dbo.Guiders", t => t.GuiderID)
                .Index(t => t.GuiderID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.UnavailableDates", "GuiderID", "dbo.Guiders");
            DropForeignKey("dbo.Guiders", "PremiumID", "dbo.Premiums");
            DropForeignKey("dbo.GuiderLanguageSkills", "LanguageID", "dbo.Languages");
            DropForeignKey("dbo.GuiderLanguageSkills", "GuiderID", "dbo.Guiders");
            DropForeignKey("dbo.Conversations", "Guider_GuiderID", "dbo.Guiders");
            DropForeignKey("dbo.Certificates", "GuiderID", "dbo.Guiders");
            DropForeignKey("dbo.Guiders", "CancellationPolicyID", "dbo.CancellationPolicies");
            DropForeignKey("dbo.Guiders", "GuiderID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Conversations", "ReservationID", "dbo.Reservations");
            DropForeignKey("dbo.TravellerToGuiderRates", "TravellerID", "dbo.Travellers");
            DropForeignKey("dbo.TravellerToGuiderRates", "GuiderID", "dbo.Guiders");
            DropForeignKey("dbo.TravellerToGuiderFavourites", "TravellerID", "dbo.Travellers");
            DropForeignKey("dbo.TravellerToGuiderFavourites", "GuiderID", "dbo.Guiders");
            DropForeignKey("dbo.Reservations", "TravellerID", "dbo.Travellers");
            DropForeignKey("dbo.GuiderToTravellerBans", "TravellerID", "dbo.Travellers");
            DropForeignKey("dbo.GuiderToTravellerBans", "GuiderID", "dbo.Guiders");
            DropForeignKey("dbo.Conversations", "Traveller_TravellerID", "dbo.Travellers");
            DropForeignKey("dbo.Travellers", "TravellerID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "GuiderID", "dbo.Guiders");
            DropForeignKey("dbo.Messages", "ConversationID", "dbo.Conversations");
            DropForeignKey("dbo.Messages", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Activities", "GuiderID", "dbo.Guiders");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UnavailableDates", new[] { "GuiderID" });
            DropIndex("dbo.GuiderLanguageSkills", new[] { "GuiderID" });
            DropIndex("dbo.GuiderLanguageSkills", new[] { "LanguageID" });
            DropIndex("dbo.Certificates", new[] { "GuiderID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.TravellerToGuiderRates", new[] { "TravellerID" });
            DropIndex("dbo.TravellerToGuiderRates", new[] { "GuiderID" });
            DropIndex("dbo.TravellerToGuiderFavourites", new[] { "TravellerID" });
            DropIndex("dbo.TravellerToGuiderFavourites", new[] { "GuiderID" });
            DropIndex("dbo.GuiderToTravellerBans", new[] { "TravellerID" });
            DropIndex("dbo.GuiderToTravellerBans", new[] { "GuiderID" });
            DropIndex("dbo.Travellers", new[] { "TravellerID" });
            DropIndex("dbo.Reservations", new[] { "TravellerID" });
            DropIndex("dbo.Reservations", new[] { "GuiderID" });
            DropIndex("dbo.Conversations", new[] { "Guider_GuiderID" });
            DropIndex("dbo.Conversations", new[] { "Traveller_TravellerID" });
            DropIndex("dbo.Conversations", new[] { "ReservationID" });
            DropIndex("dbo.Messages", new[] { "UserID" });
            DropIndex("dbo.Messages", new[] { "ConversationID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Guiders", new[] { "PremiumID" });
            DropIndex("dbo.Guiders", new[] { "CancellationPolicyID" });
            DropIndex("dbo.Guiders", new[] { "GuiderID" });
            DropIndex("dbo.Activities", new[] { "GuiderID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.UnavailableDates");
            DropTable("dbo.Premiums");
            DropTable("dbo.Languages");
            DropTable("dbo.GuiderLanguageSkills");
            DropTable("dbo.Certificates");
            DropTable("dbo.CancellationPolicies");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.TravellerToGuiderRates");
            DropTable("dbo.TravellerToGuiderFavourites");
            DropTable("dbo.GuiderToTravellerBans");
            DropTable("dbo.Travellers");
            DropTable("dbo.Reservations");
            DropTable("dbo.Conversations");
            DropTable("dbo.Messages");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Guiders");
            DropTable("dbo.Activities");
        }
    }
}
