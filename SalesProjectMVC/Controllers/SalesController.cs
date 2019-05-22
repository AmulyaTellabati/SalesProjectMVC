using SalesProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesProjectMVC.Controllers
{
    public class SalesController : Controller
    {
        private SaleEntities db = new SaleEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStoreData()
        {
            var Pdata = db.Sales.OrderBy(a => a.Id).ToList();
            return new JsonResult { Data = Pdata, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult DeleteSales(int? id)
        {
            
            Sale Sale = db.Sales.Find(id);
            db.Sales.Remove(Sale);
            db.SaveChanges();
            return new JsonResult { Data = "Deleted", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetSale(int? id)
        {
            Sale Sale = db.Sales.Find(id);

            return new JsonResult { Data = Sale, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Sales/EditSale")]
        [HttpPost]
        public JsonResult EditStore(int id, Sale Sale)
        {

            Sale EXproducts = db.Sales.Find(id);
           // EXproducts.Name = Sale.Name;
           // EXproducts.Address = Sale.Address;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e) { return new JsonResult { Data = e, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; }


            return new JsonResult { Data = "Updated", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Sales/AddSale")]
        [HttpPost]
        public JsonResult AddSale(Sale Sale)
        {
            db.Sales.Add(Sale);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                return new JsonResult { Data = e, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


            return new JsonResult { Data = "Updated", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}