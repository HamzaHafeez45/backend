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
        public virtual ICollection<Products> orderedProducts { get; set; }
        public decimal totalAmmount { get; set; }
    }
}