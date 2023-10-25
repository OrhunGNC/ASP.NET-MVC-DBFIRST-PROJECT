using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DbFirstMVCProjem.Models.ViewModel
{
    public class AccountCustomer
    {
        [Key]
        public int AccountNo { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountType { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAdress { get; set; }
        public string CustomerMail { get; set; }
        public DateTime? CustomerBirthDate { get; set; }
    }
}