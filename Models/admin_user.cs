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
    
    public partial class admin_user
    {
        public admin_user()
        {
            this.stock_in = new HashSet<stock_in>();
            this.stock_out = new HashSet<stock_out>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public Nullable<int> admin_role_id { get; set; }
        public Nullable<int> stock_location_id { get; set; }
    
        public virtual admin_role admin_role { get; set; }
        public virtual loc_stock_location loc_stock_location { get; set; }
        public virtual ICollection<stock_in> stock_in { get; set; }
        public virtual ICollection<stock_out> stock_out { get; set; }
    }
}
