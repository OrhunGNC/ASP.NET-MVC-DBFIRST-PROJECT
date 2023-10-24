using DbFirstMVCProjem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbFirstMVCProjem.Controllers
{
    [Authorize(Roles = "A,U")]
    public class BranchesController : Controller
    {
        BankEntities db = new BankEntities();
        // GET: Branches
        public ActionResult Index(string x)
        {
            var search = from p in db.Branches select p;
            if (x != null)
            {
                search=search.Where(m=>m.branchAdress.Contains(x));
            }
            return View(search.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            try
            {
                db.Branches.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = db.Branches.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Branch branch, int id)
        {
            try
            {
                db.Entry(branch).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.Branches.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(Branch branch, int id)
        {
            branch = db.Branches.Find(id);
            db.Branches.Remove(branch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}