﻿using SalesProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesProjectMVC.Controllers
{
    public class StoresController : Controller
    {
        private SaleEntities db = new SaleEntities();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStoreData()
        {
            var Pdata = db.Stores.OrderBy(a => a.Id).ToList();
            return new JsonResult { Data = Pdata, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult DeleteStores(int? id)
        {
            Store Store = db.Stores.Find(id);
            db.Stores.Remove(Store);
            db.SaveChanges();
            return new JsonResult { Data = "Deleted", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetStores(int? id)
        {
            Store Store = db.Stores.Find(id);

            return new JsonResult { Data = Store, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Stores/EditStores")]
        [HttpPost]
        public JsonResult EditStores(int id, Store Store)
        {

            Store EXproducts = db.Stores.Find(id);
            EXproducts.Name = Store.Name;
            EXproducts.Address = Store.Address;
            try
            {
                db.SaveChanges();
            }
            catch (Exception e) { return new JsonResult { Data = e, JsonRequestBehavior = JsonRequestBehavior.AllowGet }; }


            return new JsonResult { Data = "Updated", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [Route("Stores/AddStores")]
        [HttpPost]
        public JsonResult AddStores(Store Store)
        {
            db.Stores.Add(Store);
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