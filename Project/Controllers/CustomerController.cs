using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Dal;
using System.Threading;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer


        public ActionResult Submit(Customer_User cu)//Sign up
        {//Submit function will register new account into the database (thats why we need customer+user)
            try
            {//Possible get exception.
                //Open both customer and users to edit add the attributes into them both.
                cu.user.email = cu.cust.email;
                CustomerDal cDal = new Dal.CustomerDal();
                UserDal uDal = new Dal.UserDal();
                cDal.Customers.Add(cu.cust);
                uDal.Users.Add(cu.user);
                cDal.SaveChanges();
                uDal.SaveChanges();
                Session["Email"] = cu.cust.email;//Session dictionary needed to keep the account mail/name.
                Session["FirstName"] = cu.cust.fname;
                Session["LastName"] = cu.cust.lname;
                
                return View("Customer", cu.cust);
            }catch(Exception)//Throws exception if the email already used (EMAIL=[KEY])
            {
                Session["Error"] = "Email already used! Please, try again."; 
                return View("Enter", cu);
            }

        }

        public ActionResult Order(Order o)
        {//Function for user to order a cake from the list.
            try
            {
                o.oid = 1000;//BASE order id
                int check = 0;
                o.email = Session["Email"].ToString();
                o.date = DateTime.Now.Date.ToLongDateString();//based
                ProductsDal pDal = new ProductsDal();
                List<Product> obj = pDal.Products.ToList<Product>();
                foreach (Product p in obj)
                {
                    if (p.pid == o.pid)
                        check = 1;
                }
                if (check == 0)//Check if product exists
                {
                    Session["Error"] = "Product ID not exists!";
                    return RedirectToAction("NewOrder");
                }
                OrderDal oDal = new OrderDal();//SAVING PART in order list
                oDal.Orders.Add(o);
                oDal.SaveChanges();
                return RedirectToAction("Purchase", o);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return RedirectToAction("CustomerHomePage", o); 
            }
            
        }
        public ActionResult Purchase(Order o)
        {
            return View(o);
        }

        
        public ActionResult CustomerHomePage(Customer cust)
        {
            return View(cust);
        }

        public ActionResult getOrdersByJson()
        {//JSON 
            OrderDal oDal = new OrderDal();
            List<Order> obj = oDal.Orders.ToList<Order>();
            List<Order> afterOrder = new List<Order>();
            foreach(Order o in obj)
            {
                if(Session["Email"].ToString() == o.email)//Fill afterOrder list with the current email oders
                {
                    afterOrder.Add(o);
                }
            }
            return Json(afterOrder, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MyOrders()
        {
            return View();
        }

        public ActionResult NewOrder()
        {
            return View();
        }

        public ActionResult getProductsByJson()
        {//JSON getting the products by json
            Thread.Sleep(3000);//Sleep--->>> HAPPENED BY MEAN
            ProductsDal pDal = new ProductsDal();
            List<Product> objProducts = pDal.Products.ToList<Product>();
            return Json(objProducts, JsonRequestBehavior.AllowGet);
        }
    }
}