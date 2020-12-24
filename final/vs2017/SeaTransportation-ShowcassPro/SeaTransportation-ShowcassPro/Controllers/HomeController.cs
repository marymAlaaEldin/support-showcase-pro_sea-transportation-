using SeaTransportation_ShowcassPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SeaTransportation_ShowcassPro.Controllers
{
    public class HomeController : Controller
    {
        private SeaTransportationDBEntities6 db = new SeaTransportationDBEntities6();
        public ActionResult Index()
        {
            //ViewBag.Message = TempData["userdata"] as SIGNIN;
            SIGNIN user = new SIGNIN();

            user.Name = userloggedin.Name;
            user.Password = userloggedin.Password;
            user.Email = userloggedin.Email;
            user.phoneNumber = userloggedin.phoneNumber;

            return View(user);
        }

        public ActionResult About()
        {
            SIGNIN user = new SIGNIN();

            user.Name = userloggedin.Name;
            user.Password = userloggedin.Password;
            user.Email = userloggedin.Email;
            user.phoneNumber = userloggedin.phoneNumber;

            return View(user);
        }

        public ActionResult Contact()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult get_Contact(ContactData data)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Contact", data);
        }
        [HttpPost]
        public ActionResult feedback(SIGNIN user)
        {
            User userData= db.Users
                            .Where(s => s.Name == userloggedin.Name && s.Password==userloggedin.Password )
                            .FirstOrDefault<User>();
            userData.rate = user.rate;
            userData.feedbackMessage = user.feedbackMessage;
            db.Entry(userData).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index",user);
        }
    }
}