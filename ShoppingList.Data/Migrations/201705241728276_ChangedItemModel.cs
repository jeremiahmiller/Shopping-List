namespace ShoppingList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Body", c => c.String());
            AddColumn("dbo.ShoppingListItems", "NoteContent", c => c.String());
            DropColumn("dbo.Notes", "Bodu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "Bodu", c => c.String());
            DropColumn("dbo.ShoppingListItems", "NoteContent");
            DropColumn("dbo.Notes", "Body");
        }
    }
}
