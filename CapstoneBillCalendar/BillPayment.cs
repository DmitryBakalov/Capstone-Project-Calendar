//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapstoneBillCalendar
{
    using System;
    using System.Collections.Generic;
    
    public partial class BillPayment
    {
        public int PaymentId { get; set; }
        public string PayeeName { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> PaidDate { get; set; }
        public string Description { get; set; }
        public string ThemeColor { get; set; }
        public bool Paid { get; set; }
        public string username { get; set; }

    }
}
