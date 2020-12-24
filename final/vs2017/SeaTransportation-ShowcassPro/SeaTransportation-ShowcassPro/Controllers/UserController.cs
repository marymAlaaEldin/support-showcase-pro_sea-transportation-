using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeaTransportation_ShowcassPro.Models;

namespace SeaTransportation_ShowcassPro.Controllers
{
    public class UserController : Controller
    {
        private SeaTransportationDBEntities6 db = new SeaTransportationDBEntities6();

        // GET: User
        public ActionResult SignUp()
        { 
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddData([Bind(Exclude = "ID,message")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();

                userloggedin.Name = user.Name;
                userloggedin.Password = user.Password;
                userloggedin.Email = user.Email;
                userloggedin.phoneNumber = user.phoneNumber;

                return RedirectToAction("Index","Home");
            }
            return View("SignUp",user);
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Check([Bind(Include = "Name,Password,show")] SIGNIN user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var details = db.Users
                    .Where(x => x.Name == user.Name && x.Password == user.Password)
                    .FirstOrDefault<User>();

                    if (details.Name != null && details.Password != null)
                    {
                        //TempData["userdata"] = user;

                        userloggedin.Name = user.Name;
                        userloggedin.Password = user.Password;
                        userloggedin.Email = details.Email;
                        userloggedin.phoneNumber = details.phoneNumber;
                        //userloggedin.ID = details.ID;

                        return RedirectToAction("Index", "Home");
                    }
                }
                catch
                {
                    return View("SignIn",user);
                }
               
            }
            return View("SignIn", user);
        }

        public ActionResult bookingContainers()
        {
            if (userloggedin.Name == null)
                return RedirectToAction("SignIn");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitOrder( Order order)
        {
            
            if (ModelState.IsValid)
            {
                order.TotalDistance = 300;
                order.TotalPrice = 200;
                //order.ID = userloggedin.ID;

                //var ship = db.Ships
                //    .Where(x => x.availability == true)
                //    .FirstOrDefault<Ship>();

                //order.ShipID = ship.ShipID;

                db.Orders.Add(order);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View("bookingContainers", order);
        }

        public ActionResult logout()
        {
            userloggedin.Name = null;
            userloggedin.Password = null;
            userloggedin.Email = null;
            userloggedin.phoneNumber = null;

            return RedirectToAction("Index", "Home");
        }

    }

}
//http://www.dotnetawesome.com/2017/04/complete-login-registration-system-asp-mvc.html