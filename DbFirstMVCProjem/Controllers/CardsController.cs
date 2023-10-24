using DbFirstMVCProjem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbFirstMVCProjem.Controllers
{
    [Authorize(Roles = "A")]
    public class CardsController : Controller
    {
        BankEntities db = new BankEntities();
        // GET: Cards
        public ActionResult Index(string x)
        {
            var search = from p in db.Cards select p;
            if (x != null)
            {
                search = search.Where(m => m.cardType.Contains(x));
            }
            
            return View(search.ToList());
        }
        public ActionResult Create()
        {
            List<SelectListItem> datalar = (from x in db.Accounts.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.accountNo.ToString(),
                                                Value = x.accountNo.ToString()
                                            }).ToList();
            ViewBag.veri = datalar;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Card card)
        {
            try
            {
                db.Cards.Add(card);
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
            var result = db.Cards.Find(id);
            List<SelectListItem> datalar = (from x in db.Accounts.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.accountNo.ToString(),
                                                Value = x.accountNo.ToString()
                                            }).ToList();
            ViewBag.veri = datalar;
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Card card)
        {
            try
            {
                db.Entry(card).State = System.Data.Entity.EntityState.Modified;
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
            var result = db.Cards.Find(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Delete(Card card,int id)
        {
            card = db.Cards.Find(id);
            db.Cards.Remove(card);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}