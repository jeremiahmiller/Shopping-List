using ShoppingList.Data;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingList.Services
{
    public class ListService
    {
        ApplicationDbContext db = new ApplicationDbContext();

        private readonly Guid _userId;
        //private readonly int _shoppinglistId;

        //Since making this constructor now you HAVE to get it a user ID
        public ListService(Guid userId)
        {
            _userId = userId;
        }

        //public ListService(int shoppinglistId)
        //{
            
        //    _shoppinglistId = shoppinglistId;
        //}



        public bool CreateList(ListShopping model)
        {
            var entity = new ListShopping
            {
                UserId = _userId,
                ListName = model.ListName,
                Color = model.Color,
                CreatedUtc = DateTimeOffset.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingLists.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool CreateListItem(ShoppingListItem model, int id)
        {
            var entity = new ShoppingListItem
            {                
                shoppingListId = id,
                ListContent = model.ListContent,
                Priority = model.Priority,
                NoteContent = model.NoteContent,
                CreatedUtc = DateTimeOffset.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ShoppingListItems.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }
       
        public IEnumerable<ListShopping> GetShoppingList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.ShoppingLists.Where(e => e.UserId == _userId);
                    
                return query.ToArray();
            }
        }

        public IEnumerable<ShoppingListItem> GetShoppingListItems(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.ShoppingListItems.Where(e => e.shoppingListId == id);

                return query.ToArray();
            }
        }

    }
}