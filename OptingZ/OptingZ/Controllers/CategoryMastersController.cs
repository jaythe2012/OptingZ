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
    public class CategoryMastersController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

        // GET: CategoryMasters
        public ActionResult Index()
        {
            return View(uow.CategoryRepository.GetAll());
        }

        // GET: CategoryMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = uow.CategoryRepository.GetByID(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // GET: CategoryMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                uow.CategoryRepository.Add(categoryMaster);
                uow.Save();
                return RedirectToAction("Index");
            }

            return View(categoryMaster);
        }

        // GET: CategoryMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = uow.CategoryRepository.GetByID(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: CategoryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                uow.CategoryRepository.Update(categoryMaster);
                uow.Save();
                return RedirectToAction("Index");
            }
            return View(categoryMaster);
        }

        // GET: CategoryMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = uow.CategoryRepository.GetByID(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: CategoryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryMaster categoryMaster = uow.CategoryRepository.GetByID(id);
            uow.CategoryRepository.Delete(categoryMaster);
            uow.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
