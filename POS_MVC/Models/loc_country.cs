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
    
    public partial class loc_country
    {
        public loc_country()
        {
            this.loc_statedivision = new HashSet<loc_statedivision>();
            this.loc_township = new HashSet<loc_township>();
            this.loc_stock_location = new HashSet<loc_stock_location>();
        }
    
        public int country_id { get; set; }
        public string country_name { get; set; }
    
        public virtual ICollection<loc_statedivision> loc_statedivision { get; set; }
        public virtual ICollection<loc_township> loc_township { get; set; }
        public virtual ICollection<loc_stock_location> loc_stock_location { get; set; }
    }
}
