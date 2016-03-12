using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OptingZ.DAL;
using OptingZ.Models;

namespace OptingZ.Controllers
{
    public class UserFileMasterController : Controller
    {
        private OptingzDbContext db = new OptingzDbContext();

        // GET: UserFileMaster
        public ActionResult Index(int id)
        {
            var userFileMasters = db.UserFileMasters.Find(id);
            return File(userFileMasters.Content, userFileMasters.ContentType);
        }

        // GET: UserFileMaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFileMaster userFileMaster = db.UserFileMasters.Find(id);
            if (userFileMaster == null)
            {
                return HttpNotFound();
            }
            return View(userFileMaster);
        }

        // GET: UserFileMaster/Create
        public ActionResult Create()
        {
            ViewBag.UserMasterID = new SelectList(db.UserMasters, "ID", "LastName");
            return View();
        }

        // POST: UserFileMaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FileName,ContentType,Content,FileType,UserMasterID")] UserFileMaster userFileMaster)
        {
            if (ModelState.IsValid)
            {
                db.UserFileMasters.Add(userFileMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserMasterID = new SelectList(db.UserMasters, "ID", "LastName", userFileMaster.UserMasterID);
            return View(userFileMaster);
        }

        // GET: UserFileMaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFileMaster userFileMaster = db.UserFileMasters.Find(id);
            if (userFileMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserMasterID = new SelectList(db.UserMasters, "ID", "LastName", userFileMaster.UserMasterID);
            return View(userFileMaster);
        }

        // POST: UserFileMaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FileName,ContentType,Content,FileType,UserMasterID")] UserFileMaster userFileMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userFileMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserMasterID = new SelectList(db.UserMasters, "ID", "LastName", userFileMaster.UserMasterID);
            return View(userFileMaster);
        }

        // GET: UserFileMaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFileMaster userFileMaster = db.UserFileMasters.Find(id);
            if (userFileMaster == null)
            {
                return HttpNotFound();
            }
            return View(userFileMaster);
        }

        // POST: UserFileMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserFileMaster userFileMaster = db.UserFileMasters.Find(id);
            db.UserFileMasters.Remove(userFileMaster);
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
