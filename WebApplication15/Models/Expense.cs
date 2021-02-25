using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class Expense
    {
        public int expenseId { get; set; }
        public string description { get; set; }
        public decimal ammount { get; set; }
    }
}