using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DbFirstMVCProjem.Models;

namespace DbFirstMVCProjem.Controllers
{
    [Authorize(Roles ="A")]
    public class StaffController : Controller
    {
        BankEntities db = new BankEntities();
        // GET: Staff
        public ActionResult Index()
        {
            var result = db.Staffs.Include(x => x.Branch).ToList();
            return View(result);
        }
        public ActionResult Create()
        {
            List<SelectListItem> datalar = (from x in db.Branches.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.branchAdress,
                                                Value = x.branchID.ToString()
                                            }).ToList();
            ViewBag.veri = datalar;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            try
            {
                db.Staffs.Add(staff);
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
            List<SelectListItem> datalar = (from x in db.Branches.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.branchAdress,
                                                Value = x.branchID.ToString()
                                            }).ToList();
            ViewBag.veri = datalar;
            var result = db.Staffs.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            try
            {
                db.Entry(staff).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.Staffs.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id,Staff staff)
        {
            staff = db.Staffs.Find(id);
            db.Staffs.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}