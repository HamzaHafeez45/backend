using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class Order
    {
       
        public int shopId { get; set; }
        public int agentId { get; set; }
        public  List<Products> orderedProducts { get; set; }
        public decimal totalAmount { get; set; }
        public decimal totalProfit { get; set; }
    }
}