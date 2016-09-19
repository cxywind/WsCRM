using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WsCRM.Models;
using WsCRM.DAL;


namespace WsCRM.Controllers
{
    public class ProductsController : Controller
    {
        private dbContext db = new dbContext();

        // GET: Products
        public JsonResult Index()
        {
            return Json(db.Products.Select(a=>new { a.ProductId, a.ProductName, a.Price, a.RenewPrice}).ToList(), JsonRequestBehavior.AllowGet);
        }

        // POST: Products/Create
        [HttpPost]
        public void Create([Bind(Include = "ProductId,ProductName,Price,RenewPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        
        // POST: Products/Edit
        [HttpPost]
        public void Edit([Bind(Include = "ProductId,ProductName,Price,RenewPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
