namespace CarDealership.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyTypes",
                c => new
                    {
                        BodyTypeId = c.Int(nullable: false, identity: true),
                        BodyTypeName = c.String(),
                    })
                .PrimaryKey(t => t.BodyTypeId);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Interiors",
                c => new
                    {
                        InteriorId = c.Int(nullable: false, identity: true),
                        InteriorName = c.String(),
                    })
                .PrimaryKey(t => t.InteriorId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Int(),
                        Email = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.Int(),
                        PurchasePrice = c.Decimal(precision: 18, scale: 2),
                        PurchaseType = c.String(),
                    })
                .PrimaryKey(t => t.SaleId);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        StatisticId = c.Int(nullable: false, identity: true),
                        SalesPerson = c.String(),
                        TotalSales = c.Decimal(precision: 18, scale: 2),
                        VehiclesSold = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatisticId);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        TransmissionId = c.Int(nullable: false, identity: true),
                        TransmissionName = c.String(),
                    })
                .PrimaryKey(t => t.TransmissionId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.Makes",
                c => new
                    {
                        MakeId = c.Int(nullable: false, identity: true),
                        MakeName = c.String(),
                    })
                .PrimaryKey(t => t.MakeId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        Make_MakeId = c.Int(),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Makes", t => t.Make_MakeId)
                .Index(t => t.Make_MakeId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(),
                        Image = c.String(),
                        IsNew = c.Boolean(nullable: false),
                        BodyStyle = c.String(),
                        Trans = c.String(),
                        Color = c.String(),
                        Interior = c.String(),
                        Mileage = c.Int(),
                        VinNumber = c.String(),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        InStock = c.Boolean(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Models", "Make_MakeId", "dbo.Makes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Models", new[] { "Make_MakeId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Models");
            DropTable("dbo.Makes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Statistics");
            DropTable("dbo.Specials");
            DropTable("dbo.Sales");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Interiors");
            DropTable("dbo.Contacts");
            DropTable("dbo.Colors");
            DropTable("dbo.BodyTypes");
        }
    }
}
