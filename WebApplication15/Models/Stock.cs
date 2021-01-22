using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class Stock
    {
        public int stockId { get; set; }

        public int productId { get; set; }
        public int productQuantity { get; set; }

        public int warehouseId { get; set; }
        public float stockPrice { get; set; }
    }
}