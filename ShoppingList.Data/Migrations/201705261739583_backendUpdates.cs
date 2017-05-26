namespace ShoppingList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backendUpdates : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notes", "Bodu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Bodu", c => c.String());
        }
    }
}
