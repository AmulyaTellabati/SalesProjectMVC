using SalesProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesProjectMVC.Controllers
{
    public class CustomerController : Controller
    {
        private SaleEntities db = new SaleEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCustomerData()
        {
            var Pdata = db.Customers.OrderBy(a => a.Id).ToList();
            return new JsonResult { Data = Pdata, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult DeleteCustomer(int? id)
        {
            Customer Customer = db.Customers.Find(id);
            db.Customers.Remove(Customer);
            db.SaveChanges();
            return new JsonResult { Data = "Deleted", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetCustomer(int? id)
        {
            Customer Customer = db.Customers.Find(id);

            return new JsonResult { Data = Customer, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Customer/EditCustomer")]
        [HttpPost]
        public JsonResult EditCustomer(int id, Customer Customer)
        {

            Customer EXproducts = db.Customers.Find(id);
            EXproducts.Name = Customer.Name;
            EXproducts.Address = Customer.Address;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e) { return new JsonResult { Data = e, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; }


            return new JsonResult { Data = "Updated", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Customer/AddCustomer")]
        [HttpPost]
        public JsonResult AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
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
