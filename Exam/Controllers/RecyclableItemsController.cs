﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecyclingApp.Models;

namespace Exam.Controllers
{
    public class RecyclableItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecyclableItems
        public ActionResult Index()
        {
            var recyclableItems = db.RecyclableItems.Include(r => r.RecyclableType);
            return View(recyclableItems.ToList());
        }

        // GET: RecyclableItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecyclableItem recyclableItem = db.RecyclableItems.Find(id);
            if (recyclableItem == null)
            {
                return HttpNotFound();
            }
            return View(recyclableItem);
        }

        // GET: RecyclableItems/Create
        public ActionResult Create()
        {
            ViewBag.RecyclableTypeId = new SelectList(db.RecyclableTypes, "Id", "Type");
            return View();
        }

        // POST: RecyclableItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RecyclableTypeId,Weight,ComputedRate,ItemDescription")] RecyclableItem recyclableItem)
        {
            if (ModelState.IsValid)
            {
                db.RecyclableItems.Add(recyclableItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecyclableTypeId = new SelectList(db.RecyclableTypes, "Id", "Type", recyclableItem.RecyclableTypeId);
            return View(recyclableItem);
        }

        // GET: RecyclableItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecyclableItem recyclableItem = db.RecyclableItems.Find(id);
            if (recyclableItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecyclableTypeId = new SelectList(db.RecyclableTypes, "Id", "Type", recyclableItem.RecyclableTypeId);
            return View(recyclableItem);
        }

        // POST: RecyclableItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RecyclableTypeId,Weight,ComputedRate,ItemDescription")] RecyclableItem recyclableItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recyclableItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecyclableTypeId = new SelectList(db.RecyclableTypes, "Id", "Type", recyclableItem.RecyclableTypeId);
            return View(recyclableItem);
        }

        // GET: RecyclableItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecyclableItem recyclableItem = db.RecyclableItems.Find(id);
            if (recyclableItem == null)
            {
                return HttpNotFound();
            }
            return View(recyclableItem);
        }

        // POST: RecyclableItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecyclableItem recyclableItem = db.RecyclableItems.Find(id);
            db.RecyclableItems.Remove(recyclableItem);
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
