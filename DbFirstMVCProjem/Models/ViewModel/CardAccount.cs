using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DbFirstMVCProjem.Models.ViewModel
{
    public class CardAccount
    {
        [Key]
        public int CardId { get; set; }
        public string CardType { get; set; }
        public decimal CardLimit { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountType { get; set; }
    }
}