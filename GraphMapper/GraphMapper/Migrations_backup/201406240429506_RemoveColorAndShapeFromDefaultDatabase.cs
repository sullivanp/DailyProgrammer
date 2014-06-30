namespace GraphMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveColorAndShapeFromDefaultDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shapes", "ShortName", c => c.String(nullable: false, maxLength: 32));
            /*
            DropTable("dbo.Shapes");
            DropTable("dbo.Colors");
            DropTable("dbo.ShapePalettes");
            DropTable("dbo.ColorPalettes");
             */
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shapes", "ShortName", c => c.String(maxLength: 32));
        }
    }
}
