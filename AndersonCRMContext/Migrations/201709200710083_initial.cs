namespace AndersonCRMContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PeripheralHistory", "PeripheralHistoryColor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PeripheralHistory", "PeripheralHistoryColor", c => c.String(maxLength: 6));
        }
    }
}
