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
    public class SubCategoryController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

        // GET: SubCategory
        public ActionResult Index()
        {
            return View(uow.SubCategoryRepository.GetAll());
        }

        // GET: SubCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = uow.SubCategoryRepository.GetByID(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // GET: SubCategory/Create
        public ActionResult Create()
        {
            ViewBag.CategoryMasterID = new SelectList(uow.CategoryRepository.GetAll(), "ID", "Name");
            return View();
        }

        // POST: SubCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,CategoryMasterID")] SubCategoryMaster subCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                uow.SubCategoryRepository.Add(subCategoryMaster);
                uow.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryMasterID = new SelectList(uow.CategoryRepository.GetAll(), "ID", "Name", subCategoryMaster.CategoryMasterID);
            return View(subCategoryMaster);
        }

        // GET: SubCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = uow.SubCategoryRepository.GetByID(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryMasterID = new SelectList(uow.CategoryRepository.GetAll(), "ID", "Name", subCategoryMaster.CategoryMasterID);
            return View(subCategoryMaster);
        }

        // POST: SubCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,CategoryMasterID")] SubCategoryMaster subCategoryMaster)
        {
            if (ModelState.IsValid)
            {
                uow.SubCategoryRepository.Update(subCategoryMaster);
                uow.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryMasterID = new SelectList(uow.CategoryRepository.GetAll(), "ID", "Name", subCategoryMaster.CategoryMasterID);
            return View(subCategoryMaster);
        }

        // GET: SubCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategoryMaster subCategoryMaster = uow.SubCategoryRepository.GetByID(id);
            if (subCategoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(subCategoryMaster);
        }

        // POST: SubCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubCategoryMaster subCategoryMaster = uow.SubCategoryRepository.GetByID(id);
            uow.SubCategoryRepository.Delete(subCategoryMaster);
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
