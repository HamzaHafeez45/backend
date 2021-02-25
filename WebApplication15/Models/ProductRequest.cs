using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class ProductRequest
    {
        public int productRequestId { get; set; }
        public int productId { get; set; }
        public int brandId { get; set; }
        
        public int requestedQuantity { get; set; }
        public int requestedPrice { get; set; }
    }
}