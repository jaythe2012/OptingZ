using OptingZ.DAL;
using OptingZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OptingZ.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork uow = new UnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult SearchResultPartial()
        {
            var Products = uow.ProductRepository.GetAll();
            //var Products = new List<ProductMaster>{
            //            new ProductMaster() { Name = "1", SDescription= "John", Website = "18" } ,
            //            new ProductMaster() { Name = "2", SDescription = "Steve",  Website = "21" },
            //        };

            return PartialView(Products.ToList().Take(5));
            //return PartialView("~/Views/Shared/TestPartial.cshtml", Products.ToList());
        }
    }
}