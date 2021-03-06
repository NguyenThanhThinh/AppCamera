namespace AppCamera.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cameras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.Int(nullable: false),
                        Model = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 16, scale: 2),
                        Quantity = c.Int(nullable: false),
                        MinShutterSpeed = c.Int(nullable: false),
                        MaxShutterSpeed = c.Int(nullable: false),
                        MinIso = c.Int(nullable: false),
                        MaxIso = c.Int(nullable: false),
                        IsFullFrame = c.Boolean(nullable: false),
                        VideoResolution = c.String(nullable: false, maxLength: 15),
                        LightMetering = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                        LoginStamp = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        LastLoginTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Cameras", "User_Id", "dbo.Users");
            DropIndex("dbo.Logins", new[] { "User_Id" });
            DropIndex("dbo.Cameras", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Logins");
            DropTable("dbo.Cameras");
        }
    }
}
