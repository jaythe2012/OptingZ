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
    public class ProductsController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();

        // GET: Products
        public ActionResult Index()
        {
            IEnumerable<ProductMaster> Products = uow.ProductRepository.GetAll();
            return View(Products);
        }

        [HttpGet]
        //Get : Products/Alternative
        public ActionResult Alternative(string pName)
        {

            IEnumerable<ProductMaster> SelectedProduct = uow.ProductRepository.Get(
                filter: d => d.Name == pName,
                includeProperties: "ProductCategorises"
               );


            ProductMaster prod = uow.ProductRepository.Get(
                filter: d => d.Name == pName,
                includeProperties: "ProductCategorises"
               ).First();
            //IEnumerable<ProductMaster> AlternativeProducts -uow.ProductRepository.Get(
            //    filter: f => f.
            //    );

            IEnumerable<ProductCategoryMaster> pcm = prod.ProductCategorises;
            IEnumerable<ProductMaster> Products = uow.ProductRepository.GetAll();

            return View(Products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster Product = uow.ProductRepository.GetByID(id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,SDescription,IsMultipleCategory,Website")] ProductMaster Product)
        {
            if (ModelState.IsValid)
            {
                uow.ProductRepository.Add(Product);
                uow.Save();
                return RedirectToAction("Index");
            }
            return View(Product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster Product = uow.ProductRepository.GetByID(id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SDescription,IsMultipleCategory,Website")] ProductMaster Product)
        {
            if (ModelState.IsValid)
            {
                uow.ProductRepository.Update(Product);
                uow.Save();
                return RedirectToAction("Index");
            }
            return View(Product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster Product = uow.ProductRepository.GetByID(id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            return View(Product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductMaster Product = uow.ProductRepository.GetByID(id);
            uow.ProductRepository.Delete(Product);
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
