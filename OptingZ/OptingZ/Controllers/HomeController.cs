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
        public ActionResult SearchResultPartial(int? value)
        {
            var Products = uow.ProductRepository.GetAll();

            if (value == null)
                return PartialView(Products.ToList().Take(1));
            else
            {
                return PartialView(Products.ToList().Take(value.Value));
                //return PartialView("~/Views/Shared/TestPartial.cshtml", Products.ToList());
            }
        }
    }
}