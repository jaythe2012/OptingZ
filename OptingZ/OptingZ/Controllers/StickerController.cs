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
    public class StickerController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

        // GET: Sticker
        public ActionResult Index()
        {
            return View(uow.StickerRepository.GetAll());
        }

        // GET: Sticker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StickerMaster stickerMaster = uow.StickerRepository.GetByID(id);
            if (stickerMaster == null)
            {
                return HttpNotFound();
            }
            return View(stickerMaster);
        }

        // GET: Sticker/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sticker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] StickerMaster stickerMaster)
        {
            if (ModelState.IsValid)
            {
                uow.StickerRepository.Add(stickerMaster);
                uow.Save();
                return RedirectToAction("Index");
            }

            return View(stickerMaster);
        }

        // GET: Sticker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StickerMaster stickerMaster = uow.StickerRepository.GetByID(id);
            if (stickerMaster == null)
            {
                return HttpNotFound();
            }
            return View(stickerMaster);
        }

        // POST: Sticker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] StickerMaster stickerMaster)
        {
            if (ModelState.IsValid)
            {
                uow.StickerRepository.Update(stickerMaster);
                uow.Save();
                return RedirectToAction("Index");
            }
            return View(stickerMaster);
        }

        // GET: Sticker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StickerMaster stickerMaster = uow.StickerRepository.GetByID(id);
            if (stickerMaster == null)
            {
                return HttpNotFound();
            }
            return View(stickerMaster);
        }

        // POST: Sticker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StickerMaster stickerMaster = uow.StickerRepository.GetByID(id);
            uow.StickerRepository.Delete(stickerMaster);
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
