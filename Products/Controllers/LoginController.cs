using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class LoginController : Controller
    {
        StoreConnection dbconnection;

        public LoginController()
        {
            dbconnection = new StoreConnection();
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            
            return View(new Login { });
        }

        [HttpPost]
        public ActionResult Create(Login login)
        {

            if (!ModelState.IsValid)
                return View("Create");

            var login_details = dbconnection.user.Where(c => c.mail == login.mail && c.password == login.password).FirstOrDefault();

            if (login_details == null)
            {
                ModelState.AddModelError("password", "Wrong mail or password");
                return View("Create", login);
            }

            Session["Username"] = login.mail;
            return RedirectToAction("Index", "Home");

        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}