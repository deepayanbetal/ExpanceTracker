//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenceDB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Income
    {
        public System.Guid IncomeGuid { get; set; }
        public Nullable<decimal> IncomeAmount { get; set; }
        public Nullable<System.DateTime> IncomeDate { get; set; }
        public Nullable<int> Company_Id { get; set; }
        public Nullable<int> Income_ID { get; set; }
    
        public virtual CompanyMaster CompanyMaster { get; set; }
        public virtual IncomeMaster IncomeMaster { get; set; }
    }
}