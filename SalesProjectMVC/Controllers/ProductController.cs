using System;
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
        public JsonResult GetProductData(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var Pdata = db.Products.OrderBy(a => a.Id).ToList();
            
            var paginateddata=Pdata.Skip(((int)id - 1) * 10).Take(10);
            return new JsonResult { Data = paginateddata, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult ProductCount()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var PdtCt = db.Products;
            return new JsonResult { Data = PdtCt.Count(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        public JsonResult GetProduct(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Product product = db.Products.Find(id);

            return new JsonResult { Data = product, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Product/EditProduct")]
        [HttpPost]
        public JsonResult EditProduct(Product product)
        {
            var v = db.Products.Where(a => a.Id == product.Id).FirstOrDefault();
            if (v != null) {
                v.Name = product.Name;
                v.Price = product.Price;
            }
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