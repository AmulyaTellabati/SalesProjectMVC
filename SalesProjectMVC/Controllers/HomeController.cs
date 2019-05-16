using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesProjectMVC.Models;

namespace SalesProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        private SaleEntities db = new SaleEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sales()
        {
            return View();
        }
        public JsonResult GetProductData()
        {
            var Pdata = db.Products.OrderBy(a => a.Id).ToList();
            return new JsonResult { Data=Pdata, JsonRequestBehavior=JsonRequestBehavior.AllowGet};
        }
        public JsonResult GetSalesData()
        {
            var Sdata = db.Sales.OrderBy(a => a.Id).ToList();
            return new JsonResult { Data = Sdata, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}