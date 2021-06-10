using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using itemLendsSystemV01.Models;

namespace itemLendsSystemV01.Controllers
{
    public class LendListController : Controller
    {
        private db_itemLendSystemEntities3 db = new db_itemLendSystemEntities3();

        // GET: LendList
        public ActionResult Index()
        {
            return View(db.t_lend_items.ToList());
        }

        // GET: LendList/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_lend_items t_lend_items = db.t_lend_items.Find(id);
            if (t_lend_items == null)
            {
                return HttpNotFound();
            }
            return View(t_lend_items);
        }

        // GET: LendList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LendList/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,BorowerName,CheckoutDate,ReturnDateExpected,ReturnDateActual")] t_lend_items t_lend_items)
        {
            if (ModelState.IsValid)
            {
                db.t_lend_items.Add(t_lend_items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_lend_items);
        }

        // GET: LendList/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_lend_items t_lend_items = db.t_lend_items.Find(id);
            if (t_lend_items == null)
            {
                return HttpNotFound();
            }
            return View(t_lend_items);
        }

        // POST: LendList/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,BorowerName,CheckoutDate,ReturnDateExpected,ReturnDateActual")] t_lend_items t_lend_items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_lend_items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_lend_items);
        }

        // GET: LendList/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_lend_items t_lend_items = db.t_lend_items.Find(id);
            if (t_lend_items == null)
            {
                return HttpNotFound();
            }
            return View(t_lend_items);
        }

        // POST: LendList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            t_lend_items t_lend_items = db.t_lend_items.Find(id);
            db.t_lend_items.Remove(t_lend_items);
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
