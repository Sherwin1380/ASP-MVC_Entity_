using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class RoleController : Controller
    {

        // GET: Role
        StoreConnection dbconnection;

        public RoleController()
        {
            dbconnection = new StoreConnection();
        }

        // GET: House
        public ActionResult Index()
        {
            var house = dbconnection.role.ToList();
            return View(house);
        }

        public ActionResult Create()
        {
            return View(new Roles { id = 0 });
        }

        [HttpPost]
        public ActionResult Create(Roles role)
        {
            if (role.id > 0)
                dbconnection.Entry(role).State = System.Data.Entity.EntityState.Modified;
            else
                dbconnection.role.Add(role);

            dbconnection.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var t = dbconnection.role.SingleOrDefault(c => c.id == id);
            dbconnection.role.Remove(t);
            dbconnection.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var t = dbconnection.role.SingleOrDefault(c => c.id == id);
            return View("Create", t);
        }
    }
}