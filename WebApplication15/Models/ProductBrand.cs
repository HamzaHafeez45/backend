﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class ProductBrand
    {
        public int brandId { get; set; }

        public string name { get; set; }
        public int categoryId { get; set; }
    }
}