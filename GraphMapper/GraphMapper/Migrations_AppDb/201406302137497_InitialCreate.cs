namespace GraphMapper.Migrations_AppDb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
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
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        DefaultColorPalette_ID = c.Int(),
                        DefaultShapePalette_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ColorPalettes", t => t.DefaultColorPalette_ID)
                .ForeignKey("dbo.ColorPalettes", t => t.DefaultShapePalette_ID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.DefaultColorPalette_ID)
                .Index(t => t.DefaultShapePalette_ID);
            
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
                "dbo.ColorPalettes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 64),
                        Order = c.Int(nullable: false),
                        Rows = c.Int(nullable: false),
                        Columns = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Creator_Id = c.String(maxLength: 128),
                        Owner_Id = c.String(maxLength: 128),
                        GraphMapperUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.GraphMapperUser_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.GraphMapperUser_Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                        Name = c.String(maxLength: 64),
                        Red = c.Int(nullable: false),
                        Green = c.Int(nullable: false),
                        Blue = c.Int(nullable: false),
                        ColorPalette_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ColorPalettes", t => t.ColorPalette_ID)
                .Index(t => t.ColorPalette_ID);
            
            CreateTable(
                "dbo.ShapePalettes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 64),
                        Order = c.Int(nullable: false),
                        Rows = c.Int(nullable: false),
                        Columns = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Creator_Id = c.String(maxLength: 128),
                        Owner_Id = c.String(maxLength: 128),
                        GraphMapperUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Owner_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.GraphMapperUser_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.GraphMapperUser_Id);
            
            CreateTable(
                "dbo.Shapes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ShortName = c.String(nullable: false, maxLength: 64),
                        TypeExtension = c.String(maxLength: 3),
                        FileNameExtensionSeparator = c.String(maxLength: 1),
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                        ShapePalette_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ShapePalettes", t => t.ShapePalette_ID)
                .Index(t => t.ShapePalette_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShapePalettes", "GraphMapperUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shapes", "ShapePalette_ID", "dbo.ShapePalettes");
            DropForeignKey("dbo.ShapePalettes", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShapePalettes", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "DefaultShapePalette_ID", "dbo.ColorPalettes");
            DropForeignKey("dbo.AspNetUsers", "DefaultColorPalette_ID", "dbo.ColorPalettes");
            DropForeignKey("dbo.ColorPalettes", "GraphMapperUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ColorPalettes", "Owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ColorPalettes", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Colors", "ColorPalette_ID", "dbo.ColorPalettes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Shapes", new[] { "ShapePalette_ID" });
            DropIndex("dbo.ShapePalettes", new[] { "GraphMapperUser_Id" });
            DropIndex("dbo.ShapePalettes", new[] { "Owner_Id" });
            DropIndex("dbo.ShapePalettes", new[] { "Creator_Id" });
            DropIndex("dbo.Colors", new[] { "ColorPalette_ID" });
            DropIndex("dbo.ColorPalettes", new[] { "GraphMapperUser_Id" });
            DropIndex("dbo.ColorPalettes", new[] { "Owner_Id" });
            DropIndex("dbo.ColorPalettes", new[] { "Creator_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "DefaultShapePalette_ID" });
            DropIndex("dbo.AspNetUsers", new[] { "DefaultColorPalette_ID" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Shapes");
            DropTable("dbo.ShapePalettes");
            DropTable("dbo.Colors");
            DropTable("dbo.ColorPalettes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
