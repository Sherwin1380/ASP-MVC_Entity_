using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class HouseController : Controller
    {
        StoreConnection dbconnection;

        public HouseController()
        {
            dbconnection = new StoreConnection();
        }

        // GET: House
        public ActionResult Index()
        {
            var house = dbconnection.house.ToList();
            return View(house);
        }

        public ActionResult Create()
        {
            return View(new House { houseid = 0 });
        }

        [HttpPost]
        public ActionResult Create(House house)
        {
            if (house.houseid > 0)
                dbconnection.Entry(house).State = System.Data.Entity.EntityState.Modified;
            else
                dbconnection.house.Add(house);

            dbconnection.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var t = dbconnection.house.SingleOrDefault(c => c.houseid == id);
            dbconnection.house.Remove(t);
            dbconnection.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var t = dbconnection.house.SingleOrDefault(c => c.houseid == id);
            return View("Create", t);
        }

    }
}
