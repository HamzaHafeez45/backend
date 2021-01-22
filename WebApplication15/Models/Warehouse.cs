using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class Warehouse
    {
        public int warehouseId { get; set; }

        public string name { get; set; }

        public int distributionId { get; set; }
    }
}