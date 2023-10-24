using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DbFirstMVCProjem.Models;
using System.Web.Security;
using System.EnterpriseServices;

namespace DbFirstMVCProjem.Controllers
{
    
    public class AdminController : Controller
    {
        BankEntities db = new BankEntities();
        // GET: Admin
        [Authorize(Roles ="A,U")]
        public ActionResult Index()
        {

            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(admin adminn)
        {
            var userlogin = db.admins.FirstOrDefault(x => x.adminNickName == adminn.adminNickName && x.adminPassword == adminn.adminPassword);
            if (userlogin != null)
            {
                FormsAuthentication.SetAuthCookie(userlogin.adminNickName, false);
                return RedirectToAction("Index","Admin");
            }
            else
            {
                ViewBag.hata = "Wrong Username or Password!";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","Admin");
        }
    }
}