using DbFirstMVCProjem.Models;
using DbFirstMVCProjem.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DbFirstMVCProjem.Controllers
{
    [Authorize(Roles ="A")]
    public class ReportsController : Controller
    {
        BankEntities db = new BankEntities();
        // GET: Reports
        public ActionResult StaffBranch()
        {
            var query = (from s in db.Staffs
                        join b in db.Branches on s.branchID equals b.branchID
                        select new StaffBranch
                        {
                            StaffName=s.staffName,
                            StaffPhone=s.staffPhone,
                            StaffAdress=s.staffAdress,
                            StaffTitle = s.staffTitle,
                            StaffSalary = (decimal)s.staffSalary,
                            BranchPhone=b.branchPhone,
                            BranchAdress=b.branchAdress,
                            BranchCapital=b.branchCapital
                        }).ToList();
            return View(query);
        }
        public ActionResult CustomerAccount()
        {
            var query = (from a in db.Accounts
                         join c in db.Customers on a.customerID equals c.customerID
                         select new AccountCustomer
                         {
                             AccountBalance = (decimal)a.accountBalance,
                             AccountType = a.accountType,
                             CustomerName = c.customerName,
                             CustomerPhone = c.customerPhone,
                             CustomerAdress = c.customerAdress,
                             CustomerMail = c.customerMail,
                             CustomerBirthDate = c.customerBirthDate
                         }).ToList();
            return View(query);
        }
        public ActionResult CardAccount()
        {
            var query = (from c in db.Cards
                         join a in db.Accounts on c.accountNo equals a.accountNo
                         select new CardAccount
                         {
                             CardId = c.cardID,
                             CardType = c.cardType,
                             CardLimit = (decimal)c.cardLimit,
                             AccountBalance = (decimal)a.accountBalance,
                             AccountType = a.accountType

                         }).ToList();
            return View(query);
        }
    }
}