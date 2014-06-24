namespace GraphMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultShapeSeparatorAndType : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Shapes", "FileNameExtensionSeparator", c => c.String(defaultValue: "."));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Shapes", "FileNameExtensionSeparator", c => c.String(defaultValue: null));
        }
    }
}
