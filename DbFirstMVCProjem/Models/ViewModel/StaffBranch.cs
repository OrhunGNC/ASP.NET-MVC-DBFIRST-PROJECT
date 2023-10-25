using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DbFirstMVCProjem.Models.ViewModel
{
    public class StaffBranch
    {
        [Key]
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffPhone { get; set; }
        public string StaffAdress { get; set; }
        public string StaffTitle { get; set; }
        public decimal StaffSalary { get; set; }
        public string BranchAdress { get; set; }
        public string BranchPhone { get; set; }
        public string BranchCapital { get; set; }
    }
}