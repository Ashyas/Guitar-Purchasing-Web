using Project.Dal;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult ShowHomePage()
        {//Resets the Session 
            Session["FirstName"] = "";
            Session["LastName"] = "";
            Session["Email"] = "";
            return View();
        }

        public ActionResult About(Customer cust)
        {
            return View(cust);
        }


        public ActionResult LogIn()
        {
            return View(new User());
        }
        public ActionResult Enter()
        {
            return View(new Customer_User());
        }
        public ActionResult Submit(User user)//LOG IN
        {//Sign in
            try
            {
                UserDal dal = new UserDal();
                List<User> obj = dal.Users.ToList<User>();
                
                foreach (User u in obj)
                {
                    if (user.email == u.email)//Checking user email with database emails
                        if (user.password == u.password)//Checking user password with database password
                        {//----------------------------------------This part will be to fill Session
                            CustomerDal cdal = new CustomerDal();
                            List<Customer> cobj = cdal.Customers.ToList<Customer>();
                            foreach (Customer c in cobj)
                                if (user.email == c.email)
                                {
                                    Session["Email"] = c.email;
                                    Session["FirstName"] = c.fname;
                                    Session["LastName"] = c.lname;
                                    if (u.type==true)
                                        return RedirectToAction("AdminHomePage", "Admin");
                                    else
                                        return RedirectToAction("CustomerHomePage", "Customer");
                                }//-----------------------              
                        }
                }
                throw new Exception(); //Exception to make sure that email or password are exists/equals
            }
            catch (Exception)
            {
                Session["Error"] = "Email or password does not exists, please try again.";
                return View("LogIn", user);
            }

        }
    }
}