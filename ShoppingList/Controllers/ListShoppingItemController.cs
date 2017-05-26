using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingList.Data;
using ShoppingList.Models;
using ShoppingList.Services;
using Microsoft.AspNet.Identity;

namespace ShoppingList.Controllers
{
    public class ListShoppingItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ListService CreateListService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new ListService(userId);
            return service;
        }


        // GET: Test
        public ActionResult Index(string sortOrder, int id)
        {


            var service = CreateListService();
            var model = service.GetShoppingListItems(id);

             


            ViewBag.id = id;
            ViewBag.Url = Request.UrlReferrer;




            ViewBag.PrioitySortParm = String.IsNullOrEmpty(sortOrder) ? "prioity" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            var items = from s in db.ShoppingListItems
                        select s;

            switch (sortOrder)
            {
                case "prioity":
                    items = items.OrderByDescending(s => s.Priority);
                    break;
                case "Name":
                    items = items.OrderBy(s => s.ListContent);
                    break;
                case "name_desc":
                    items = items.OrderByDescending(s => s.ListContent);
                    break;
                default:
                    items = items.OrderBy(s => s.Priority);
                    break;
            }
            return View(items.ToList());
        }

        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItem shoppingListItem = db.ShoppingListItems.Find(id);
            if (shoppingListItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItem);
        }

        // GET: Test/Create
        public ActionResult Create(int id)
        {
            return View();
          

        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShoppingListItem model, int id)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateListService();

            if (service.CreateListItem(model, id))
            {
                //TempData is a dictionary that displays text per user in view then is removed only displaying the 
                //Value of the key
                TempData["SaveResult"] = "Your note was created";
                //TODO WHY COULDN'T YOU DO RETURN View(Index)
                return RedirectToAction("Index", new { id = id });
            }

            //If it fails the ModelState.AddModelError would display that the note was not created in the validation summary
            ModelState.AddModelError("", "Your note could not be create.");
            return View(model);

        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItem shoppingListItem = db.ShoppingListItems.Find(id);
            if (shoppingListItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItem);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "shoppingItemId,shoppingListId,ListContent,Priority,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItem shoppingListItem, int id)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListItem).State = EntityState.Modified;
                
                db.SaveChanges();

                using (var context = new ApplicationDbContext())
                {

                    var query = from b in context.ShoppingListItems
                                where b.shoppingItemId == id
                                select b.shoppingListId;

                    var list = query.ToList();
                    int anotherId = list.ElementAt(0);                    
                    return RedirectToAction("Index", new { id = anotherId });

                }                
                
            }
            return View(shoppingListItem);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListItem shoppingListItem = db.ShoppingListItems.Find(id);
            if (shoppingListItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingListItem);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingListItem shoppingListItem = db.ShoppingListItems.Find(id);
            var items = db.ShoppingListItems.Where(i => i.shoppingItemId == id);

            using (var context = new ApplicationDbContext())
            {

                var query = from b in context.ShoppingListItems
                            where b.shoppingItemId == id
                            select b.shoppingListId;

                var list = query.ToList();
                int anotherId = list.ElementAt(0);

                db.ShoppingListItems.Remove(shoppingListItem);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = anotherId });

            }                      
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
