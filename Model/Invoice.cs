//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WsCRM.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public int InvoiceID { get; set; }
        public decimal PaidMoney { get; set; }
        public int Type { get; set; }
        public int Bank { get; set; }
        public int Status { get; set; }
        public System.DateTime PaidDate { get; set; }
        public Nullable<int> Order_OrderId { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
