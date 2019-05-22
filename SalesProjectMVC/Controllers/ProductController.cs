﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesProjectMVC.Models;

namespace SalesProjectMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private SaleEntities db = new SaleEntities();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult DeleteProduct(int? id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return new JsonResult { Data = "Deleted", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetProductData()
        {
            var Pdata = db.Products.OrderBy(a => a.Id).ToList();
            return new JsonResult { Data = Pdata, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }


        public JsonResult GetProduct(int? id)
        {
            Product product = db.Products.Find(id);

            return new JsonResult { Data = product, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Product/EditProduct")]
        [HttpPost]
        public JsonResult EditProduct(int id, Product product)
        {

            Product EXproducts = db.Products.Find(id);
            EXproducts.Name = product.Name;
            EXproducts.Price = product.Price;
            //var updatedProduct = UpdateExistingResource(EXproducts, product);
            // db.Entry(product).State = EntityState.Modified;

            //db.Products.
            db.Entry(product);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e) { return new JsonResult { Data = e, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; }


            return new JsonResult { Data = "Updated", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Product/AddProduct")]
        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            db.Products.Add(product);
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