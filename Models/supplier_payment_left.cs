//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class supplier_payment_left
    {
        public supplier_payment_left()
        {
            this.stock_in = new HashSet<stock_in>();
        }
    
        public int supplier_payment_left_id { get; set; }
        public Nullable<decimal> left_amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<decimal> return_amount { get; set; }
        public int supplier_id { get; set; }
        public Nullable<byte> finish { get; set; }
    
        public virtual ICollection<stock_in> stock_in { get; set; }
        public virtual supplier supplier { get; set; }
    }
}
