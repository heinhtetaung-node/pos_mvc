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
    
    public partial class total_daily_transition
    {
        public total_daily_transition()
        {
            this.stock_in = new HashSet<stock_in>();
            this.stock_out = new HashSet<stock_out>();
        }
    
        public int daily_transition_id { get; set; }
        public Nullable<decimal> total_profit_amount { get; set; }
        public Nullable<System.DateTime> income_or_outcome_date { get; set; }
        public Nullable<decimal> total_income_amount { get; set; }
        public Nullable<decimal> total_outgo_amount { get; set; }
        public Nullable<int> stock_location_id { get; set; }
    
        public virtual loc_stock_location loc_stock_location { get; set; }
        public virtual ICollection<stock_in> stock_in { get; set; }
        public virtual ICollection<stock_out> stock_out { get; set; }
    }
}