using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class shop
    {
        public int shopId { get; set; }
        public string name { get; set; }
        public string shopCnic { get; set; }
        public string shopPhone { get; set; }

        public int cityId { get; set; }
        public int areaId { get; set; }
    }
}