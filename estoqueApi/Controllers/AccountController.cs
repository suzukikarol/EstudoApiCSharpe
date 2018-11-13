using estoqueApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace estoqueApi.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.UserAccounts.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.UserAccounts.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " cadastrado com sucesso!";
            }
            return View();
        }
        //login
        public ActionResult Login(UserAccount account)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.UserAccounts.Where(u => u.UserName == account.UserName && u.Password == account.Password).FirstOrDefault();
                if (usr !=null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.UserName.ToString();

                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", " ");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}