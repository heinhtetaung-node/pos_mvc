using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_MVC.Models
{
    public class product_model
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> category_id { get; set; }
        public int subcategory_id { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<decimal> current_price { get; set; }
        public Nullable<decimal> cost { get; set; }

        public string category_name { get; set; }
        public string subcategory_name { get; set; }
    }
}