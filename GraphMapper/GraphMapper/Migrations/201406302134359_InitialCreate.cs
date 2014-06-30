namespace GraphMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                        GraphMapperUser_Id = c.String(maxLength: 128),
                        Creator_Id = c.String(maxLength: 128),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GraphMapperUsers", t => t.GraphMapperUser_Id)
                .ForeignKey("dbo.GraphMapperUsers", t => t.Creator_Id)
                .ForeignKey("dbo.GraphMapperUsers", t => t.Owner_Id)
                .Index(t => t.GraphMapperUser_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.Owner_Id);
            
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
                "dbo.GraphMapperUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        DefaultColorPalette_ID = c.Int(),
                        DefaultShapePalette_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ColorPalettes", t => t.DefaultColorPalette_ID)
                .ForeignKey("dbo.ColorPalettes", t => t.DefaultShapePalette_ID)
                .Index(t => t.DefaultColorPalette_ID)
                .Index(t => t.DefaultShapePalette_ID);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        GraphMapperUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GraphMapperUsers", t => t.GraphMapperUser_Id)
                .Index(t => t.GraphMapperUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        GraphMapperUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.GraphMapperUsers", t => t.GraphMapperUser_Id)
                .Index(t => t.GraphMapperUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        GraphMapperUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.GraphMapperUsers", t => t.GraphMapperUser_Id)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.GraphMapperUser_Id)
                .Index(t => t.IdentityRole_Id);
            
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
                .ForeignKey("dbo.GraphMapperUsers", t => t.Creator_Id)
                .ForeignKey("dbo.GraphMapperUsers", t => t.Owner_Id)
                .ForeignKey("dbo.GraphMapperUsers", t => t.GraphMapperUser_Id)
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
            
            CreateTable(
                "dbo.GraphMaps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Order = c.Int(nullable: false),
                        Rows = c.Int(nullable: false),
                        Columns = c.Int(nullable: false),
                        Name = c.String(maxLength: 64),
                        Updated = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Creator_Id = c.String(maxLength: 128),
                        DefaultColorPalette_ID = c.Int(),
                        DefaultShapePalette_ID = c.Int(),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GraphMapperUsers", t => t.Creator_Id)
                .ForeignKey("dbo.ColorPalettes", t => t.DefaultColorPalette_ID)
                .ForeignKey("dbo.ShapePalettes", t => t.DefaultShapePalette_ID)
                .ForeignKey("dbo.GraphMapperUsers", t => t.Owner_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.DefaultColorPalette_ID)
                .Index(t => t.DefaultShapePalette_ID)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.MapElements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GraphMapID = c.Int(),
                        Row = c.Int(nullable: false),
                        Column = c.Int(nullable: false),
                        BackgroundColor_ID = c.Int(),
                        ForegroundColor_ID = c.Int(),
                        Shape_ID = c.Int(),
                        MapElementPalette_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Colors", t => t.BackgroundColor_ID)
                .ForeignKey("dbo.Colors", t => t.ForegroundColor_ID)
                .ForeignKey("dbo.GraphMaps", t => t.GraphMapID, cascadeDelete: true)
                .ForeignKey("dbo.Shapes", t => t.Shape_ID)
                .ForeignKey("dbo.MapElementPalettes", t => t.MapElementPalette_ID)
                .Index(t => t.GraphMapID)
                .Index(t => t.BackgroundColor_ID)
                .Index(t => t.ForegroundColor_ID)
                .Index(t => t.Shape_ID)
                .Index(t => t.MapElementPalette_ID);
            
            CreateTable(
                "dbo.MapElementPalettes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 64),
                        Order = c.Int(nullable: false),
                        Rows = c.Int(nullable: false),
                        Columns = c.Int(nullable: false),
                        Creator_Id = c.String(maxLength: 128),
                        Owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GraphMapperUsers", t => t.Creator_Id)
                .ForeignKey("dbo.GraphMapperUsers", t => t.Owner_Id)
                .Index(t => t.Creator_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.MapElementPalettes", "Owner_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.MapElements", "MapElementPalette_ID", "dbo.MapElementPalettes");
            DropForeignKey("dbo.MapElementPalettes", "Creator_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.GraphMaps", "Owner_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.MapElements", "Shape_ID", "dbo.Shapes");
            DropForeignKey("dbo.MapElements", "GraphMapID", "dbo.GraphMaps");
            DropForeignKey("dbo.MapElements", "ForegroundColor_ID", "dbo.Colors");
            DropForeignKey("dbo.MapElements", "BackgroundColor_ID", "dbo.Colors");
            DropForeignKey("dbo.GraphMaps", "DefaultShapePalette_ID", "dbo.ShapePalettes");
            DropForeignKey("dbo.GraphMaps", "DefaultColorPalette_ID", "dbo.ColorPalettes");
            DropForeignKey("dbo.GraphMaps", "Creator_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.ColorPalettes", "Owner_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.ColorPalettes", "Creator_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.ShapePalettes", "GraphMapperUser_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.Shapes", "ShapePalette_ID", "dbo.ShapePalettes");
            DropForeignKey("dbo.ShapePalettes", "Owner_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.ShapePalettes", "Creator_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.IdentityUserRoles", "GraphMapperUser_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.IdentityUserLogins", "GraphMapperUser_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.GraphMapperUsers", "DefaultShapePalette_ID", "dbo.ColorPalettes");
            DropForeignKey("dbo.GraphMapperUsers", "DefaultColorPalette_ID", "dbo.ColorPalettes");
            DropForeignKey("dbo.ColorPalettes", "GraphMapperUser_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.IdentityUserClaims", "GraphMapperUser_Id", "dbo.GraphMapperUsers");
            DropForeignKey("dbo.Colors", "ColorPalette_ID", "dbo.ColorPalettes");
            DropIndex("dbo.MapElementPalettes", new[] { "Owner_Id" });
            DropIndex("dbo.MapElementPalettes", new[] { "Creator_Id" });
            DropIndex("dbo.MapElements", new[] { "MapElementPalette_ID" });
            DropIndex("dbo.MapElements", new[] { "Shape_ID" });
            DropIndex("dbo.MapElements", new[] { "ForegroundColor_ID" });
            DropIndex("dbo.MapElements", new[] { "BackgroundColor_ID" });
            DropIndex("dbo.MapElements", new[] { "GraphMapID" });
            DropIndex("dbo.GraphMaps", new[] { "Owner_Id" });
            DropIndex("dbo.GraphMaps", new[] { "DefaultShapePalette_ID" });
            DropIndex("dbo.GraphMaps", new[] { "DefaultColorPalette_ID" });
            DropIndex("dbo.GraphMaps", new[] { "Creator_Id" });
            DropIndex("dbo.Shapes", new[] { "ShapePalette_ID" });
            DropIndex("dbo.ShapePalettes", new[] { "GraphMapperUser_Id" });
            DropIndex("dbo.ShapePalettes", new[] { "Owner_Id" });
            DropIndex("dbo.ShapePalettes", new[] { "Creator_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "GraphMapperUser_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "GraphMapperUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "GraphMapperUser_Id" });
            DropIndex("dbo.GraphMapperUsers", new[] { "DefaultShapePalette_ID" });
            DropIndex("dbo.GraphMapperUsers", new[] { "DefaultColorPalette_ID" });
            DropIndex("dbo.Colors", new[] { "ColorPalette_ID" });
            DropIndex("dbo.ColorPalettes", new[] { "Owner_Id" });
            DropIndex("dbo.ColorPalettes", new[] { "Creator_Id" });
            DropIndex("dbo.ColorPalettes", new[] { "GraphMapperUser_Id" });
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.MapElementPalettes");
            DropTable("dbo.MapElements");
            DropTable("dbo.GraphMaps");
            DropTable("dbo.Shapes");
            DropTable("dbo.ShapePalettes");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.GraphMapperUsers");
            DropTable("dbo.Colors");
            DropTable("dbo.ColorPalettes");
        }
    }
}
