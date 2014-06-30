namespace GraphMapper.ApplicationDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Latest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ColorPalettes", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ColorPalettes", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Colors", "Row", c => c.Int(nullable: false));
            AddColumn("dbo.Colors", "Column", c => c.Int(nullable: false));
            AddColumn("dbo.ShapePalettes", "Updated", c => c.DateTime(nullable: false));
            AddColumn("dbo.ShapePalettes", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ColorPalettes", "Name", c => c.String(maxLength: 64));
            AlterColumn("dbo.Colors", "Name", c => c.String(maxLength: 64));
            AlterColumn("dbo.ShapePalettes", "Name", c => c.String(maxLength: 64));
            AlterColumn("dbo.Shapes", "ShortName", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shapes", "ShortName", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.ShapePalettes", "Name", c => c.String(maxLength: 32));
            AlterColumn("dbo.Colors", "Name", c => c.String(maxLength: 32));
            AlterColumn("dbo.ColorPalettes", "Name", c => c.String(maxLength: 32));
            DropColumn("dbo.ShapePalettes", "Created");
            DropColumn("dbo.ShapePalettes", "Updated");
            DropColumn("dbo.Colors", "Column");
            DropColumn("dbo.Colors", "Row");
            DropColumn("dbo.ColorPalettes", "Created");
            DropColumn("dbo.ColorPalettes", "Updated");
        }
    }
}
