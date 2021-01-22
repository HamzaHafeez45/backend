using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class Products
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string productCode { get; set; }
        public int productPrice { get; set; }
        public string expireable { get; set; }
        public int brandId{ get; set; }
        public int categoryId { get; set; }
        public int quantity { get; set; }

    }
}