namespace ShoppingList.Data.Migrations
{
    using ShoppingList.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShoppingList.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ShoppingList.Data.ApplicationDbContext";
        }

        protected override void Seed(ShoppingList.Data.ApplicationDbContext context)
        {
            context.ShoppingLists.AddOrUpdate(x => x.shoppingListId,
                new ListShopping() { shoppingListId = 1, ListName = "Grocery", Color = "#FFFFFF" });

            context.ShoppingListItems.AddOrUpdate(x => x.shoppingItemId,
                new ShoppingListItem { shoppingItemId = 1, shoppingListId = 1, ListContent = "Eggs", Priority = Priority.Low },
                new ShoppingListItem { shoppingItemId = 2, shoppingListId = 1, ListContent = "bacon", Priority = Priority.High },
                new ShoppingListItem { shoppingItemId = 3, shoppingListId = 1, ListContent = "grits", Priority = Priority.Medium },
                new ShoppingListItem { shoppingItemId = 4, shoppingListId = 1, ListContent = "sausage", Priority = Priority.Low });
        }
    }
}
