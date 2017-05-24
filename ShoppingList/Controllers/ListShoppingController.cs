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
    public class ListShoppingController : Controller
    {
        

        private ListService CreateListService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            
            var service = new ListService(userId);
            return service;
        }

        private ListService CreateListItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new ListService(userId);
            return service;
        }

        // GET: ListShopping
        [Authorize]
        public ActionResult Index()
        {

            var service = CreateListService();
            var model = service.GetShoppingList();            


            return View(model);
        }

        // GET: ListShopping/Create

        public ActionResult Create()
        {
            return View();
        }


        // GET: ListShopping/Details/5
        //[ValidateAntiForgeryToken]
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ListShopping listShopping = db.ShoppingLists.Find(id);
        //    if (listShopping == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(listShopping);
        //}

  

        // POST: ListShopping/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListShopping model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateListService();

            if (service.CreateList(model))
            {               
                return RedirectToAction("Index");
            }

            //If it fails the ModelState.AddModelError would display that the note was not created in the validation summary
            ModelState.AddModelError("", "Your note could not be create.");



            return View(model);

        }



        // GET: ListShopping/Edit/5
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ListShopping listShopping = db.ShoppingLists.Find(id);
        //    if (listShopping == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(listShopping);
        //}

        // POST: ListShopping/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "shoppingListId,UserId,ListName,Color,CreatedUtc,ModifiedUtc")] ListShopping listShopping)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(listShopping).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(listShopping);
        //}

        // GET: ListShopping/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ListShopping listShopping = db.ShoppingLists.Find(id);
        //    if (listShopping == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(listShopping);
        //}

        // POST: ListShopping/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ListShopping listShopping = db.ShoppingLists.Find(id);
        //    db.ShoppingLists.Remove(listShopping);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


    }
}
