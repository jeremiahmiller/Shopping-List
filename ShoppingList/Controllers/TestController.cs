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

namespace ShoppingList.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Test
        public ActionResult Index()
        {
            return View(db.ShoppingListItems.ToList());
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "shoppingItemId,shoppingListId,ListContent,Priority,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItem shoppingListItem)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingListItems.Add(shoppingListItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingListItem);
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
        public ActionResult Edit([Bind(Include = "shoppingItemId,shoppingListId,ListContent,Priority,IsChecked,CreatedUtc,ModifiedUtc")] ShoppingListItem shoppingListItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingListItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
            db.ShoppingListItems.Remove(shoppingListItem);
            db.SaveChanges();
            return RedirectToAction("Index");
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
