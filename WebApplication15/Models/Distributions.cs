using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class Distributions
    {
        public int distributionId { get; set; }
        public string name { get; set; }
        public int categoryId { get; set; }
        public int cityId { get; set; }
        public string distributorName { get; set; }
        public string distributorEmail { get; set; }
        public string distributorCnic { get; set; }
        public string distributorPhone { get; set; }
    }
}