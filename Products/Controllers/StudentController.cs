using Products.Models;
using Products.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Products.Controllers
{
    public class StudentController : Controller
    {
        StoreConnection dbconnect;

        public StudentController()
        {
            dbconnect = new StoreConnection();
        }
        // GET: Student
        public ActionResult Index()
        {
            var student = dbconnect.student.Include(c => c.house).ToList();
            return View(student);
        }

        public ActionResult Create()
        {
            var house_list = dbconnect.house.ToList();
            StudentHouse sh = new StudentHouse
            {
                student = new Student() { id =0},
                house = house_list
            };
            return View(sh);
        }

        [HttpPost]
        public ActionResult Create(StudentHouse studentHouse)
        {
            if (studentHouse.student.id > 0)
                dbconnect.Entry(studentHouse.student).State = EntityState.Modified;
            else
            dbconnect.student.Add(studentHouse.student);

            dbconnect.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var t = dbconnect.student.Find(id);
            dbconnect.student.Remove(t);
            dbconnect.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var t = dbconnect.student.Find(id);
            StudentHouse sh = new StudentHouse
            {
                student = t,
                house = dbconnect.house.ToList()
            };
            return View("Create", sh);
        }
    }
}