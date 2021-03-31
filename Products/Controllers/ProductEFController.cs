using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class ProductEFController : Controller
    {
        DBFirstEntities dbentity;

        public ProductEFController()
        {
            dbentity = new DBFirstEntities();
        }

        // GET: ProductEF
        public ActionResult Index()
        {
            var products = dbentity.ProductTables.ToList();
            return View(products);
        }

        public ActionResult Search(string name)
        {
            var list = dbentity.ProductTables.Where(c => c.Name == name).ToList();
            return View("Index", list);
        }

        [HttpPost]
        public ActionResult Create(ProductTable prod)
        {

            if (ModelState.IsValid)
            {

                if (prod.id > 0)
                    dbentity.Entry(prod).State = System.Data.Entity.EntityState.Modified;
                else
                    dbentity.ProductTables.Add(prod);


                dbentity.SaveChanges();
                }
            return RedirectToAction("Index");
        }


        public ActionResult Create()
        {
            return View(new ProductTable { id = 0 });
        }

        public ActionResult Delete(int id)
        {
                var prod = dbentity.ProductTables.Find(id);

                if (prod == null)
                    return HttpNotFound();

                dbentity.ProductTables.Remove(prod);
                dbentity.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var prod = dbentity.ProductTables.Find(id);
            return View("Create", prod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                dbentity.Dispose();

            base.Dispose(disposing);
        }
    }

}