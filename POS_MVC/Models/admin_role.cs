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
    
    public partial class admin_role
    {
        public admin_role()
        {
            this.admin_user = new HashSet<admin_user>();
        }
    
        public int admin_role_id { get; set; }
        public string role_name { get; set; }
        public string role_description { get; set; }
    
        public virtual ICollection<admin_user> admin_user { get; set; }
    }
}