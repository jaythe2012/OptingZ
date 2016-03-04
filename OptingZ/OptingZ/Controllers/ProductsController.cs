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
    public class ProductsController : Controller
    {
        private OptingzDbContext db = new OptingzDbContext();

        // GET: Products
        public ActionResult Index()
        {

            List<ProductMaster> Products = db.ProductMasters.ToList();
            return View(db.ProductMasters.ToList());
        }

        [HttpGet]
        //Get : Products/Alternative
        public ActionResult Alternative(string pName)
        {
            //var product = db.ProductMasters.Where(p => p.Name == pName);

            //ProductMaster pr = db.ProductMasters.Find(pName);

            
            //ProductMaster products = (ProductMaster)db.ProductMasters.Where(p => p.Name == product);

            List<ProductMaster> Products = db.ProductMasters.ToList();
            return View(db.ProductMasters.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster Product = db.ProductMasters.Find(id);
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
                db.ProductMasters.Add(Product);
                db.SaveChanges();
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
            ProductMaster Product = db.ProductMasters.Find(id);
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
                db.Entry(Product).State = EntityState.Modified;
                db.SaveChanges();
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
            ProductMaster Product = db.ProductMasters.Find(id);
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
            ProductMaster Product = db.ProductMasters.Find(id);
            db.ProductMasters.Remove(Product);
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
