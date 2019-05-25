﻿using SalesProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
        public JsonResult SaleCount()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var SaleCt = db.Sales;
            return new JsonResult { Data = SaleCt.Count(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult GetSale(int? id)
        {
            Sale Sale = db.Sales.Include(x => x.Store).Include(x => x.Customer).Include(x => x.Product).AsEnumerable().Single(x => x.Id == id);

            return new JsonResult { Data = SaleResult(Sale), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Sales/EditSale")]
        [HttpPost]
        public JsonResult EditSale(Sale Sale)
        {
            Sale Xsale = db.Sales.Single(r => r.Id == Sale.Id);
            if (Xsale != null)
            {
                Xsale.ProductId = Sale.ProductId;
                Xsale.StoreId = Sale.StoreId;
                Xsale.CustomerId = Sale.CustomerId;
                Xsale.DateSold = Sale.DateSold;
            }
            try
            {
                db.SaveChanges();
                db.Entry(Xsale).Reference(x => x.Store).Load();
                db.Entry(Xsale).Reference(x => x.Customer).Load();
                db.Entry(Xsale).Reference(x => x.Product).Load();
            }
            catch (Exception e) { return new JsonResult { Data = e, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; }
            return new JsonResult { Data = SaleResult(Xsale), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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