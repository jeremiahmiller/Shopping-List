using ShoppingList.Models;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

namespace ShoppingList.Data

{
    public class ListInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)

        {
            var ListItems = new List<ShoppingListItem>

            {

                new ShoppingListItem{shoppingItemId = 1, shoppingListId = 1, ListContent = "Eggs", Priority = Priority.Low},
                new ShoppingListItem{shoppingItemId = 2, shoppingListId = 1, ListContent = "bacon", Priority = Priority.High},
                new ShoppingListItem{shoppingItemId = 3, shoppingListId = 1, ListContent = "grits", Priority = Priority.Medium},
                new ShoppingListItem{shoppingItemId = 4, shoppingListId = 1, ListContent = "sausage", Priority = Priority.Low}



            };

            ListItems.ForEach(s => context.ShoppingListItems.Add(s));

            context.SaveChanges();

            var ListsShopping = new List<ListShopping>

            {

                new ListShopping{shoppingListId = 1, ListName = "Grocery", Color = "#FFFFFF"}

            };

            ListsShopping.ForEach(s => context.ShoppingLists.Add(s));

            context.SaveChanges();

        }

    }

}