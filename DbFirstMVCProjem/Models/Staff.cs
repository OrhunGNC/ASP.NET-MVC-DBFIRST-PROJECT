//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbFirstMVCProjem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Staff
    {
        public int staffID { get; set; }
        public string staffName { get; set; }
        public string staffPhone { get; set; }
        public string staffAdress { get; set; }
        public string staffTitle { get; set; }
        public Nullable<decimal> staffSalary { get; set; }
        public Nullable<int> branchID { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}
