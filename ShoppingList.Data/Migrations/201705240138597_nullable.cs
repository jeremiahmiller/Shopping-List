namespace ShoppingList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShoppingListItems", "shoppingListId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShoppingListItems", "shoppingListId", c => c.Int(nullable: false));
        }
    }
}
