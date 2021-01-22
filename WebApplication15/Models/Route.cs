using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class Route
    {
        public int routeId { get; set; }

        public string name { get; set; }

        public int cityId { get; set; }
        public int areaId { get; set; }
    }
}