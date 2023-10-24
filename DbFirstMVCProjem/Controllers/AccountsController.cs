using DbFirstMVCProjem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DbFirstMVCProjem.Controllers
{
    [Authorize(Roles ="A,U")]
    public class AccountsController : Controller
    {
        BankEntities db = new BankEntities();
        // GET: Accounts


        public ActionResult Index(string x)
        {
            var search = from p in db.Accounts select p;
            if (x != null)
            {
                search = search.Where(m => m.accountType.Contains(x));

            }
            return View(search.ToList());
        }
        public ActionResult Create()
        {
            List<SelectListItem> datalar = (from x in db.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.customerName,
                                                Value = x.customerID.ToString()
                                            }).ToList();
            ViewBag.veri = datalar;
            List<SelectListItem> datalar2 = (from x in db.Branches.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.branchAdress,
                                                 Value = x.branchID.ToString()
                                             }).ToList();
            ViewBag.veri2 = datalar2;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Account account)
        {
            try
            {
                db.Accounts.Add(account);
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
            var result = db.Accounts.Find(id);
            List<SelectListItem> datalar = (from x in db.Customers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.customerName,
                                                Value = x.customerID.ToString()
                                            }).ToList();
            ViewBag.veri = datalar;
            List<SelectListItem> datalar2 = (from x in db.Branches.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.branchAdress,
                                                 Value = x.branchID.ToString()
                                             }).ToList();
            ViewBag.veri2 = datalar2;
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(int id, Account account)
        {
            try
            {
                db.Entry(account).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.Accounts.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(int id, Account account)
        {
            account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}