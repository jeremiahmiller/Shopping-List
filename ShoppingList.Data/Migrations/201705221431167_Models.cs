namespace ShoppingList.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notes", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.ShoppingListItems", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.ListShoppings", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ListShoppings", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.ShoppingListItems", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Notes", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
