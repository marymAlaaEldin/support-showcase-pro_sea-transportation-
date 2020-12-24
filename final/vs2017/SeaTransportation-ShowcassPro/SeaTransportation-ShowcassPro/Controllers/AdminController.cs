using SeaTransportation_ShowcassPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SeaTransportation_ShowcassPro.Controllers
{
    public class AdminController : Controller
    {
        private SeaTransportationDBEntities6 db = new SeaTransportationDBEntities6();
        // GET: Admin
        public ActionResult mainPage()
        {
            if(Adminloggedin.AdminPassword==null)
                return RedirectToAction("login", db.Users.ToList());
            return View(db.Users.ToList());
        }

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult checkAdmin([Bind(Include = "AdminName,AdminPassword")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var details = db.Admins
                        .Where(x => x.AdminName == admin.AdminName && x.AdminPassword == admin.AdminPassword)
                        .FirstOrDefault<Admin>();

                    if (details.AdminName != null && details.AdminPassword != null)
                    {
                        Adminloggedin.AdminName = admin.AdminName;
                        Adminloggedin.AdminPassword = admin.AdminPassword;

                        return RedirectToAction("mainPage", "Admin");
                    }
                }
                catch
                {
                    return View("login", admin);
                }
            }
                return View("login",admin);
        }

        public ActionResult AddAdmin()
        {
            if (Adminloggedin.AdminPassword == null)
                return RedirectToAction("login", db.Users.ToList());
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAdminData([Bind(Include = "AdminName,AdminPassword")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();

                Adminloggedin.AdminName = admin.AdminName;
                Adminloggedin.AdminPassword = admin.AdminPassword;
            }
            return View("AddAdmin", admin);
        }

        public ActionResult logout()
        {
            Adminloggedin.AdminName = null;
            Adminloggedin.AdminPassword = null;
            return RedirectToAction("mainPage", db.Users.ToList());
        }

        public ActionResult orders()
        {
            return View(db.Orders.ToList());
        }
        [ChildActionOnly]
        public ActionResult ControllShips()
        {
            
            return PartialView(db.Ships.ToList());
        }
        [ChildActionOnly]
        public ActionResult  RenderShipView()
        {
            return PartialView();
        }
        public ActionResult mainShipController()
        {
            if (Adminloggedin.AdminPassword == null)
                return RedirectToAction("login", db.Users.ToList());
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddShip(Ship ship)
        {
            if (ModelState.IsValid)
            {
                ship.availability = true;
                db.Ships.Add(ship);
                db.SaveChanges();

                return RedirectToAction("mainPage");
            }
            return PartialView("RenderShipView", ship);
        }

        // GET: test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("mainPage");
        }

        //for orders
        // GET: test/Delete/5
        public ActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: test/Delete/5
        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("mainPage");
        }
    }
}