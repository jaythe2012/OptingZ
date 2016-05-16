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
            ViewBag.pName = Request.Form["pName"];
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

        
        public JsonResult AutoCompleteProduct(string term)
        {
            //var result = (from r in db.Customers
            //              where r.Country.ToLower().Contains(term.ToLower())
            //              select new { r.Country }).Distinct();
            var result = uow.ProductRepository.GetNames(term).Select(p => new { label = p.Name, id = p.ID, value = p.IsMultipleCategory });
          //  var test = Json(result, JsonRequestBehavior.AllowGet);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}