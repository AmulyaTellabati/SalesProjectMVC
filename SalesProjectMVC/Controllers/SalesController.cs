using SalesProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Newtonsoft.Json;

namespace SalesProjectMVC.Controllers
{
    public class SalesController : Controller
    {
        private SaleEntities db = new SaleEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSaleData()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var storedata = db.Sales.Include(r => r.Store).Include(r => r.Customer).Include(r => r.Product).AsEnumerable().Select(r => SaleResult(r));
            var Pdata = storedata.ToList();
            return new JsonResult { Data = Pdata, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        private Object SaleResult(Sale sale)
        {
            return new
            {
                sale.Id,
                Store = new { sale.Store.Id, sale.Store.Name },
                Customer = new { sale.Customer.Id, sale.Customer.Name },
                Product = new { sale.Product.Id, sale.Product.Name },
                sale.DateSold
            };
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
        public JsonResult EditSale(int id, Sale Sale)
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
                db.Entry(Sale).Reference(r => r.Store).Load();
                db.Entry(Sale).Reference(r => r.Customer).Load();
                db.Entry(Sale).Reference(r => r.Product).Load();
               
            }
            

            catch (Exception e)
            {
                return new JsonResult { Data = e, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }


            return new JsonResult { Data = SaleResult(Sale), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}