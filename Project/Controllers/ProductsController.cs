using Project.Dal;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult getProductsByJson()
        {//Json function - returns the products by json
            Thread.Sleep(3000);
            ProductsDal pDal = new ProductsDal();
            List<Product> objProducts = pDal.Products.ToList<Product>();
            return Json(objProducts, JsonRequestBehavior.AllowGet);
        }
    }
}