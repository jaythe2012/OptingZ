﻿using System;
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
    public class UserController : Controller
    {
        //private OptingzDbContext db = new OptingzDbContext();

        private UnitOfWork uow = new UnitOfWork();
        // GET: User
        public ActionResult Index()
        {
            //var userMasters = db.UserMasters.Include(u => u.UserRoleMaster);
            var userMasters = uow.UserRepository.GetAll();
            return View(userMasters.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = uow.UserRepository.GetByID(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            //ViewBag.UserRoleMasterID = new SelectList(db.UserRoleMasters, "ID", "Name");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,Email,Password,UserRoleMasterID")] UserMaster userMaster)
        {
            if (ModelState.IsValid)
            {
                  
                userMaster.UserRoleMasterID = 1;
                uow.UserRepository.Add(userMaster);
                uow.Save();
            }
            
          
            return RedirectToAction("Index");
            //ViewBag.UserRoleMasterID = new SelectList(db.UserRoleMasters, "ID", "Name", userMaster.UserRoleMasterID);
           // return View(userMaster);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //UserMaster userMaster = db.UserMasters.Include(u => u.UserFiles).SingleOrDefault(u => u.ID == id);
            UserMaster userMaster = uow.UserRepository.Get(filter: u =>u.ID == id,
                includeProperties: "UserFiles").SingleOrDefault();
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            //ViewBag.UserRoleMasterID = new SelectList(db.UserRoleMasters, "ID", "Name", userMaster.UserRoleMasterID);
            return View(userMaster);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,Email,Password,UserRoleMasterID")] UserMaster userMaster, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var image = new UserFileMaster
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.ProfilePic,
                        ContentType = upload.ContentType,
                        UserMasterID = userMaster.ID
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        image.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    userMaster.UserFiles = new List<UserFileMaster> { image };
                    uow.UserFileRepository.Add(userMaster.UserFiles.FirstOrDefault());

                }
                userMaster.UserRoleMasterID = 1;
                
                
                uow.UserRepository.Update(userMaster);
                uow.Save();
                
                //db.Entry(userMaster).State = EntityState.Modified;
                ////db.Entry(userMaster.UserFiles).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            //ViewBag.UserRoleMasterID = new SelectList(db.UserRoleMasters, "ID", "Name", userMaster.UserRoleMasterID);
            return View(userMaster);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = uow.UserRepository.GetByID(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMaster userMaster = uow.UserRepository.GetByID(id);
            uow.UserRepository.Delete(userMaster);
            uow.Save();
            //db.UserMasters.Remove(userMaster);
            //db.SaveChanges();
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
