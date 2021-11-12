using Project.Dal;
using Project.Models;
using Project.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminHomePage()
        {
            return View();
        }

        public ActionResult ViewOrders()
        {
            //Open orders db and fill ovm with the orders
            OrderDal oDal = new OrderDal();
            List<Order> obj = oDal.Orders.ToList<Order>();
            OrderViewModel ovm = new OrderViewModel();
            ovm.Orders = obj;
            return View(ovm);
        }

        public ActionResult ViewProducts()
        {
            return View();
        }

        public ActionResult ViewCustomers()
        {
            return View();
        }

        public ActionResult getOrdersByJson()
        {
            //Json- return json with order list 
            OrderDal oDal = new OrderDal();
            List<Order> obj = oDal.Orders.ToList<Order>();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getProductsByJson()
        {
            //Json- return json with products list 
            ProductsDal pDal = new ProductsDal();
            List<Product> objProducts = pDal.Products.ToList<Product>();
            return Json(objProducts, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getCustomersByJson()
        {
            //Json- return json with customers list 
            CustomerDal cDal = new CustomerDal();
            List<Customer> objProducts = cDal.Customers.ToList<Customer>();
            return Json(objProducts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult updateOrder(OrderViewModel o)
        {
            //This function will change "supply" area if the cake have been supported. Will be edit by the Admin.
            OrderDal oDal = new OrderDal();
            List<Order> obj = oDal.Orders.ToList<Order>();
            int check = 0;
            foreach (Order ord in obj) 
            {
                if (ord.oid == o.order.oid)//Check if the order id that the admin entered is the same as the database oder id
                {
                    check = 1;
                    ord.supply = true;//Change the supply value 
                    oDal.SaveChanges();
                    break;
                }
            }

            if(check == 0) //Check will be the flag to be sure which message to show
                Session["Error"] = "This order ID does not exists!";
            else
                Session["Error"] = "This order ID successfuly updated!";

            return RedirectToAction("ViewOrders");
        }

        public ActionResult updateProduct(Product p)
        {
            //Update product into the data base (no need to make more checks cause of data annotation)
            ProductsDal pDal = new ProductsDal();
            List<Product> objProducts = pDal.Products.ToList<Product>();
            p.pid = 1000;
            pDal.Products.Add(p);
            pDal.SaveChanges();
            Session["Error"] = "The product have been added successfuly!";
            return RedirectToAction("ViewProducts");
        }

    }
}