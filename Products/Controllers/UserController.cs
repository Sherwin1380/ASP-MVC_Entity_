using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class UserController : Controller
    {
        StoreConnection dbconnection;

        public UserController()
        {
            dbconnection = new StoreConnection();
        }

        // GET: House
        public ActionResult Index()
        {
            var house = dbconnection.user.ToList();
            return View(house);
        }

        public ActionResult Create()
        {
            return View(new User { id = 0 });
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid) 
                return View("Create", user);
  
                if (user.id > 0)
                    dbconnection.Entry(user).State = System.Data.Entity.EntityState.Modified;
                else
                {
                    if (dbconnection.user.Where(c => c.name == user.name && c.mail == user.mail).Any())
                { 
                        ModelState.AddModelError("mail", "This mail or name already used");
                        return View("Create", user);
                    }
                }
            dbconnection.user.Add(user);
            dbconnection.SaveChanges();
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Delete(int id)
        {
            var t = dbconnection.user.SingleOrDefault(c => c.id == id);
            dbconnection.user.Remove(t);
            dbconnection.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var t = dbconnection.user.SingleOrDefault(c => c.id == id);
            return View("Create", t);
        }

    }
}