using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DbFirstMVCProjem.Models;

namespace DbFirstMVCProjem.Controllers
{
    [Authorize(Roles = "A,U")]
    public class CustomerController : Controller
    {
        BankEntities db = new BankEntities();
        // GET: Customer
        public ActionResult Index()
        {
            var result = db.Customers.ToList();
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var result = db.Customers.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var result = db.Customers.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(Customer customer,int id)
        {
            customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}