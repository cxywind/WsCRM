using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WsCRM.Models;
using WsCRM.DAL;

namespace WsCRM.Controllers
{
    public class OrdersController : Controller
    {
        private dbContext db = new dbContext();

        // GET: Orders
        public async Task<JsonResult> Index()
        {
            var _orders =await db.Orders.Include(o => o.Product).Include(o => o.User).ToListAsync();
            var _orderJson = _orders.Select(o => new {o.OrderId, o.Domain, o.Email, o.Phone, o.QQ,o.Total, o.OrderStatus, OrderDate = o.OrderDate.ToString(), o.MarketingWay, o.Product.ProductName, o.Description, });
            return Json(_orderJson, JsonRequestBehavior.AllowGet);
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
